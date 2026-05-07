using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Threads;

namespace Anthropic.Tests.Models.Beta.Sessions.Threads;

public class BetaManagedAgentsSessionThreadStatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };

        double expectedActiveSeconds = 0;
        double expectedDurationSeconds = 0;
        double expectedStartupSeconds = 0;

        Assert.Equal(expectedActiveSeconds, model.ActiveSeconds);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedStartupSeconds, model.StartupSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStats>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStats>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedActiveSeconds = 0;
        double expectedDurationSeconds = 0;
        double expectedStartupSeconds = 0;

        Assert.Equal(expectedActiveSeconds, deserialized.ActiveSeconds);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedStartupSeconds, deserialized.StartupSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats { };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.StartupSeconds);
        Assert.False(model.RawData.ContainsKey("startup_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            DurationSeconds = null,
            StartupSeconds = null,
        };

        Assert.Null(model.ActiveSeconds);
        Assert.False(model.RawData.ContainsKey("active_seconds"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("duration_seconds"));
        Assert.Null(model.StartupSeconds);
        Assert.False(model.RawData.ContainsKey("startup_seconds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            // Null should be interpreted as omitted for these properties
            ActiveSeconds = null,
            DurationSeconds = null,
            StartupSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStats
        {
            ActiveSeconds = 0,
            DurationSeconds = 0,
            StartupSeconds = 0,
        };

        BetaManagedAgentsSessionThreadStats copied = new(model);

        Assert.Equal(model, copied);
    }
}
