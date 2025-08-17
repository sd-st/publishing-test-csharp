using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.Pets;

[JsonConverter(typeof(ModelConverter<Category>))]
public sealed record class Category : ModelBase, IFromRaw<Category>
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

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public Category() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Category(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Category FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
