using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string expectedName = "example-mcp";
        ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType> expectedType =
            BetaManagedAgentsMcpServerUrlDefinitionType.Url;
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
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
            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpServerUrlDefinition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "example-mcp";
        ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType> expectedType =
            BetaManagedAgentsMcpServerUrlDefinitionType.Url;
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpServerUrlDefinition
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
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
            Type = BetaManagedAgentsMcpServerUrlDefinitionType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        BetaManagedAgentsMcpServerUrlDefinition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpServerUrlDefinitionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpServerUrlDefinitionType.Url)]
    public void Validation_Works(BetaManagedAgentsMcpServerUrlDefinitionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpServerUrlDefinitionType.Url)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpServerUrlDefinitionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpServerUrlDefinitionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
