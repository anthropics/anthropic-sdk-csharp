using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
        };

        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError
    )]
    public void Validation_Works(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
