using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Users;

/// <summary>
/// Creates list of users with given input array
/// </summary>
public sealed record class UserCreateWithListParams : PublishingTest::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public List<User>? Items
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<User>?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["items"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/user/createWithList")
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
