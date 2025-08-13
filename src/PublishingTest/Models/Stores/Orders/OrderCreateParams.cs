using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using OrderCreateParamsProperties = PublishingTest.Models.Stores.Orders.OrderCreateParamsProperties;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Stores.Orders;

/// <summary>
/// Place a new order in the store
/// </summary>
public sealed record class OrderCreateParams : PublishingTest::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public long? ID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public bool? Complete
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("complete", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["complete"] = JsonSerializer.SerializeToElement(value); }
    }

    public long? PetID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("petId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["petId"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? ShipDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("shipDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["shipDate"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public OrderCreateParamsProperties::Status? Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OrderCreateParamsProperties::Status?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/store/order")
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
