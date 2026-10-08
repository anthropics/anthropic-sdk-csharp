using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsSkillChatCoworkUnifiedChatMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        long expectedDistinctConversationSkillUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationSkillUsedCount,
            model.DistinctConversationSkillUsedCount
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedChatMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedChatMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedDistinctConversationSkillUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationSkillUsedCount,
            deserialized.DistinctConversationSkillUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
