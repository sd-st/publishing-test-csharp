using System;
using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Exceptions;
using PublishingTest.Services.Pets;
using PublishingTest.Services.Stores;
using PublishingTest.Services.Users;

namespace PublishingTest;

public sealed class PublishingTestClient : IPublishingTestClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("PUBLISHING_TEST_BASE_URL")
                ?? "https://petstore3.swagger.io/api/v3"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("PETSTORE_API_KEY")
        ?? throw new PublishingTestInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    readonly Lazy<IPetService> _pets;
    public IPetService Pets
    {
        get { return _pets.Value; }
    }

    readonly Lazy<IStoreService> _stores;
    public IStoreService Stores
    {
        get { return _stores.Value; }
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new PublishingTestIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw PublishingTestExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new PublishingTestIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public PublishingTestClient()
    {
        _pets = new(() => new PetService(this));
        _stores = new(() => new StoreService(this));
        _users = new(() => new UserService(this));
    }
}
