using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsUnknownDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
        };

        ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> expectedType =
            BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnknownDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUnknownDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUnknownDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUnknownDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> expectedType =
            BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUnknownDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUnknownDeploymentPausedReasonError
        {
            Type = BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
        };

        BetaManagedAgentsUnknownDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUnknownDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError)]
    public void Validation_Works(BetaManagedAgentsUnknownDeploymentPausedReasonErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUnknownDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
