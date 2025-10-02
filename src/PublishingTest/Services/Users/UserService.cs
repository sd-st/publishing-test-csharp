using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Models.Users;

namespace PublishingTest.Services.Users;

public sealed class UserService : IUserService
{
    readonly IPublishingTestClient _client;

    public UserService(IPublishingTestClient client)
    {
        _client = client;
    }

    public async Task<User> Create(UserCreateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<UserCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<User>().ConfigureAwait(false);
    }

    public async Task<User> Retrieve(UserRetrieveParams parameters)
    {
        HttpRequest<UserRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<User>().ConfigureAwait(false);
    }

    public async Task Update(UserUpdateParams parameters)
    {
        HttpRequest<UserUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Delete(UserDeleteParams parameters)
    {
        HttpRequest<UserDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<User> CreateWithList(UserCreateWithListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<UserCreateWithListParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<User>().ConfigureAwait(false);
    }

    public async Task<string> Login(UserLoginParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<UserLoginParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<string>().ConfigureAwait(false);
    }

    public async Task Logout(UserLogoutParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<UserLogoutParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
