using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationDeliveryHealthTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationDeliveryHealth
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedLastError = "last_error";
        DateTimeOffset expectedLastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedLastError, model.LastError);
        Assert.Equal(expectedLastErrorAt, model.LastErrorAt);
        Assert.Equal(expectedLastSuccessAt, model.LastSuccessAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationDeliveryHealth
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDeliveryHealth>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationDeliveryHealth
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationDeliveryHealth>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLastError = "last_error";
        DateTimeOffset expectedLastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedLastError, deserialized.LastError);
        Assert.Equal(expectedLastErrorAt, deserialized.LastErrorAt);
        Assert.Equal(expectedLastSuccessAt, deserialized.LastSuccessAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationDeliveryHealth
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationDeliveryHealth
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaTelemetryDestinationDeliveryHealth copied = new(model);

        Assert.Equal(model, copied);
    }
}
