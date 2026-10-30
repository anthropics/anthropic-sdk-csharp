using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsConnectorChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        AnalyticsConnectorChatCoworkUnifiedChatMetrics expectedChat = new(0);
        AnalyticsConnectorChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsConnectorChatCoworkUnifiedMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsConnectorChatCoworkUnifiedMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AnalyticsConnectorChatCoworkUnifiedChatMetrics expectedChat = new(0);
        AnalyticsConnectorChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsConnectorChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        AnalyticsConnectorChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
