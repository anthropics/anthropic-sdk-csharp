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

        JsonElement expectedType = JsonSerializer.SerializeToElement("caller");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaTelemetryDestinationDisabledReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
