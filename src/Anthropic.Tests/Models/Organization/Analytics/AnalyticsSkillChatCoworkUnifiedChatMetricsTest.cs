using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsSkillChatCoworkUnifiedChatMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedChatMetrics
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
        var model = new AnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillChatCoworkUnifiedChatMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillChatCoworkUnifiedChatMetrics>(
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
        var model = new AnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedChatMetrics
        {
            DistinctConversationSkillUsedCount = 0,
        };

        AnalyticsSkillChatCoworkUnifiedChatMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
