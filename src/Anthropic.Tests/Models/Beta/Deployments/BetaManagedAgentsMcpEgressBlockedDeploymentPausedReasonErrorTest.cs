using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
        };

        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError
    )]
    public void Validation_Works(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
