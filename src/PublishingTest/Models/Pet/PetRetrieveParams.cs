using System;
using System.Net.Http;

namespace PublishingTest.Models.Pet;

/// <summary>
/// Returns a single pet
/// </summary>
public sealed record class PetRetrieveParams : ParamsBase
{
    public required long PetID;

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/pet/{0}", this.PetID)
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
