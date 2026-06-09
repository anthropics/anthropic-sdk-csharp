using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
        };

        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError
    )]
    public void Validation_Works(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
