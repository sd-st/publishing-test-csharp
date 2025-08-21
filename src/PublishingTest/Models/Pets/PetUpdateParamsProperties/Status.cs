using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.Pets.PetUpdateParamsProperties;

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Available,
    Pending,
    Sold,
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
            "available" => Status.Available,
            "pending" => Status.Pending,
            "sold" => Status.Sold,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Available => "available",
                Status.Pending => "pending",
                Status.Sold => "sold",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
