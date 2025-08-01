using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.Pet;

[JsonConverter(typeof(ModelConverter<PetUploadImageResponse>))]
public sealed record class PetUploadImageResponse : ModelBase, IFromRaw<PetUploadImageResponse>
{
    public int? Code
    {
        get
        {
            if (!this.Properties.TryGetValue("code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["code"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["message"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Code;
        _ = this.Message;
        _ = this.Type;
    }

    public PetUploadImageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetUploadImageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PetUploadImageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
