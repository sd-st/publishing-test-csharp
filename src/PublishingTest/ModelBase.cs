using System.Collections.Generic;
using System.Text.Json;
using PublishingTest.Models.OrderProperties;
using OrderCreateParamsProperties = PublishingTest.Models.Stores.Orders.OrderCreateParamsProperties;
using PetCreateParamsProperties = PublishingTest.Models.Pets.PetCreateParamsProperties;
using PetFindByStatusParamsProperties = PublishingTest.Models.Pets.PetFindByStatusParamsProperties;
using PetProperties = PublishingTest.Models.Pets.PetProperties;
using PetUpdateParamsProperties = PublishingTest.Models.Pets.PetUpdateParamsProperties;

namespace PublishingTest;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, PetProperties::Status>(),
            new ApiEnumConverter<string, PetCreateParamsProperties::Status>(),
            new ApiEnumConverter<string, PetUpdateParamsProperties::Status>(),
            new ApiEnumConverter<string, PetFindByStatusParamsProperties::Status>(),
            new ApiEnumConverter<string, OrderCreateParamsProperties::Status>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
