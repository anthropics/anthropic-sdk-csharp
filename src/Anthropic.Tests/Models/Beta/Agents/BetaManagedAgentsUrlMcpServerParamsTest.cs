using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsUrlMcpServerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUrlMcpServerParams
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string expectedName = "example-mcp";
        ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType> expectedType =
            BetaManagedAgentsUrlMcpServerParamsType.Url;
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUrlMcpServerParams
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUrlMcpServerParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUrlMcpServerParams
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUrlMcpServerParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "example-mcp";
        ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType> expectedType =
            BetaManagedAgentsUrlMcpServerParamsType.Url;
        string expectedUrl = "https://example-server.modelcontextprotocol.io/sse";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUrlMcpServerParams
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUrlMcpServerParams
        {
            Name = "example-mcp",
            Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
            Url = "https://example-server.modelcontextprotocol.io/sse",
        };

        BetaManagedAgentsUrlMcpServerParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUrlMcpServerParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUrlMcpServerParamsType.Url)]
    public void Validation_Works(BetaManagedAgentsUrlMcpServerParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUrlMcpServerParamsType.Url)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUrlMcpServerParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
