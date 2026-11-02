using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsSkillChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSkillChatCoworkUnifiedMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsSkillChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
