using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PublishingTest.Models.User;

[JsonConverter(typeof(ModelConverter<User>))]
public sealed record class User : ModelBase, IFromRaw<User>
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

    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["email"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? FirstName
    {
        get
        {
            if (!this.Properties.TryGetValue("firstName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["firstName"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? LastName
    {
        get
        {
            if (!this.Properties.TryGetValue("lastName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["lastName"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Password
    {
        get
        {
            if (!this.Properties.TryGetValue("password", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["password"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Phone
    {
        get
        {
            if (!this.Properties.TryGetValue("phone", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["phone"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Username
    {
        get
        {
            if (!this.Properties.TryGetValue("username", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["username"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User Status
    /// </summary>
    public int? UserStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("userStatus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["userStatus"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.Password;
        _ = this.Phone;
        _ = this.Username;
        _ = this.UserStatus;
    }

    public User() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    User(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static User FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
