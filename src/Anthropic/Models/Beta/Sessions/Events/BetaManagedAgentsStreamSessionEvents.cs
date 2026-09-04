using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Server-sent event in the session stream.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsStreamSessionEventsConverter))]
public record class BetaManagedAgentsStreamSessionEvents : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ID
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent x => x.ID,
                BetaManagedAgentsUserInterruptEvent x => x.ID,
                BetaManagedAgentsUserToolConfirmationEvent x => x.ID,
                BetaManagedAgentsUserCustomToolResultEvent x => x.ID,
                BetaManagedAgentsAgentCustomToolUseEvent x => x.ID,
                BetaManagedAgentsAgentMessageEvent x => x.ID,
                BetaManagedAgentsAgentThinkingEvent x => x.ID,
                BetaManagedAgentsAgentMcpToolUseEvent x => x.ID,
                BetaManagedAgentsAgentMcpToolResultEvent x => x.ID,
                BetaManagedAgentsAgentToolUseEvent x => x.ID,
                BetaManagedAgentsAgentToolResultEvent x => x.ID,
                BetaManagedAgentsAgentThreadMessageReceivedEvent x => x.ID,
                BetaManagedAgentsAgentThreadMessageSentEvent x => x.ID,
                BetaManagedAgentsAgentThreadContextCompactedEvent x => x.ID,
                BetaManagedAgentsSessionErrorEvent x => x.ID,
                BetaManagedAgentsSessionStatusRescheduledEvent x => x.ID,
                BetaManagedAgentsSessionStatusRunningEvent x => x.ID,
                BetaManagedAgentsSessionStatusIdleEvent x => x.ID,
                BetaManagedAgentsSessionStatusTerminatedEvent x => x.ID,
                BetaManagedAgentsSessionThreadCreatedEvent x => x.ID,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent x => x.ID,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent x => x.ID,
                BetaManagedAgentsSpanModelRequestStartEvent x => x.ID,
                BetaManagedAgentsSpanModelRequestEndEvent x => x.ID,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent x => x.ID,
                BetaManagedAgentsUserDefineOutcomeEvent x => x.ID,
                BetaManagedAgentsSessionDeletedEvent x => x.ID,
                BetaManagedAgentsSessionThreadStatusRunningEvent x => x.ID,
                BetaManagedAgentsSessionThreadStatusIdleEvent x => x.ID,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent x => x.ID,
                BetaManagedAgentsUserToolResultEvent x => x.ID,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent x => x.ID,
                BetaManagedAgentsSessionUpdatedEvent x => x.ID,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent x => x.ID,
                BetaManagedAgentsSessionUsageEvent x => x.ID,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent x => x.ProcessedAt,
                BetaManagedAgentsUserInterruptEvent x => x.ProcessedAt,
                BetaManagedAgentsUserToolConfirmationEvent x => x.ProcessedAt,
                BetaManagedAgentsUserCustomToolResultEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentCustomToolUseEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentMessageEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentThinkingEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentMcpToolUseEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentMcpToolResultEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentToolUseEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentToolResultEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentThreadMessageReceivedEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentThreadMessageSentEvent x => x.ProcessedAt,
                BetaManagedAgentsAgentThreadContextCompactedEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionErrorEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionStatusRescheduledEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionStatusRunningEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionStatusIdleEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionStatusTerminatedEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionThreadCreatedEvent x => x.ProcessedAt,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent x => x.ProcessedAt,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent x => x.ProcessedAt,
                BetaManagedAgentsSpanModelRequestStartEvent x => x.ProcessedAt,
                BetaManagedAgentsSpanModelRequestEndEvent x => x.ProcessedAt,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent x => x.ProcessedAt,
                BetaManagedAgentsUserDefineOutcomeEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionDeletedEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionThreadStatusRunningEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionThreadStatusIdleEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent x => x.ProcessedAt,
                BetaManagedAgentsUserToolResultEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionUpdatedEvent x => x.ProcessedAt,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent x => x.ProcessedAt,
                BetaManagedAgentsSessionUsageEvent x => x.ProcessedAt,
                _ => WrappedJsonSerializer.GetNullableStructProperty<System::DateTimeOffset>(
                    this.Json,
                    "processed_at"
                ),
            };
        }
    }

    public string? SessionThreadID
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent x => x.SessionThreadID,
                BetaManagedAgentsUserToolConfirmationEvent x => x.SessionThreadID,
                BetaManagedAgentsUserCustomToolResultEvent x => x.SessionThreadID,
                BetaManagedAgentsAgentCustomToolUseEvent x => x.SessionThreadID,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent x => x.SessionThreadID,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent x => x.SessionThreadID,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent x => x.SessionThreadID,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent x => x.SessionThreadID,
                BetaManagedAgentsSessionThreadStatusIdleEvent x => x.SessionThreadID,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent x => x.SessionThreadID,
                BetaManagedAgentsUserToolResultEvent x => x.SessionThreadID,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent x => x.SessionThreadID,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "session_thread_id"
                ),
            };
        }
    }

    public string? ToolUseID
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent x => x.ToolUseID,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent x => x.ToolUseID,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent x => x.ToolUseID,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "tool_use_id"
                ),
            };
        }
    }

    public bool? IsError
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent x => x.IsError,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent x => x.IsError,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent x => x.IsError,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent x => x.IsError,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent x => x.IsError,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<bool>(this.Json, "is_error"),
            };
        }
    }

    public string? Name
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent x => x.Name,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent x => x.Name,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent x => x.Name,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "name"),
            };
        }
    }

    public string? AgentName
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent x => x.AgentName,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent x => x.AgentName,
                BetaManagedAgentsSessionThreadStatusIdleEvent x => x.AgentName,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent x => x.AgentName,
                BetaManagedAgentsUserToolResultEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent x => x.AgentName,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "agent_name"
                ),
            };
        }
    }

    public int? Iteration
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent x => x.Iteration,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent x => x.Iteration,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent x => x.Iteration,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<int>(this.Json, "iteration"),
            };
        }
    }

    public string? OutcomeID
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent x => x.OutcomeID,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent x => x.OutcomeID,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent x => x.OutcomeID,
                BetaManagedAgentsUserDefineOutcomeEvent x => x.OutcomeID,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent _ => null,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "outcome_id"
                ),
            };
        }
    }

    public BetaManagedAgentsBudgetLimit? Budget
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsUserMessageEvent _ => null,
                BetaManagedAgentsUserInterruptEvent _ => null,
                BetaManagedAgentsUserToolConfirmationEvent _ => null,
                BetaManagedAgentsUserCustomToolResultEvent _ => null,
                BetaManagedAgentsAgentCustomToolUseEvent _ => null,
                BetaManagedAgentsAgentMessageEvent _ => null,
                BetaManagedAgentsAgentThinkingEvent _ => null,
                BetaManagedAgentsAgentMcpToolUseEvent _ => null,
                BetaManagedAgentsAgentMcpToolResultEvent _ => null,
                BetaManagedAgentsAgentToolUseEvent _ => null,
                BetaManagedAgentsAgentToolResultEvent _ => null,
                BetaManagedAgentsAgentThreadMessageReceivedEvent _ => null,
                BetaManagedAgentsAgentThreadMessageSentEvent _ => null,
                BetaManagedAgentsAgentThreadContextCompactedEvent _ => null,
                BetaManagedAgentsSessionErrorEvent _ => null,
                BetaManagedAgentsSessionStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionStatusRunningEvent _ => null,
                BetaManagedAgentsSessionStatusIdleEvent _ => null,
                BetaManagedAgentsSessionStatusTerminatedEvent _ => null,
                BetaManagedAgentsSessionThreadCreatedEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => null,
                BetaManagedAgentsSpanModelRequestStartEvent _ => null,
                BetaManagedAgentsSpanModelRequestEndEvent _ => null,
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => null,
                BetaManagedAgentsUserDefineOutcomeEvent _ => null,
                BetaManagedAgentsSessionDeletedEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRunningEvent _ => null,
                BetaManagedAgentsSessionThreadStatusIdleEvent _ => null,
                BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => null,
                BetaManagedAgentsUserToolResultEvent _ => null,
                BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => null,
                BetaManagedAgentsSessionUpdatedEvent x => x.Budget,
                BetaManagedAgentsStartEvent _ => null,
                BetaManagedAgentsDeltaEvent _ => null,
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent x => x.Budget,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaManagedAgentsBudgetLimit>(
                    this.Json,
                    "budget"
                ),
            };
        }
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserInterruptEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserToolConfirmationEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserCustomToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentCustomToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThinkingEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMcpToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMcpToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadMessageReceivedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadMessageSentEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadContextCompactedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionErrorEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusRescheduledEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusRunningEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusIdleEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusTerminatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadCreatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanModelRequestStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanModelRequestEndEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserDefineOutcomeEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionDeletedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusRunningEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusIdleEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusTerminatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionUpdatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsDeltaEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSystemMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionUsageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsStreamSessionEvents(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserMessageEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserMessageEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserInterruptEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserInterruptEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserInterruptEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserInterruptEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserInterruptEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserInterruptEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserToolConfirmationEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserToolConfirmationEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolConfirmationEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserToolConfirmationEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserToolConfirmationEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserToolConfirmationEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserCustomToolResultEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserCustomToolResultEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserCustomToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserCustomToolResultEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserCustomToolResultEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserCustomToolResultEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentCustomToolUseEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentCustomToolUseEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentCustomToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentCustomToolUseEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentCustomToolUseEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentCustomToolUseEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentMessageEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMessageEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentThinkingEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentThinkingEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThinkingEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThinkingEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentThinkingEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentThinkingEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentMcpToolUseEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentMcpToolUseEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMcpToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMcpToolUseEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentMcpToolUseEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentMcpToolUseEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentMcpToolResultEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentMcpToolResultEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMcpToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMcpToolResultEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentMcpToolResultEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentMcpToolResultEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolUseEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentToolUseEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentToolUseEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolUseEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolUseEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentToolResultEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentToolResultEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentToolResultEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentToolResultEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentToolResultEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentThreadMessageReceivedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentThreadMessageReceivedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadMessageReceivedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadMessageReceivedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentThreadMessageReceivedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentThreadMessageReceivedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentThreadMessageSentEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentThreadMessageSentEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadMessageSentEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadMessageSentEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentThreadMessageSentEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentThreadMessageSentEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentThreadContextCompactedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAgentThreadContextCompactedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadContextCompactedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadContextCompactedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsAgentThreadContextCompactedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentThreadContextCompactedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionErrorEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionErrorEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionErrorEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionStatusRescheduledEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusRescheduledEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusRescheduledEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusRescheduledEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionStatusRescheduledEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionStatusRescheduledEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionStatusRunningEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusRunningEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusRunningEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusRunningEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionStatusRunningEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionStatusRunningEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionStatusIdleEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusIdleEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusIdleEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusIdleEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionStatusIdleEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionStatusIdleEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionStatusTerminatedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionStatusTerminatedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusTerminatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionStatusTerminatedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionStatusTerminatedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionStatusTerminatedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadCreatedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadCreatedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadCreatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadCreatedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadCreatedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadCreatedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSpanOutcomeEvaluationStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpanOutcomeEvaluationStartEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationStartEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSpanOutcomeEvaluationStartEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSpanOutcomeEvaluationStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSpanOutcomeEvaluationEndEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpanOutcomeEvaluationEndEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationEndEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationEndEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSpanOutcomeEvaluationEndEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSpanOutcomeEvaluationEndEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSpanModelRequestStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpanModelRequestStartEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanModelRequestStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanModelRequestStartEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSpanModelRequestStartEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSpanModelRequestStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSpanModelRequestEndEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpanModelRequestEndEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanModelRequestEndEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanModelRequestEndEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSpanModelRequestEndEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSpanModelRequestEndEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSpanOutcomeEvaluationOngoingEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationOngoingEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserDefineOutcomeEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserDefineOutcomeEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserDefineOutcomeEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserDefineOutcomeEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserDefineOutcomeEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserDefineOutcomeEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionDeletedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionDeletedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionDeletedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionDeletedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionDeletedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionDeletedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadStatusRunningEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadStatusRunningEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusRunningEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadStatusRunningEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadStatusRunningEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadStatusRunningEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadStatusIdleEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadStatusIdleEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusIdleEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadStatusIdleEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadStatusIdleEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadStatusIdleEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadStatusTerminatedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadStatusTerminatedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusTerminatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadStatusTerminatedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadStatusTerminatedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadStatusTerminatedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserToolResultEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserToolResultEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserToolResultEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserToolResultEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserToolResultEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionThreadStatusRescheduledEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionThreadStatusRescheduledEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusRescheduledEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionThreadStatusRescheduledEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionThreadStatusRescheduledEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionThreadStatusRescheduledEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionUpdatedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionUpdatedEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionUpdatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionUpdatedEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionUpdatedEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionUpdatedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStartEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStartEvent([NotNullWhen(true)] out BetaManagedAgentsStartEvent? value)
    {
        value = this.Value as BetaManagedAgentsStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsDeltaEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDeltaEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsDeltaEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDeltaEvent([NotNullWhen(true)] out BetaManagedAgentsDeltaEvent? value)
    {
        value = this.Value as BetaManagedAgentsDeltaEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSystemMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystemMessageEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSystemMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystemMessageEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSystemMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSystemMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionUsageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSessionUsageEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionUsageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSessionUsageEvent(
        [NotNullWhen(true)] out BetaManagedAgentsSessionUsageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionUsageEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaManagedAgentsUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentCustomToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThinkingEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMcpToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMcpToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadMessageReceivedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadMessageSentEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadContextCompactedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionErrorEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusRescheduledEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusRunningEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusIdleEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusTerminatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadCreatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationEndEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanModelRequestStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanModelRequestEndEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserDefineOutcomeEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionDeletedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusRunningEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusIdleEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusTerminatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusRescheduledEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUpdatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeltaEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSystemMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUsageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUserMessageEvent> userMessageEvent,
        System::Action<BetaManagedAgentsUserInterruptEvent> userInterruptEvent,
        System::Action<BetaManagedAgentsUserToolConfirmationEvent> userToolConfirmationEvent,
        System::Action<BetaManagedAgentsUserCustomToolResultEvent> userCustomToolResultEvent,
        System::Action<BetaManagedAgentsAgentCustomToolUseEvent> agentCustomToolUseEvent,
        System::Action<BetaManagedAgentsAgentMessageEvent> agentMessageEvent,
        System::Action<BetaManagedAgentsAgentThinkingEvent> agentThinkingEvent,
        System::Action<BetaManagedAgentsAgentMcpToolUseEvent> agentMcpToolUseEvent,
        System::Action<BetaManagedAgentsAgentMcpToolResultEvent> agentMcpToolResultEvent,
        System::Action<BetaManagedAgentsAgentToolUseEvent> agentToolUseEvent,
        System::Action<BetaManagedAgentsAgentToolResultEvent> agentToolResultEvent,
        System::Action<BetaManagedAgentsAgentThreadMessageReceivedEvent> agentThreadMessageReceivedEvent,
        System::Action<BetaManagedAgentsAgentThreadMessageSentEvent> agentThreadMessageSentEvent,
        System::Action<BetaManagedAgentsAgentThreadContextCompactedEvent> agentThreadContextCompactedEvent,
        System::Action<BetaManagedAgentsSessionErrorEvent> sessionErrorEvent,
        System::Action<BetaManagedAgentsSessionStatusRescheduledEvent> sessionStatusRescheduledEvent,
        System::Action<BetaManagedAgentsSessionStatusRunningEvent> sessionStatusRunningEvent,
        System::Action<BetaManagedAgentsSessionStatusIdleEvent> sessionStatusIdleEvent,
        System::Action<BetaManagedAgentsSessionStatusTerminatedEvent> sessionStatusTerminatedEvent,
        System::Action<BetaManagedAgentsSessionThreadCreatedEvent> sessionThreadCreatedEvent,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationStartEvent> spanOutcomeEvaluationStartEvent,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationEndEvent> spanOutcomeEvaluationEndEvent,
        System::Action<BetaManagedAgentsSpanModelRequestStartEvent> spanModelRequestStartEvent,
        System::Action<BetaManagedAgentsSpanModelRequestEndEvent> spanModelRequestEndEvent,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent> spanOutcomeEvaluationOngoingEvent,
        System::Action<BetaManagedAgentsUserDefineOutcomeEvent> userDefineOutcomeEvent,
        System::Action<BetaManagedAgentsSessionDeletedEvent> sessionDeletedEvent,
        System::Action<BetaManagedAgentsSessionThreadStatusRunningEvent> sessionThreadStatusRunningEvent,
        System::Action<BetaManagedAgentsSessionThreadStatusIdleEvent> sessionThreadStatusIdleEvent,
        System::Action<BetaManagedAgentsSessionThreadStatusTerminatedEvent> sessionThreadStatusTerminatedEvent,
        System::Action<BetaManagedAgentsUserToolResultEvent> userToolResultEvent,
        System::Action<BetaManagedAgentsSessionThreadStatusRescheduledEvent> sessionThreadStatusRescheduledEvent,
        System::Action<BetaManagedAgentsSessionUpdatedEvent> sessionUpdatedEvent,
        System::Action<BetaManagedAgentsStartEvent> startEvent,
        System::Action<BetaManagedAgentsDeltaEvent> deltaEvent,
        System::Action<BetaManagedAgentsSystemMessageEvent> systemMessageEvent,
        System::Action<BetaManagedAgentsSessionUsageEvent> sessionUsageEvent
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUserMessageEvent value:
                userMessageEvent(value);
                break;
            case BetaManagedAgentsUserInterruptEvent value:
                userInterruptEvent(value);
                break;
            case BetaManagedAgentsUserToolConfirmationEvent value:
                userToolConfirmationEvent(value);
                break;
            case BetaManagedAgentsUserCustomToolResultEvent value:
                userCustomToolResultEvent(value);
                break;
            case BetaManagedAgentsAgentCustomToolUseEvent value:
                agentCustomToolUseEvent(value);
                break;
            case BetaManagedAgentsAgentMessageEvent value:
                agentMessageEvent(value);
                break;
            case BetaManagedAgentsAgentThinkingEvent value:
                agentThinkingEvent(value);
                break;
            case BetaManagedAgentsAgentMcpToolUseEvent value:
                agentMcpToolUseEvent(value);
                break;
            case BetaManagedAgentsAgentMcpToolResultEvent value:
                agentMcpToolResultEvent(value);
                break;
            case BetaManagedAgentsAgentToolUseEvent value:
                agentToolUseEvent(value);
                break;
            case BetaManagedAgentsAgentToolResultEvent value:
                agentToolResultEvent(value);
                break;
            case BetaManagedAgentsAgentThreadMessageReceivedEvent value:
                agentThreadMessageReceivedEvent(value);
                break;
            case BetaManagedAgentsAgentThreadMessageSentEvent value:
                agentThreadMessageSentEvent(value);
                break;
            case BetaManagedAgentsAgentThreadContextCompactedEvent value:
                agentThreadContextCompactedEvent(value);
                break;
            case BetaManagedAgentsSessionErrorEvent value:
                sessionErrorEvent(value);
                break;
            case BetaManagedAgentsSessionStatusRescheduledEvent value:
                sessionStatusRescheduledEvent(value);
                break;
            case BetaManagedAgentsSessionStatusRunningEvent value:
                sessionStatusRunningEvent(value);
                break;
            case BetaManagedAgentsSessionStatusIdleEvent value:
                sessionStatusIdleEvent(value);
                break;
            case BetaManagedAgentsSessionStatusTerminatedEvent value:
                sessionStatusTerminatedEvent(value);
                break;
            case BetaManagedAgentsSessionThreadCreatedEvent value:
                sessionThreadCreatedEvent(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationStartEvent value:
                spanOutcomeEvaluationStartEvent(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationEndEvent value:
                spanOutcomeEvaluationEndEvent(value);
                break;
            case BetaManagedAgentsSpanModelRequestStartEvent value:
                spanModelRequestStartEvent(value);
                break;
            case BetaManagedAgentsSpanModelRequestEndEvent value:
                spanModelRequestEndEvent(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value:
                spanOutcomeEvaluationOngoingEvent(value);
                break;
            case BetaManagedAgentsUserDefineOutcomeEvent value:
                userDefineOutcomeEvent(value);
                break;
            case BetaManagedAgentsSessionDeletedEvent value:
                sessionDeletedEvent(value);
                break;
            case BetaManagedAgentsSessionThreadStatusRunningEvent value:
                sessionThreadStatusRunningEvent(value);
                break;
            case BetaManagedAgentsSessionThreadStatusIdleEvent value:
                sessionThreadStatusIdleEvent(value);
                break;
            case BetaManagedAgentsSessionThreadStatusTerminatedEvent value:
                sessionThreadStatusTerminatedEvent(value);
                break;
            case BetaManagedAgentsUserToolResultEvent value:
                userToolResultEvent(value);
                break;
            case BetaManagedAgentsSessionThreadStatusRescheduledEvent value:
                sessionThreadStatusRescheduledEvent(value);
                break;
            case BetaManagedAgentsSessionUpdatedEvent value:
                sessionUpdatedEvent(value);
                break;
            case BetaManagedAgentsStartEvent value:
                startEvent(value);
                break;
            case BetaManagedAgentsDeltaEvent value:
                deltaEvent(value);
                break;
            case BetaManagedAgentsSystemMessageEvent value:
                systemMessageEvent(value);
                break;
            case BetaManagedAgentsSessionUsageEvent value:
                sessionUsageEvent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsStreamSessionEvents"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaManagedAgentsUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentCustomToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThinkingEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMcpToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentMcpToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolUseEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadMessageReceivedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadMessageSentEvent value) =&gt; {...},
    ///     (BetaManagedAgentsAgentThreadContextCompactedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionErrorEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusRescheduledEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusRunningEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusIdleEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionStatusTerminatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadCreatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationEndEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanModelRequestStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanModelRequestEndEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserDefineOutcomeEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionDeletedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusRunningEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusIdleEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusTerminatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolResultEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionThreadStatusRescheduledEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUpdatedEvent value) =&gt; {...},
    ///     (BetaManagedAgentsStartEvent value) =&gt; {...},
    ///     (BetaManagedAgentsDeltaEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSystemMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUsageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUserMessageEvent, T> userMessageEvent,
        System::Func<BetaManagedAgentsUserInterruptEvent, T> userInterruptEvent,
        System::Func<BetaManagedAgentsUserToolConfirmationEvent, T> userToolConfirmationEvent,
        System::Func<BetaManagedAgentsUserCustomToolResultEvent, T> userCustomToolResultEvent,
        System::Func<BetaManagedAgentsAgentCustomToolUseEvent, T> agentCustomToolUseEvent,
        System::Func<BetaManagedAgentsAgentMessageEvent, T> agentMessageEvent,
        System::Func<BetaManagedAgentsAgentThinkingEvent, T> agentThinkingEvent,
        System::Func<BetaManagedAgentsAgentMcpToolUseEvent, T> agentMcpToolUseEvent,
        System::Func<BetaManagedAgentsAgentMcpToolResultEvent, T> agentMcpToolResultEvent,
        System::Func<BetaManagedAgentsAgentToolUseEvent, T> agentToolUseEvent,
        System::Func<BetaManagedAgentsAgentToolResultEvent, T> agentToolResultEvent,
        System::Func<
            BetaManagedAgentsAgentThreadMessageReceivedEvent,
            T
        > agentThreadMessageReceivedEvent,
        System::Func<BetaManagedAgentsAgentThreadMessageSentEvent, T> agentThreadMessageSentEvent,
        System::Func<
            BetaManagedAgentsAgentThreadContextCompactedEvent,
            T
        > agentThreadContextCompactedEvent,
        System::Func<BetaManagedAgentsSessionErrorEvent, T> sessionErrorEvent,
        System::Func<
            BetaManagedAgentsSessionStatusRescheduledEvent,
            T
        > sessionStatusRescheduledEvent,
        System::Func<BetaManagedAgentsSessionStatusRunningEvent, T> sessionStatusRunningEvent,
        System::Func<BetaManagedAgentsSessionStatusIdleEvent, T> sessionStatusIdleEvent,
        System::Func<BetaManagedAgentsSessionStatusTerminatedEvent, T> sessionStatusTerminatedEvent,
        System::Func<BetaManagedAgentsSessionThreadCreatedEvent, T> sessionThreadCreatedEvent,
        System::Func<
            BetaManagedAgentsSpanOutcomeEvaluationStartEvent,
            T
        > spanOutcomeEvaluationStartEvent,
        System::Func<
            BetaManagedAgentsSpanOutcomeEvaluationEndEvent,
            T
        > spanOutcomeEvaluationEndEvent,
        System::Func<BetaManagedAgentsSpanModelRequestStartEvent, T> spanModelRequestStartEvent,
        System::Func<BetaManagedAgentsSpanModelRequestEndEvent, T> spanModelRequestEndEvent,
        System::Func<
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent,
            T
        > spanOutcomeEvaluationOngoingEvent,
        System::Func<BetaManagedAgentsUserDefineOutcomeEvent, T> userDefineOutcomeEvent,
        System::Func<BetaManagedAgentsSessionDeletedEvent, T> sessionDeletedEvent,
        System::Func<
            BetaManagedAgentsSessionThreadStatusRunningEvent,
            T
        > sessionThreadStatusRunningEvent,
        System::Func<BetaManagedAgentsSessionThreadStatusIdleEvent, T> sessionThreadStatusIdleEvent,
        System::Func<
            BetaManagedAgentsSessionThreadStatusTerminatedEvent,
            T
        > sessionThreadStatusTerminatedEvent,
        System::Func<BetaManagedAgentsUserToolResultEvent, T> userToolResultEvent,
        System::Func<
            BetaManagedAgentsSessionThreadStatusRescheduledEvent,
            T
        > sessionThreadStatusRescheduledEvent,
        System::Func<BetaManagedAgentsSessionUpdatedEvent, T> sessionUpdatedEvent,
        System::Func<BetaManagedAgentsStartEvent, T> startEvent,
        System::Func<BetaManagedAgentsDeltaEvent, T> deltaEvent,
        System::Func<BetaManagedAgentsSystemMessageEvent, T> systemMessageEvent,
        System::Func<BetaManagedAgentsSessionUsageEvent, T> sessionUsageEvent
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEvent value => userMessageEvent(value),
            BetaManagedAgentsUserInterruptEvent value => userInterruptEvent(value),
            BetaManagedAgentsUserToolConfirmationEvent value => userToolConfirmationEvent(value),
            BetaManagedAgentsUserCustomToolResultEvent value => userCustomToolResultEvent(value),
            BetaManagedAgentsAgentCustomToolUseEvent value => agentCustomToolUseEvent(value),
            BetaManagedAgentsAgentMessageEvent value => agentMessageEvent(value),
            BetaManagedAgentsAgentThinkingEvent value => agentThinkingEvent(value),
            BetaManagedAgentsAgentMcpToolUseEvent value => agentMcpToolUseEvent(value),
            BetaManagedAgentsAgentMcpToolResultEvent value => agentMcpToolResultEvent(value),
            BetaManagedAgentsAgentToolUseEvent value => agentToolUseEvent(value),
            BetaManagedAgentsAgentToolResultEvent value => agentToolResultEvent(value),
            BetaManagedAgentsAgentThreadMessageReceivedEvent value =>
                agentThreadMessageReceivedEvent(value),
            BetaManagedAgentsAgentThreadMessageSentEvent value => agentThreadMessageSentEvent(
                value
            ),
            BetaManagedAgentsAgentThreadContextCompactedEvent value =>
                agentThreadContextCompactedEvent(value),
            BetaManagedAgentsSessionErrorEvent value => sessionErrorEvent(value),
            BetaManagedAgentsSessionStatusRescheduledEvent value => sessionStatusRescheduledEvent(
                value
            ),
            BetaManagedAgentsSessionStatusRunningEvent value => sessionStatusRunningEvent(value),
            BetaManagedAgentsSessionStatusIdleEvent value => sessionStatusIdleEvent(value),
            BetaManagedAgentsSessionStatusTerminatedEvent value => sessionStatusTerminatedEvent(
                value
            ),
            BetaManagedAgentsSessionThreadCreatedEvent value => sessionThreadCreatedEvent(value),
            BetaManagedAgentsSpanOutcomeEvaluationStartEvent value =>
                spanOutcomeEvaluationStartEvent(value),
            BetaManagedAgentsSpanOutcomeEvaluationEndEvent value => spanOutcomeEvaluationEndEvent(
                value
            ),
            BetaManagedAgentsSpanModelRequestStartEvent value => spanModelRequestStartEvent(value),
            BetaManagedAgentsSpanModelRequestEndEvent value => spanModelRequestEndEvent(value),
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value =>
                spanOutcomeEvaluationOngoingEvent(value),
            BetaManagedAgentsUserDefineOutcomeEvent value => userDefineOutcomeEvent(value),
            BetaManagedAgentsSessionDeletedEvent value => sessionDeletedEvent(value),
            BetaManagedAgentsSessionThreadStatusRunningEvent value =>
                sessionThreadStatusRunningEvent(value),
            BetaManagedAgentsSessionThreadStatusIdleEvent value => sessionThreadStatusIdleEvent(
                value
            ),
            BetaManagedAgentsSessionThreadStatusTerminatedEvent value =>
                sessionThreadStatusTerminatedEvent(value),
            BetaManagedAgentsUserToolResultEvent value => userToolResultEvent(value),
            BetaManagedAgentsSessionThreadStatusRescheduledEvent value =>
                sessionThreadStatusRescheduledEvent(value),
            BetaManagedAgentsSessionUpdatedEvent value => sessionUpdatedEvent(value),
            BetaManagedAgentsStartEvent value => startEvent(value),
            BetaManagedAgentsDeltaEvent value => deltaEvent(value),
            BetaManagedAgentsSystemMessageEvent value => systemMessageEvent(value),
            BetaManagedAgentsSessionUsageEvent value => sessionUsageEvent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsStreamSessionEvents"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserInterruptEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserToolConfirmationEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserCustomToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentCustomToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThinkingEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMcpToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentMcpToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadMessageReceivedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadMessageSentEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsAgentThreadContextCompactedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionErrorEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusRescheduledEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusRunningEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusIdleEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionStatusTerminatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadCreatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanModelRequestStartEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanModelRequestEndEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserDefineOutcomeEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionDeletedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusRunningEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusIdleEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusTerminatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsUserToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionUpdatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsStartEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsDeltaEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSystemMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsStreamSessionEvents(
        BetaManagedAgentsSessionUsageEvent value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsStreamSessionEvents"
            );
        }
        this.Switch(
            (userMessageEvent) => userMessageEvent.Validate(),
            (userInterruptEvent) => userInterruptEvent.Validate(),
            (userToolConfirmationEvent) => userToolConfirmationEvent.Validate(),
            (userCustomToolResultEvent) => userCustomToolResultEvent.Validate(),
            (agentCustomToolUseEvent) => agentCustomToolUseEvent.Validate(),
            (agentMessageEvent) => agentMessageEvent.Validate(),
            (agentThinkingEvent) => agentThinkingEvent.Validate(),
            (agentMcpToolUseEvent) => agentMcpToolUseEvent.Validate(),
            (agentMcpToolResultEvent) => agentMcpToolResultEvent.Validate(),
            (agentToolUseEvent) => agentToolUseEvent.Validate(),
            (agentToolResultEvent) => agentToolResultEvent.Validate(),
            (agentThreadMessageReceivedEvent) => agentThreadMessageReceivedEvent.Validate(),
            (agentThreadMessageSentEvent) => agentThreadMessageSentEvent.Validate(),
            (agentThreadContextCompactedEvent) => agentThreadContextCompactedEvent.Validate(),
            (sessionErrorEvent) => sessionErrorEvent.Validate(),
            (sessionStatusRescheduledEvent) => sessionStatusRescheduledEvent.Validate(),
            (sessionStatusRunningEvent) => sessionStatusRunningEvent.Validate(),
            (sessionStatusIdleEvent) => sessionStatusIdleEvent.Validate(),
            (sessionStatusTerminatedEvent) => sessionStatusTerminatedEvent.Validate(),
            (sessionThreadCreatedEvent) => sessionThreadCreatedEvent.Validate(),
            (spanOutcomeEvaluationStartEvent) => spanOutcomeEvaluationStartEvent.Validate(),
            (spanOutcomeEvaluationEndEvent) => spanOutcomeEvaluationEndEvent.Validate(),
            (spanModelRequestStartEvent) => spanModelRequestStartEvent.Validate(),
            (spanModelRequestEndEvent) => spanModelRequestEndEvent.Validate(),
            (spanOutcomeEvaluationOngoingEvent) => spanOutcomeEvaluationOngoingEvent.Validate(),
            (userDefineOutcomeEvent) => userDefineOutcomeEvent.Validate(),
            (sessionDeletedEvent) => sessionDeletedEvent.Validate(),
            (sessionThreadStatusRunningEvent) => sessionThreadStatusRunningEvent.Validate(),
            (sessionThreadStatusIdleEvent) => sessionThreadStatusIdleEvent.Validate(),
            (sessionThreadStatusTerminatedEvent) => sessionThreadStatusTerminatedEvent.Validate(),
            (userToolResultEvent) => userToolResultEvent.Validate(),
            (sessionThreadStatusRescheduledEvent) => sessionThreadStatusRescheduledEvent.Validate(),
            (sessionUpdatedEvent) => sessionUpdatedEvent.Validate(),
            (startEvent) => startEvent.Validate(),
            (deltaEvent) => deltaEvent.Validate(),
            (systemMessageEvent) => systemMessageEvent.Validate(),
            (sessionUsageEvent) => sessionUsageEvent.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsStreamSessionEvents? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEvent _ => 0,
            BetaManagedAgentsUserInterruptEvent _ => 1,
            BetaManagedAgentsUserToolConfirmationEvent _ => 2,
            BetaManagedAgentsUserCustomToolResultEvent _ => 3,
            BetaManagedAgentsAgentCustomToolUseEvent _ => 4,
            BetaManagedAgentsAgentMessageEvent _ => 5,
            BetaManagedAgentsAgentThinkingEvent _ => 6,
            BetaManagedAgentsAgentMcpToolUseEvent _ => 7,
            BetaManagedAgentsAgentMcpToolResultEvent _ => 8,
            BetaManagedAgentsAgentToolUseEvent _ => 9,
            BetaManagedAgentsAgentToolResultEvent _ => 10,
            BetaManagedAgentsAgentThreadMessageReceivedEvent _ => 11,
            BetaManagedAgentsAgentThreadMessageSentEvent _ => 12,
            BetaManagedAgentsAgentThreadContextCompactedEvent _ => 13,
            BetaManagedAgentsSessionErrorEvent _ => 14,
            BetaManagedAgentsSessionStatusRescheduledEvent _ => 15,
            BetaManagedAgentsSessionStatusRunningEvent _ => 16,
            BetaManagedAgentsSessionStatusIdleEvent _ => 17,
            BetaManagedAgentsSessionStatusTerminatedEvent _ => 18,
            BetaManagedAgentsSessionThreadCreatedEvent _ => 19,
            BetaManagedAgentsSpanOutcomeEvaluationStartEvent _ => 20,
            BetaManagedAgentsSpanOutcomeEvaluationEndEvent _ => 21,
            BetaManagedAgentsSpanModelRequestStartEvent _ => 22,
            BetaManagedAgentsSpanModelRequestEndEvent _ => 23,
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent _ => 24,
            BetaManagedAgentsUserDefineOutcomeEvent _ => 25,
            BetaManagedAgentsSessionDeletedEvent _ => 26,
            BetaManagedAgentsSessionThreadStatusRunningEvent _ => 27,
            BetaManagedAgentsSessionThreadStatusIdleEvent _ => 28,
            BetaManagedAgentsSessionThreadStatusTerminatedEvent _ => 29,
            BetaManagedAgentsUserToolResultEvent _ => 30,
            BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => 31,
            BetaManagedAgentsSessionUpdatedEvent _ => 32,
            BetaManagedAgentsStartEvent _ => 33,
            BetaManagedAgentsDeltaEvent _ => 34,
            BetaManagedAgentsSystemMessageEvent _ => 35,
            BetaManagedAgentsSessionUsageEvent _ => 36,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsStreamSessionEventsConverter
    : JsonConverter<BetaManagedAgentsStreamSessionEvents>
{
    public override BetaManagedAgentsStreamSessionEvents? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "user.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user.interrupt":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserInterruptEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user.tool_confirmation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user.custom_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.custom_tool_use":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentCustomToolUseEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.thinking":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentThinkingEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.mcp_tool_use":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolUseEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.mcp_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolResultEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.tool_use":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolUseEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentToolResultEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.thread_message_received":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.thread_message_sent":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "agent.thread_context_compacted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadContextCompactedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionErrorEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.status_rescheduled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusRescheduledEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.status_running":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusRunningEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.status_idle":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusIdleEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.status_terminated":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusTerminatedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.thread_created":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadCreatedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "span.outcome_evaluation_start":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationStartEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "span.outcome_evaluation_end":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationEndEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "span.model_request_start":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSpanModelRequestStartEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "span.model_request_end":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSpanModelRequestEndEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "span.outcome_evaluation_ongoing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user.define_outcome":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.deleted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionDeletedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.thread_status_running":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusRunningEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.thread_status_idle":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.thread_status_terminated":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusTerminatedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user.tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.thread_status_rescheduled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusRescheduledEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.updated":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionUpdatedEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStartEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "system.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "session.usage":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionUsageEvent>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaManagedAgentsStreamSessionEvents(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsStreamSessionEvents value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
