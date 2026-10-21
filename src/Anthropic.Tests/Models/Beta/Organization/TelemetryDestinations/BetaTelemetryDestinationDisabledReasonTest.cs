using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationDisabledReasonTest : TestBase
{
    [Fact]
    public void CallerValidationWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonCaller();
        value.Validate();
    }

    [Fact]
    public void SustainedFailureValidationWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonSustainedFailure();
        value.Validate();
    }

    [Fact]
    public void InvalidAddressValidationWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonInvalidAddress();
        value.Validate();
    }

    [Fact]
    public void RedirectValidationWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonRedirect();
        value.Validate();
    }

    [Fact]
    public void CallerSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SustainedFailureSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonSustainedFailure();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidAddressSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonInvalidAddress();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RedirectSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonRedirect();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CallerTypeWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonCaller();
        Assert.Equal(BetaTelemetryDestinationDisabledReasonType.Caller, value.Type.Value());
    }

    [Fact]
    public void SustainedFailureTypeWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonSustainedFailure();
        Assert.Equal(
            BetaTelemetryDestinationDisabledReasonType.SustainedFailure,
            value.Type.Value()
        );
    }

    [Fact]
    public void InvalidAddressTypeWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonInvalidAddress();
        Assert.Equal(BetaTelemetryDestinationDisabledReasonType.InvalidAddress, value.Type.Value());
    }

    [Fact]
    public void RedirectTypeWorks()
    {
        BetaTelemetryDestinationDisabledReason value =
            new BetaTelemetryDestinationDisabledReasonRedirect();
        Assert.Equal(BetaTelemetryDestinationDisabledReasonType.Redirect, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationDisabledReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "caller"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaTelemetryDestinationDisabledReasonType> expectedType =
            BetaTelemetryDestinationDisabledReasonType.Caller;

        Assert.Equal(expectedType, value.Type);

        BetaTelemetryDestinationDisabledReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaTelemetryDestinationDisabledReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.Caller)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.SustainedFailure)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.InvalidAddress)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.Redirect)]
    public void Validation_Works(BetaTelemetryDestinationDisabledReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationDisabledReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationDisabledReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.Caller)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.SustainedFailure)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.InvalidAddress)]
    [InlineData(BetaTelemetryDestinationDisabledReasonType.Redirect)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationDisabledReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationDisabledReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationDisabledReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationDisabledReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationDisabledReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
