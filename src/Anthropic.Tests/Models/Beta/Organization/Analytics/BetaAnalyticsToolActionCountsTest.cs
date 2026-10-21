using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsToolActionCountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsToolActionCounts { AcceptedCount = 0, RejectedCount = 0 };

        long expectedAcceptedCount = 0;
        long expectedRejectedCount = 0;

        Assert.Equal(expectedAcceptedCount, model.AcceptedCount);
        Assert.Equal(expectedRejectedCount, model.RejectedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsToolActionCounts { AcceptedCount = 0, RejectedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsToolActionCounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsToolActionCounts { AcceptedCount = 0, RejectedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsToolActionCounts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAcceptedCount = 0;
        long expectedRejectedCount = 0;

        Assert.Equal(expectedAcceptedCount, deserialized.AcceptedCount);
        Assert.Equal(expectedRejectedCount, deserialized.RejectedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsToolActionCounts { AcceptedCount = 0, RejectedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsToolActionCounts { AcceptedCount = 0, RejectedCount = 0 };

        BetaAnalyticsToolActionCounts copied = new(model);

        Assert.Equal(model, copied);
    }
}
