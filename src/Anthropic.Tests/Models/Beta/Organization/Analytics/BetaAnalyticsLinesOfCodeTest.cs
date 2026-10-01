using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsLinesOfCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsLinesOfCode { AddedCount = 0, RemovedCount = 0 };

        long expectedAddedCount = 0;
        long expectedRemovedCount = 0;

        Assert.Equal(expectedAddedCount, model.AddedCount);
        Assert.Equal(expectedRemovedCount, model.RemovedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsLinesOfCode { AddedCount = 0, RemovedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsLinesOfCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsLinesOfCode { AddedCount = 0, RemovedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsLinesOfCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAddedCount = 0;
        long expectedRemovedCount = 0;

        Assert.Equal(expectedAddedCount, deserialized.AddedCount);
        Assert.Equal(expectedRemovedCount, deserialized.RemovedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsLinesOfCode { AddedCount = 0, RemovedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsLinesOfCode { AddedCount = 0, RemovedCount = 0 };

        BetaAnalyticsLinesOfCode copied = new(model);

        Assert.Equal(model, copied);
    }
}
