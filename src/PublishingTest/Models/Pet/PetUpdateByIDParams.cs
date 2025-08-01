using System;
using System.Net.Http;
using System.Text.Json;

namespace PublishingTest.Models.Pet;

/// <summary>
/// Updates a pet in the store with form data
/// </summary>
public sealed record class PetUpdateByIDParams : ParamsBase
{
    public required long PetID;

    /// <summary>
    /// Name of pet that needs to be updated
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Status of pet that needs to be updated
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

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
