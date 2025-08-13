using System;
using System.Net.Http;
using System.Text.Json;
using PetFindByStatusParamsProperties = PublishingTest.Models.Pets.PetFindByStatusParamsProperties;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Pets;

/// <summary>
/// Multiple status values can be provided with comma separated strings
/// </summary>
public sealed record class PetFindByStatusParams : PublishingTest::ParamsBase
{
    /// <summary>
    /// Status values that need to be considered for filter
    /// </summary>
    public PetFindByStatusParamsProperties::Status? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PetFindByStatusParamsProperties::Status?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/pet/findByStatus")
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
