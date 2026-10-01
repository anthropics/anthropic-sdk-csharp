using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionEventType.UserMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.UserInterrupt)]
    [InlineData(BetaManagedAgentsSessionEventType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsSessionEventType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThinking)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionError)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsSessionEventType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventType.UserToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUpdated)]
    [InlineData(BetaManagedAgentsSessionEventType.SystemMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUsage)]
    public void Validation_Works(BetaManagedAgentsSessionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionEventType.UserMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.UserInterrupt)]
    [InlineData(BetaManagedAgentsSessionEventType.UserToolConfirmation)]
    [InlineData(BetaManagedAgentsSessionEventType.UserCustomToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentCustomToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThinking)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolUse)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadMessageReceived)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadMessageSent)]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThreadContextCompacted)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionError)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadCreated)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationStart)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationEnd)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanModelRequestStart)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanModelRequestEnd)]
    [InlineData(BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationOngoing)]
    [InlineData(BetaManagedAgentsSessionEventType.UserDefineOutcome)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusTerminated)]
    [InlineData(BetaManagedAgentsSessionEventType.UserToolResult)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionThreadStatusRescheduled)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUpdated)]
    [InlineData(BetaManagedAgentsSessionEventType.SystemMessage)]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUsage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
