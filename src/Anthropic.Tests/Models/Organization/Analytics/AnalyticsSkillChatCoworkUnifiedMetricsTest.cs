using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsSkillChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        AnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        AnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillChatCoworkUnifiedMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsSkillChatCoworkUnifiedMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        AnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsSkillChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        AnalyticsSkillChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
