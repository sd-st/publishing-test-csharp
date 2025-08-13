using System;
using System.Net.Http;
using System.Text.Json;
using PublishingTest = PublishingTest;

namespace PublishingTest.Models.Users;

/// <summary>
/// Logs user into the system
/// </summary>
public sealed record class UserLoginParams : PublishingTest::ParamsBase
{
    /// <summary>
    /// The password for login in clear text
    /// </summary>
    public string? Password
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("password", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["password"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The user name for login
    /// </summary>
    public string? Username
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("username", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                PublishingTest::ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["username"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(PublishingTest::IPublishingTestClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/user/login")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        PublishingTest::IPublishingTestClient client
    )
    {
        PublishingTest::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            PublishingTest::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
