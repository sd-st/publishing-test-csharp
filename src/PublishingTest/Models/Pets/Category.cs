using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Pets;

[JsonConverter(typeof(PublishingTest::ModelConverter<Category>))]
public sealed record class Category : PublishingTest::ModelBase, PublishingTest::IFromRaw<Category>
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

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
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
