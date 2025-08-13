using System;
using System.Net.Http;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Stores.Orders;

/// <summary>
/// For valid response try integer IDs with value <= 5 or > 10. Other values will
/// generate exceptions.
/// </summary>
public sealed record class OrderRetrieveParams : PublishingTest::ParamsBase
{
    public required long OrderID;

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/store/order/{0}", this.OrderID)
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
