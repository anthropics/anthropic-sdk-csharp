using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsStaticBearerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };

        string expectedToken = "bearer_exampletoken";
        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        JsonElement expectedType = JsonSerializer.SerializeToElement("static_bearer");

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "bearer_exampletoken";
        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        JsonElement expectedType = JsonSerializer.SerializeToElement("static_bearer");

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
        };

        BetaManagedAgentsStaticBearerCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
