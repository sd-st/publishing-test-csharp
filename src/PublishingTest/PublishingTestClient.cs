using System;
using Http = System.Net.Http;
using Store = PublishingTest.Service.Store;

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

    readonly Lazy<global::PublishingTest.Service.Pet.IPetService> _pet;
    public global::PublishingTest.Service.Pet.IPetService Pet
    {
        get { return _pet.Value; }
    }

    readonly Lazy<Store::IStoreService> _store;
    public Store::IStoreService Store
    {
        get { return _store.Value; }
    }

    readonly Lazy<global::PublishingTest.Service.User.IUserService> _user;
    public global::PublishingTest.Service.User.IUserService User
    {
        get { return _user.Value; }
    }

    public PublishingTestClient()
    {
        _pet = new(() => new global::PublishingTest.Service.Pet.PetService(this));
        _store = new(() => new Store::StoreService(this));
        _user = new(() => new global::PublishingTest.Service.User.UserService(this));
    }
}
