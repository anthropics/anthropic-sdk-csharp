using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsConnectorChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsConnectorChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsConnectorChatCoworkUnifiedMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsConnectorChatCoworkUnifiedMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsConnectorChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsConnectorChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
