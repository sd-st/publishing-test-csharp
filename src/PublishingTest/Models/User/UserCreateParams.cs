using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace PublishingTest.Models.User;

/// <summary>
/// This can only be done by the logged in user.
/// </summary>
public sealed record class UserCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public long? ID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Email
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["email"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? FirstName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("firstName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["firstName"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? LastName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("lastName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["lastName"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Password
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("password", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["password"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Phone
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("phone", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["phone"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Username
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("username", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["username"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User Status
    /// </summary>
    public int? UserStatus
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("userStatus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<int?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["userStatus"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/user")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IPublishingTestClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
