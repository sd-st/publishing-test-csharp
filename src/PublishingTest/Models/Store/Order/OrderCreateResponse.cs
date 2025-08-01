using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OrderCreateResponseProperties = PublishingTest.Models.Store.Order.OrderCreateResponseProperties;

namespace PublishingTest.Models.Store.Order;

[JsonConverter(typeof(ModelConverter<OrderCreateResponse>))]
public sealed record class OrderCreateResponse : ModelBase, IFromRaw<OrderCreateResponse>
{
    public long? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public bool? Complete
    {
        get
        {
            if (!this.Properties.TryGetValue("complete", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["complete"] = JsonSerializer.SerializeToElement(value); }
    }

    public long? PetID
    {
        get
        {
            if (!this.Properties.TryGetValue("petId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["petId"] = JsonSerializer.SerializeToElement(value); }
    }

    public int? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? ShipDate
    {
        get
        {
            if (!this.Properties.TryGetValue("shipDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["shipDate"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public OrderCreateResponseProperties::Status? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OrderCreateResponseProperties::Status?>(
                element,
                ModelBase.SerializerOptions
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

    public OrderCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrderCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OrderCreateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
