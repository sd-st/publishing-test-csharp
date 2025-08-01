using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace PublishingTest.Models.Pets;

/// <summary>
/// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3
/// for testing.
/// </summary>
public sealed record class PetFindByTagsParams : ParamsBase
{
    /// <summary>
    /// Tags to filter by
    /// </summary>
    public List<string>? Tags
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element);
        }
        set { this.QueryProperties["tags"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/pet/findByTags")
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
