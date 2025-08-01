using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PetUpdateParamsProperties = PublishingTest.Models.Pet.PetUpdateParamsProperties;

namespace PublishingTest.Models.Pet;

/// <summary>
/// Update an existing pet by Id
/// </summary>
public sealed record class PetUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<string> PhotoURLs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("photoUrls", out JsonElement element))
                throw new ArgumentOutOfRangeException("photoUrls", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("photoUrls");
        }
        set { this.BodyProperties["photoUrls"] = JsonSerializer.SerializeToElement(value); }
    }

    public long? ID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public Category? Category
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Category?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["category"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public PetUpdateParamsProperties::Status? Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PetUpdateParamsProperties::Status?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<PetUpdateParamsProperties::Tag>? Tags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PetUpdateParamsProperties::Tag>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["tags"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/pet")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
