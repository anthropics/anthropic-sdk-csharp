using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsErrorDeploymentPausedReasonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            ),
            Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
        };

        BetaManagedAgentsDeploymentPausedReasonError expectedError =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            );
        ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType> expectedType =
            BetaManagedAgentsErrorDeploymentPausedReasonType.Error;

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            ),
            Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsErrorDeploymentPausedReason>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            ),
            Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsErrorDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsDeploymentPausedReasonError expectedError =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            );
        ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType> expectedType =
            BetaManagedAgentsErrorDeploymentPausedReasonType.Error;

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            ),
            Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            ),
            Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
        };

        BetaManagedAgentsErrorDeploymentPausedReason copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsErrorDeploymentPausedReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsErrorDeploymentPausedReasonType.Error)]
    public void Validation_Works(BetaManagedAgentsErrorDeploymentPausedReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsErrorDeploymentPausedReasonType.Error)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsErrorDeploymentPausedReasonType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsErrorDeploymentPausedReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
