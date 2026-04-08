using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsStaticBearerAuthResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerAuthResponse
        {
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
        };

        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType> expectedType =
            BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer;

        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerAuthResponse
        {
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerAuthResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsStaticBearerAuthResponse
        {
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerAuthResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType> expectedType =
            BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer;

        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerAuthResponse
        {
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsStaticBearerAuthResponse
        {
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
        };

        BetaManagedAgentsStaticBearerAuthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsStaticBearerAuthResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer)]
    public void Validation_Works(BetaManagedAgentsStaticBearerAuthResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsStaticBearerAuthResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
