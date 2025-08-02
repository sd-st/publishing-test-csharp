using System;
using Http = System.Net.Http;
using Pets = PublishingTest.Services.Pets;
using Stores = PublishingTest.Services.Stores;
using Users = PublishingTest.Services.Users;

namespace PublishingTest;

public interface IPublishingTestClient
{
    Http::HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    Pets::IPetService Pets { get; }

    Stores::IStoreService Stores { get; }

    Users::IUserService Users { get; }
}
