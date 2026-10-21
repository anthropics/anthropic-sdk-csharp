using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationStateEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationStateEnabled { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationStateEnabled { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateEnabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationStateEnabled { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationStateEnabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("enabled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationStateEnabled { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationStateEnabled { };

        BetaTelemetryDestinationStateEnabled copied = new(model);

        Assert.Equal(model, copied);
    }
}
