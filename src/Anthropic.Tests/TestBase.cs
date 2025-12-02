using System;

namespace Anthropic.Tests;

/// <summary>
/// This is the TestBase compat used as an intermediary solution until multiple providers can be supported via codegen.
/// </summary>
public abstract class TestBase
{
    protected IAnthropicClient client;

    /// <summary>
    /// This class is only used by codegen tests and should not be used for hand written tests. Use the <see cref="AnthropicTestClientsAttribute"/> instead.
    /// </summary>
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
