using System;
using System.Net.Http;

namespace PublishingTest.Models.User;

/// <summary>
/// Logs out current logged in user session
/// </summary>
public sealed record class UserLogoutParams : ParamsBase
{
    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/user/logout")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IPublishingTestClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
