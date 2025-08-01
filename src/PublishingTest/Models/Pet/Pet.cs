using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PetProperties = PublishingTest.Models.Pet.PetProperties;

namespace PublishingTest.Models.Pet;

[JsonConverter(typeof(ModelConverter<Pet>))]
public sealed record class Pet : ModelBase, IFromRaw<Pet>
{
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<string> PhotoURLs
    {
        get
        {
            if (!this.Properties.TryGetValue("photoUrls", out JsonElement element))
                throw new ArgumentOutOfRangeException("photoUrls", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("photoUrls");
        }
        set { this.Properties["photoUrls"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public Category? Category
    {
        get
        {
            if (!this.Properties.TryGetValue("category", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Category?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["category"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public PetProperties::Status? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PetProperties::Status?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<PetProperties::Tag>? Tags
    {
        get
        {
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<PetProperties::Tag>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["tags"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Name;
        foreach (var item in this.PhotoURLs)
        {
            _ = item;
        }
        _ = this.ID;
        this.Category?.Validate();
        this.Status?.Validate();
        foreach (var item in this.Tags ?? [])
        {
            item.Validate();
        }
    }

    public Pet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pet(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Pet FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
