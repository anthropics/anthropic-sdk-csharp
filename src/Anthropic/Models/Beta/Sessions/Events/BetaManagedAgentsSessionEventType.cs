using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The `type` of a session event.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionEventTypeConverter))]
public enum BetaManagedAgentsSessionEventType
{
    UserMessage,
    UserInterrupt,
    UserToolConfirmation,
    UserCustomToolResult,
    AgentCustomToolUse,
    AgentMessage,
    AgentThinking,
    AgentMcpToolUse,
    AgentMcpToolResult,
    AgentToolUse,
    AgentToolResult,
    AgentThreadMessageReceived,
    AgentThreadMessageSent,
    AgentThreadContextCompacted,
    SessionError,
    SessionStatusRescheduled,
    SessionStatusRunning,
    SessionStatusIdle,
    SessionStatusTerminated,
    SessionThreadCreated,
    SpanOutcomeEvaluationStart,
    SpanOutcomeEvaluationEnd,
    SpanModelRequestStart,
    SpanModelRequestEnd,
    SpanOutcomeEvaluationOngoing,
    UserDefineOutcome,
    SessionThreadStatusRunning,
    SessionThreadStatusIdle,
    SessionThreadStatusTerminated,
    UserToolResult,
    SessionThreadStatusRescheduled,
    SessionUpdated,
    SystemMessage,
    SessionUsage,
    WorkflowRunCreated,
    WorkflowRunStatusRunning,
    WorkflowRunStatusIdle,
    WorkflowRunStatusEnded,
    WorkflowRunError,
    WorkflowRunPhaseStarted,
    WorkflowRunPhaseEnded,
}

sealed class BetaManagedAgentsSessionEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionEventType>
{
    public override BetaManagedAgentsSessionEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.message" => BetaManagedAgentsSessionEventType.UserMessage,
            "user.interrupt" => BetaManagedAgentsSessionEventType.UserInterrupt,
            "user.tool_confirmation" => BetaManagedAgentsSessionEventType.UserToolConfirmation,
            "user.custom_tool_result" => BetaManagedAgentsSessionEventType.UserCustomToolResult,
            "agent.custom_tool_use" => BetaManagedAgentsSessionEventType.AgentCustomToolUse,
            "agent.message" => BetaManagedAgentsSessionEventType.AgentMessage,
            "agent.thinking" => BetaManagedAgentsSessionEventType.AgentThinking,
            "agent.mcp_tool_use" => BetaManagedAgentsSessionEventType.AgentMcpToolUse,
            "agent.mcp_tool_result" => BetaManagedAgentsSessionEventType.AgentMcpToolResult,
            "agent.tool_use" => BetaManagedAgentsSessionEventType.AgentToolUse,
            "agent.tool_result" => BetaManagedAgentsSessionEventType.AgentToolResult,
            "agent.thread_message_received" =>
                BetaManagedAgentsSessionEventType.AgentThreadMessageReceived,
            "agent.thread_message_sent" => BetaManagedAgentsSessionEventType.AgentThreadMessageSent,
            "agent.thread_context_compacted" =>
                BetaManagedAgentsSessionEventType.AgentThreadContextCompacted,
            "session.error" => BetaManagedAgentsSessionEventType.SessionError,
            "session.status_rescheduled" =>
                BetaManagedAgentsSessionEventType.SessionStatusRescheduled,
            "session.status_running" => BetaManagedAgentsSessionEventType.SessionStatusRunning,
            "session.status_idle" => BetaManagedAgentsSessionEventType.SessionStatusIdle,
            "session.status_terminated" =>
                BetaManagedAgentsSessionEventType.SessionStatusTerminated,
            "session.thread_created" => BetaManagedAgentsSessionEventType.SessionThreadCreated,
            "span.outcome_evaluation_start" =>
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationStart,
            "span.outcome_evaluation_end" =>
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationEnd,
            "span.model_request_start" => BetaManagedAgentsSessionEventType.SpanModelRequestStart,
            "span.model_request_end" => BetaManagedAgentsSessionEventType.SpanModelRequestEnd,
            "span.outcome_evaluation_ongoing" =>
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationOngoing,
            "user.define_outcome" => BetaManagedAgentsSessionEventType.UserDefineOutcome,
            "session.thread_status_running" =>
                BetaManagedAgentsSessionEventType.SessionThreadStatusRunning,
            "session.thread_status_idle" =>
                BetaManagedAgentsSessionEventType.SessionThreadStatusIdle,
            "session.thread_status_terminated" =>
                BetaManagedAgentsSessionEventType.SessionThreadStatusTerminated,
            "user.tool_result" => BetaManagedAgentsSessionEventType.UserToolResult,
            "session.thread_status_rescheduled" =>
                BetaManagedAgentsSessionEventType.SessionThreadStatusRescheduled,
            "session.updated" => BetaManagedAgentsSessionEventType.SessionUpdated,
            "system.message" => BetaManagedAgentsSessionEventType.SystemMessage,
            "session.usage" => BetaManagedAgentsSessionEventType.SessionUsage,
            "workflow_run.created" => BetaManagedAgentsSessionEventType.WorkflowRunCreated,
            "workflow_run.status_running" =>
                BetaManagedAgentsSessionEventType.WorkflowRunStatusRunning,
            "workflow_run.status_idle" => BetaManagedAgentsSessionEventType.WorkflowRunStatusIdle,
            "workflow_run.status_ended" => BetaManagedAgentsSessionEventType.WorkflowRunStatusEnded,
            "workflow_run.error" => BetaManagedAgentsSessionEventType.WorkflowRunError,
            "workflow_run.phase_started" =>
                BetaManagedAgentsSessionEventType.WorkflowRunPhaseStarted,
            "workflow_run.phase_ended" => BetaManagedAgentsSessionEventType.WorkflowRunPhaseEnded,
            _ => (BetaManagedAgentsSessionEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionEventType.UserMessage => "user.message",
                BetaManagedAgentsSessionEventType.UserInterrupt => "user.interrupt",
                BetaManagedAgentsSessionEventType.UserToolConfirmation => "user.tool_confirmation",
                BetaManagedAgentsSessionEventType.UserCustomToolResult => "user.custom_tool_result",
                BetaManagedAgentsSessionEventType.AgentCustomToolUse => "agent.custom_tool_use",
                BetaManagedAgentsSessionEventType.AgentMessage => "agent.message",
                BetaManagedAgentsSessionEventType.AgentThinking => "agent.thinking",
                BetaManagedAgentsSessionEventType.AgentMcpToolUse => "agent.mcp_tool_use",
                BetaManagedAgentsSessionEventType.AgentMcpToolResult => "agent.mcp_tool_result",
                BetaManagedAgentsSessionEventType.AgentToolUse => "agent.tool_use",
                BetaManagedAgentsSessionEventType.AgentToolResult => "agent.tool_result",
                BetaManagedAgentsSessionEventType.AgentThreadMessageReceived =>
                    "agent.thread_message_received",
                BetaManagedAgentsSessionEventType.AgentThreadMessageSent =>
                    "agent.thread_message_sent",
                BetaManagedAgentsSessionEventType.AgentThreadContextCompacted =>
                    "agent.thread_context_compacted",
                BetaManagedAgentsSessionEventType.SessionError => "session.error",
                BetaManagedAgentsSessionEventType.SessionStatusRescheduled =>
                    "session.status_rescheduled",
                BetaManagedAgentsSessionEventType.SessionStatusRunning => "session.status_running",
                BetaManagedAgentsSessionEventType.SessionStatusIdle => "session.status_idle",
                BetaManagedAgentsSessionEventType.SessionStatusTerminated =>
                    "session.status_terminated",
                BetaManagedAgentsSessionEventType.SessionThreadCreated => "session.thread_created",
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationStart =>
                    "span.outcome_evaluation_start",
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationEnd =>
                    "span.outcome_evaluation_end",
                BetaManagedAgentsSessionEventType.SpanModelRequestStart =>
                    "span.model_request_start",
                BetaManagedAgentsSessionEventType.SpanModelRequestEnd => "span.model_request_end",
                BetaManagedAgentsSessionEventType.SpanOutcomeEvaluationOngoing =>
                    "span.outcome_evaluation_ongoing",
                BetaManagedAgentsSessionEventType.UserDefineOutcome => "user.define_outcome",
                BetaManagedAgentsSessionEventType.SessionThreadStatusRunning =>
                    "session.thread_status_running",
                BetaManagedAgentsSessionEventType.SessionThreadStatusIdle =>
                    "session.thread_status_idle",
                BetaManagedAgentsSessionEventType.SessionThreadStatusTerminated =>
                    "session.thread_status_terminated",
                BetaManagedAgentsSessionEventType.UserToolResult => "user.tool_result",
                BetaManagedAgentsSessionEventType.SessionThreadStatusRescheduled =>
                    "session.thread_status_rescheduled",
                BetaManagedAgentsSessionEventType.SessionUpdated => "session.updated",
                BetaManagedAgentsSessionEventType.SystemMessage => "system.message",
                BetaManagedAgentsSessionEventType.SessionUsage => "session.usage",
                BetaManagedAgentsSessionEventType.WorkflowRunCreated => "workflow_run.created",
                BetaManagedAgentsSessionEventType.WorkflowRunStatusRunning =>
                    "workflow_run.status_running",
                BetaManagedAgentsSessionEventType.WorkflowRunStatusIdle =>
                    "workflow_run.status_idle",
                BetaManagedAgentsSessionEventType.WorkflowRunStatusEnded =>
                    "workflow_run.status_ended",
                BetaManagedAgentsSessionEventType.WorkflowRunError => "workflow_run.error",
                BetaManagedAgentsSessionEventType.WorkflowRunPhaseStarted =>
                    "workflow_run.phase_started",
                BetaManagedAgentsSessionEventType.WorkflowRunPhaseEnded =>
                    "workflow_run.phase_ended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
