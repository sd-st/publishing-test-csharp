using System;
using System.Net.Http;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Pets;

/// <summary>
/// Returns a single pet
/// </summary>
public sealed record class PetRetrieveParams : PublishingTest::ParamsBase
{
    public required long PetID;

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/pet/{0}", this.PetID)
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
