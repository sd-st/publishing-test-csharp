using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Pets;

/// <summary>
/// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3
/// for testing.
/// </summary>
public sealed record class PetFindByTagsParams : PublishingTest::ParamsBase
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

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["tags"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/pet/findByTags")
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
