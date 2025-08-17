using System;
using System.Net.Http;
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
        ?? throw new ArgumentNullException(nameof(APIKey))
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

    public PublishingTestClient()
    {
        _pets = new(() => new PetService(this));
        _stores = new(() => new StoreService(this));
        _users = new(() => new UserService(this));
    }
}
