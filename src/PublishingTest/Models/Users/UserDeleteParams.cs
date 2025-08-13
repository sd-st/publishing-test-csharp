using System;
using System.Net.Http;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Users;

/// <summary>
/// This can only be done by the logged in user.
/// </summary>
public sealed record class UserDeleteParams : PublishingTest::ParamsBase
{
    public required string Username;

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/user/{0}", this.Username)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        PublishingTest::IPublishingTestClient client
    )
    {
        PublishingTest::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            PublishingTest::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
