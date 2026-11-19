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
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunCreated)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunStatusRunning)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunStatusIdle)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunStatusEnded)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunError)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunPhaseStarted)]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunPhaseEnded)]
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
    [InlineData(BetaManagedAgentsSessionEventType.UserMessage, 0, "user.message")]
    [InlineData(BetaManagedAgentsSessionEventType.UserInterrupt, 1, "user.interrupt")]
    [InlineData(
        BetaManagedAgentsSessionEventType.UserToolConfirmation,
        2,
        "user.tool_confirmation"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.UserCustomToolResult,
        3,
        "user.custom_tool_result"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.AgentCustomToolUse, 4, "agent.custom_tool_use")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMessage, 5, "agent.message")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentThinking, 6, "agent.thinking")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolUse, 7, "agent.mcp_tool_use")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentMcpToolResult, 8, "agent.mcp_tool_result")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolUse, 9, "agent.tool_use")]
    [InlineData(BetaManagedAgentsSessionEventType.AgentToolResult, 10, "agent.tool_result")]
    [InlineData(
        BetaManagedAgentsSessionEventType.AgentThreadMessageReceived,
        11,
        "agent.thread_message_received"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.AgentThreadMessageSent,
        12,
        "agent.thread_message_sent"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.AgentThreadContextCompacted,
        13,
        "agent.thread_context_compacted"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.SessionError, 14, "session.error")]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionStatusRescheduled,
        15,
        "session.status_rescheduled"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionStatusRunning,
        16,
        "session.status_running"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.SessionStatusIdle, 17, "session.status_idle")]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionStatusTerminated,
        18,
        "session.status_terminated"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionThreadCreated,
        19,
        "session.thread_created"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationStart,
        20,
        "span.outcome_evaluation_start"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationEnd,
        21,
        "span.outcome_evaluation_end"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SpanModelRequestStart,
        22,
        "span.model_request_start"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SpanModelRequestEnd,
        23,
        "span.model_request_end"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationOngoing,
        24,
        "span.outcome_evaluation_ongoing"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.UserDefineOutcome, 25, "user.define_outcome")]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionThreadStatusRunning,
        26,
        "session.thread_status_running"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionThreadStatusIdle,
        27,
        "session.thread_status_idle"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionThreadStatusTerminated,
        28,
        "session.thread_status_terminated"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.UserToolResult, 29, "user.tool_result")]
    [InlineData(
        BetaManagedAgentsSessionEventType.SessionThreadStatusRescheduled,
        30,
        "session.thread_status_rescheduled"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUpdated, 31, "session.updated")]
    [InlineData(BetaManagedAgentsSessionEventType.SystemMessage, 32, "system.message")]
    [InlineData(BetaManagedAgentsSessionEventType.SessionUsage, 33, "session.usage")]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunCreated, 34, "workflow_run.created")]
    [InlineData(
        BetaManagedAgentsSessionEventType.WorkflowRunStatusRunning,
        35,
        "workflow_run.status_running"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.WorkflowRunStatusIdle,
        36,
        "workflow_run.status_idle"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.WorkflowRunStatusEnded,
        37,
        "workflow_run.status_ended"
    )]
    [InlineData(BetaManagedAgentsSessionEventType.WorkflowRunError, 38, "workflow_run.error")]
    [InlineData(
        BetaManagedAgentsSessionEventType.WorkflowRunPhaseStarted,
        39,
        "workflow_run.phase_started"
    )]
    [InlineData(
        BetaManagedAgentsSessionEventType.WorkflowRunPhaseEnded,
        40,
        "workflow_run.phase_ended"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaManagedAgentsSessionEventType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionEventType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionEventType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
