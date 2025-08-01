using System;
using System.Net.Http;

namespace PublishingTest.Models.Stores.Order;

/// <summary>
/// For valid response try integer IDs with value <= 5 or > 10. Other values will
/// generate exceptions.
/// </summary>
public sealed record class OrderRetrieveParams : ParamsBase
{
    public required long OrderID;

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/store/order/{0}", this.OrderID)
        )
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
