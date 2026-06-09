using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsManualDeploymentPausedReasonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsManualDeploymentPausedReason
        {
            Type = BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
        };

        ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> expectedType =
            BetaManagedAgentsManualDeploymentPausedReasonType.Manual;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsManualDeploymentPausedReason
        {
            Type = BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsManualDeploymentPausedReason>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsManualDeploymentPausedReason
        {
            Type = BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsManualDeploymentPausedReason>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> expectedType =
            BetaManagedAgentsManualDeploymentPausedReasonType.Manual;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsManualDeploymentPausedReason
        {
            Type = BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsManualDeploymentPausedReason
        {
            Type = BetaManagedAgentsManualDeploymentPausedReasonType.Manual,
        };

        BetaManagedAgentsManualDeploymentPausedReason copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsManualDeploymentPausedReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsManualDeploymentPausedReasonType.Manual)]
    public void Validation_Works(BetaManagedAgentsManualDeploymentPausedReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsManualDeploymentPausedReasonType.Manual)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsManualDeploymentPausedReasonType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualDeploymentPausedReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
