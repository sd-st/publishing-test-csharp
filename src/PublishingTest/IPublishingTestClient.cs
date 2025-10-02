using System;
using System.Net.Http;
using System.Threading.Tasks;
using PublishingTest.Core;
using PublishingTest.Services.Pets;
using PublishingTest.Services.Stores;
using PublishingTest.Services.Users;

namespace PublishingTest;

public interface IPublishingTestClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    IPetService Pets { get; }

    IStoreService Stores { get; }

    IUserService Users { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
