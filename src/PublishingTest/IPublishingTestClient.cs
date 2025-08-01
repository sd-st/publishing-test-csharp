using System;
using Http = System.Net.Http;
using Store = PublishingTest.Service.Store;

namespace PublishingTest;

public interface IPublishingTestClient
{
    Http::HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    global::PublishingTest.Service.Pet.IPetService Pet { get; }

    Store::IStoreService Store { get; }

    global::PublishingTest.Service.User.IUserService User { get; }
}
