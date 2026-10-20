using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationTracesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTraces
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        ApiEnum<string, BetaTelemetryDestinationContentMode> expectedContentMode =
            BetaTelemetryDestinationContentMode.MetadataOnly;
        bool expectedEnabled = true;
        string expectedEndpointUrl = "endpoint_url";
        int expectedMaxContentBytes = 0;

        Assert.Equal(expectedContentMode, model.ContentMode);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEndpointUrl, model.EndpointUrl);
        Assert.Equal(expectedMaxContentBytes, model.MaxContentBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTraces
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTraces>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationTraces
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTraces>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaTelemetryDestinationContentMode> expectedContentMode =
            BetaTelemetryDestinationContentMode.MetadataOnly;
        bool expectedEnabled = true;
        string expectedEndpointUrl = "endpoint_url";
        int expectedMaxContentBytes = 0;

        Assert.Equal(expectedContentMode, deserialized.ContentMode);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEndpointUrl, deserialized.EndpointUrl);
        Assert.Equal(expectedMaxContentBytes, deserialized.MaxContentBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationTraces
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationTraces
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        BetaTelemetryDestinationTraces copied = new(model);

        Assert.Equal(model, copied);
    }
}
