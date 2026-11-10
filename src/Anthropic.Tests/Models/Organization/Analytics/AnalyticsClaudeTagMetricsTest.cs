using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsClaudeTagMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsClaudeTagMetrics { ActiveDayCount = 0, ActiveMessageCount = 0 };

        long expectedActiveDayCount = 0;
        long expectedActiveMessageCount = 0;

        Assert.Equal(expectedActiveDayCount, model.ActiveDayCount);
        Assert.Equal(expectedActiveMessageCount, model.ActiveMessageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsClaudeTagMetrics { ActiveDayCount = 0, ActiveMessageCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsClaudeTagMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsClaudeTagMetrics { ActiveDayCount = 0, ActiveMessageCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsClaudeTagMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedActiveDayCount = 0;
        long expectedActiveMessageCount = 0;

        Assert.Equal(expectedActiveDayCount, deserialized.ActiveDayCount);
        Assert.Equal(expectedActiveMessageCount, deserialized.ActiveMessageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsClaudeTagMetrics { ActiveDayCount = 0, ActiveMessageCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsClaudeTagMetrics { ActiveDayCount = 0, ActiveMessageCount = 0 };

        AnalyticsClaudeTagMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
