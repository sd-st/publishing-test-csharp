using System;
using Http = System.Net.Http;
using Pets = PublishingTest.Service.Pets;
using Stores = PublishingTest.Service.Stores;
using Users = PublishingTest.Service.Users;

namespace PublishingTest;

public sealed class PublishingTestClient : IPublishingTestClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

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

    readonly Lazy<Pets::IPetService> _pets;
    public Pets::IPetService Pets
    {
        get { return _pets.Value; }
    }

    readonly Lazy<Stores::IStoreService> _stores;
    public Stores::IStoreService Stores
    {
        get { return _stores.Value; }
    }

    readonly Lazy<Users::IUserService> _users;
    public Users::IUserService Users
    {
        get { return _users.Value; }
    }

    public PublishingTestClient()
    {
        _pets = new(() => new Pets::PetService(this));
        _stores = new(() => new Stores::StoreService(this));
        _users = new(() => new Users::UserService(this));
    }
}
