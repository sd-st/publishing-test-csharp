using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.Pets.PetProperties;

[JsonConverter(typeof(ModelConverter<Tag>))]
public sealed record class Tag : ModelBase, IFromRaw<Tag>
{
    public long? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public Tag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tag FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
