using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationStateTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateEnabled();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateDisabled(
            new BetaTelemetryDestinationDisabledReasonCaller()
        );
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateEnabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateDisabled(
            new BetaTelemetryDestinationDisabledReasonCaller()
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationState>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateEnabled();
        Assert.Equal(BetaTelemetryDestinationStateType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaTelemetryDestinationState value = new BetaTelemetryDestinationStateDisabled(
            new BetaTelemetryDestinationDisabledReasonCaller()
        );
        Assert.Equal(BetaTelemetryDestinationStateType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationState value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaTelemetryDestinationStateType> expectedType =
            BetaTelemetryDestinationStateType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaTelemetryDestinationState emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaTelemetryDestinationStateTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationStateType.Enabled)]
    [InlineData(BetaTelemetryDestinationStateType.Disabled)]
    public void Validation_Works(BetaTelemetryDestinationStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationStateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaTelemetryDestinationStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationStateType.Enabled)]
    [InlineData(BetaTelemetryDestinationStateType.Disabled)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationStateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationStateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaTelemetryDestinationStateType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
