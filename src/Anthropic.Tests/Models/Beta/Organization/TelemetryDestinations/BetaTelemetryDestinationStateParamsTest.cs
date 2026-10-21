using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationStateParamsTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateEnabledParams();
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateDisabledParams();
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateEnabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateDisabledParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnabledTypeWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateEnabledParams();
        Assert.Equal(BetaTelemetryDestinationStateParamsType.Enabled, value.Type.Value());
    }

    [Fact]
    public void DisabledTypeWorks()
    {
        BetaTelemetryDestinationStateParams value =
            new BetaTelemetryDestinationStateDisabledParams();
        Assert.Equal(BetaTelemetryDestinationStateParamsType.Disabled, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationStateParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "enabled"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaTelemetryDestinationStateParamsType> expectedType =
            BetaTelemetryDestinationStateParamsType.Enabled;

        Assert.Equal(expectedType, value.Type);

        BetaTelemetryDestinationStateParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaTelemetryDestinationStateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationStateParamsType.Enabled)]
    [InlineData(BetaTelemetryDestinationStateParamsType.Disabled)]
    public void Validation_Works(BetaTelemetryDestinationStateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationStateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationStateParamsType.Enabled)]
    [InlineData(BetaTelemetryDestinationStateParamsType.Disabled)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationStateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationStateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationStateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
