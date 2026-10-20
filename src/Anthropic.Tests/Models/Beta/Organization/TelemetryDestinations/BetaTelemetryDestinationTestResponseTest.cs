using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationTestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTestResponse
        {
            Result = new BetaTelemetryDestinationTestSuccess(),
        };

        BetaTelemetryDestinationTestResult expectedResult =
            new BetaTelemetryDestinationTestSuccess();
        JsonElement expectedType = JsonSerializer.SerializeToElement("telemetry_destination_test");

        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTestResponse
        {
            Result = new BetaTelemetryDestinationTestSuccess(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationTestResponse
        {
            Result = new BetaTelemetryDestinationTestSuccess(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaTelemetryDestinationTestResult expectedResult =
            new BetaTelemetryDestinationTestSuccess();
        JsonElement expectedType = JsonSerializer.SerializeToElement("telemetry_destination_test");

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationTestResponse
        {
            Result = new BetaTelemetryDestinationTestSuccess(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationTestResponse
        {
            Result = new BetaTelemetryDestinationTestSuccess(),
        };

        BetaTelemetryDestinationTestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
