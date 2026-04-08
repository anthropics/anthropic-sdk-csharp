using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSessionStatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionStats { ActiveSeconds = 0, DurationSeconds = 0 };

        double expectedActiveSeconds = 0;
        double expectedDurationSeconds = 0;

        Assert.Equal(expectedActiveSeconds, model.ActiveSeconds);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionStats { ActiveSeconds = 0, DurationSeconds = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionStats>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionStats { ActiveSeconds = 0, DurationSeconds = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionStats>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedActiveSeconds = 0;
        double expectedDurationSeconds = 0;

        Assert.Equal(expectedActiveSeconds, deserialized.ActiveSeconds);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionStats { ActiveSeconds = 0, DurationSeconds = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionStats { };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionStats { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionStats
        {
            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            DurationSeconds = null,
        };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionStats
        {
            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            DurationSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionStats { ActiveSeconds = 0, DurationSeconds = 0 };

        BetaManagedAgentsSessionStats copied = new(model);

        Assert.Equal(model, copied);
    }
}
