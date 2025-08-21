using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.OrderProperties;

/// <summary>
/// Order Status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Placed,
    Approved,
    Delivered,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "placed" => Status.Placed,
            "approved" => Status.Approved,
            "delivered" => Status.Delivered,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Placed => "placed",
                Status.Approved => "approved",
                Status.Delivered => "delivered",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
