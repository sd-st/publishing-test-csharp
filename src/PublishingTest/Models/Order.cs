using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OrderProperties = PublishingTest.Models.OrderProperties;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models;

[JsonConverter(typeof(PublishingTest::ModelConverter<Order>))]
public sealed record class Order : PublishingTest::ModelBase, PublishingTest::IFromRaw<Order>
{
    public long? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public bool? Complete
    {
        get
        {
            if (!this.Properties.TryGetValue("complete", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["complete"] = JsonSerializer.SerializeToElement(value); }
    }

    public long? PetID
    {
        get
        {
            if (!this.Properties.TryGetValue("petId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["petId"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? ShipDate
    {
        get
        {
            if (!this.Properties.TryGetValue("shipDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["shipDate"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public OrderProperties::Status? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OrderProperties::Status?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Complete;
        _ = this.PetID;
        _ = this.Quantity;
        _ = this.ShipDate;
        this.Status?.Validate();
    }

    public Order() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Order(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Order FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
