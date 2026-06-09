using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsMcpEgressBlockedRunErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
        };

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType> expectedType =
            BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedRunError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedRunError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType> expectedType =
            BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedRunError
        {
            Message = "message",
            Type = BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
        };

        BetaManagedAgentsMcpEgressBlockedRunError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpEgressBlockedRunErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError)]
    public void Validation_Works(BetaManagedAgentsMcpEgressBlockedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpEgressBlockedRunErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
