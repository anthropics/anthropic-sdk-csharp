using System;
using Anthropic;

namespace Anthropic.Tests;

public class TestBase
{
    protected IAnthropicClient client;

    public TestBase()
    {
        client = new AnthropicClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "my-anthropic-api-key",
        };
    }
}
