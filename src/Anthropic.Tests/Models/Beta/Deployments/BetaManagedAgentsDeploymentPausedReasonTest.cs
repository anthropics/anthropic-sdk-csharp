using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentPausedReasonTest : TestBase
{
    [Fact]
    public void ManualValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsManualDeploymentPausedReason();
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsErrorDeploymentPausedReason(
                new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError()
            );
        value.Validate();
    }

    [Fact]
    public void ManualSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsManualDeploymentPausedReason();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsErrorDeploymentPausedReason(
                new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError()
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ManualTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsManualDeploymentPausedReason();
        Assert.Equal(BetaManagedAgentsDeploymentPausedReasonType.Manual, value.Type.Value());
    }

    [Fact]
    public void ErrorTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsErrorDeploymentPausedReason(
                new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError()
            );
        Assert.Equal(BetaManagedAgentsDeploymentPausedReasonType.Error, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsDeploymentPausedReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "manual"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType> expectedType =
            BetaManagedAgentsDeploymentPausedReasonType.Manual;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsDeploymentPausedReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsDeploymentPausedReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonType.Manual)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonType.Error)]
    public void Validation_Works(BetaManagedAgentsDeploymentPausedReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonType.Manual, 0, "manual")]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonType.Error, 1, "error")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentPausedReasonType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
