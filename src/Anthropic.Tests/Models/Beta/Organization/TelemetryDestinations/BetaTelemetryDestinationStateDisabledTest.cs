using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationStateDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationStateDisabled
        {
            Reason = new BetaTelemetryDestinationDisabledReasonCaller(),
        };

        BetaTelemetryDestinationDisabledReason expectedReason =
            new BetaTelemetryDestinationDisabledReasonCaller();
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationStateDisabled
        {
            Reason = new BetaTelemetryDestinationDisabledReasonCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationStateDisabled
        {
            Reason = new BetaTelemetryDestinationDisabledReasonCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaTelemetryDestinationDisabledReason expectedReason =
            new BetaTelemetryDestinationDisabledReasonCaller();
        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationStateDisabled
        {
            Reason = new BetaTelemetryDestinationDisabledReasonCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationStateDisabled
        {
            Reason = new BetaTelemetryDestinationDisabledReasonCaller(),
        };

        BetaTelemetryDestinationStateDisabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
