using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMcpServerUrlDefinitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string expectedName = "example-mcp";
        JsonElement expectedType = JsonSerializer.SerializeToElement("url");
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpServerUrlDefinition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpServerUrlDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "example-mcp";
        JsonElement expectedType = JsonSerializer.SerializeToElement("url");
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        BetaManagedAgentsMcpServerUrlDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}
