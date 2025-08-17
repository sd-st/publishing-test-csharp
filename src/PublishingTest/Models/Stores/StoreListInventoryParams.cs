using System;
using System.Net.Http;

namespace PublishingTest.Models.Stores;

/// <summary>
/// Returns a map of status codes to quantities
/// </summary>
public sealed record class StoreListInventoryParams : ParamsBase
{
    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/store/inventory")
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
