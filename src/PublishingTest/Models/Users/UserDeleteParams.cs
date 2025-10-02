using System;
using System.Net.Http;
using PublishingTest.Core;

namespace PublishingTest.Models.Users;

/// <summary>
/// This can only be done by the logged in user.
/// </summary>
public sealed record class UserDeleteParams : ParamsBase
{
    public required string Username;

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/user/{0}", this.Username)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IPublishingTestClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
