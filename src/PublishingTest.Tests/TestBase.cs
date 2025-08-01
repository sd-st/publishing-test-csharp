using System;
using PublishingTest;

namespace PublishingTest.Tests;

public class TestBase
{
    protected IPublishingTestClient client;

    public TestBase()
    {
        client = new PublishingTestClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
