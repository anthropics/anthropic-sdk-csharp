using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };

        string expectedToken = "bearer_exampletoken";
        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType> expectedType =
            BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
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
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "bearer_exampletoken";
        string expectedMcpServerUrl = "https://example-server.modelcontextprotocol.io/sse";
        ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType> expectedType =
            BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerCreateParams
        {
            Token = "bearer_exampletoken",
            McpServerUrl = "https://example-server.modelcontextprotocol.io/sse",
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
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
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
        };

        BetaManagedAgentsStaticBearerCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsStaticBearerCreateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer)]
    public void Validation_Works(BetaManagedAgentsStaticBearerCreateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsStaticBearerCreateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
