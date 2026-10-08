using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsSkillChatCoworkUnifiedSessionsMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics
        {
            DistinctSessionSkillUsedCount = 0,
        };

        long expectedDistinctSessionSkillUsedCount = 0;

        Assert.Equal(expectedDistinctSessionSkillUsedCount, model.DistinctSessionSkillUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics
        {
            DistinctSessionSkillUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics
        {
            DistinctSessionSkillUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionSkillUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionSkillUsedCount,
            deserialized.DistinctSessionSkillUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics
        {
            DistinctSessionSkillUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics
        {
            DistinctSessionSkillUsedCount = 0,
        };

        BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
