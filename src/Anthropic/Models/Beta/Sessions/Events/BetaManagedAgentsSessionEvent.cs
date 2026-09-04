using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Union type for all event types in a session.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionEventConverter))]
public record class BetaManagedAgentsSessionEvent : ModelBase
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

    public string ID
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
                BetaManagedAgentsSystemMessageEvent x => x.ID,
                BetaManagedAgentsSessionUsageEvent x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
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
                BetaManagedAgentsSystemMessageEvent _ => null,
                BetaManagedAgentsSessionUsageEvent x => x.Budget,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaManagedAgentsBudgetLimit>(
                    this.Json,
                    "budget"
                ),
            };
        }
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserInterruptEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserToolConfirmationEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserCustomToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentCustomToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThinkingEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMcpToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMcpToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentToolUseEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadMessageReceivedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadMessageSentEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadContextCompactedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionErrorEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusRescheduledEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusRunningEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusIdleEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusTerminatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadCreatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanModelRequestStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanModelRequestEndEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserDefineOutcomeEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionDeletedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusRunningEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusIdleEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusTerminatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserToolResultEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionUpdatedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSystemMessageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionUsageEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionEvent(JsonElement element)
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
    /// if (instance.TryPickUserMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserMessage([NotNullWhen(true)] out BetaManagedAgentsUserMessageEvent? value)
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
    /// if (instance.TryPickUserInterrupt(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserInterruptEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserInterrupt(
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
    /// if (instance.TryPickUserToolConfirmation(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolConfirmationEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserToolConfirmation(
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
    /// if (instance.TryPickUserCustomToolResult(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserCustomToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserCustomToolResult(
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
    /// if (instance.TryPickAgentCustomToolUse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentCustomToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentCustomToolUse(
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
    /// if (instance.TryPickAgentMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMessage(
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
    /// if (instance.TryPickAgentThinking(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThinkingEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThinking(
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
    /// if (instance.TryPickAgentMcpToolUse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMcpToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMcpToolUse(
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
    /// if (instance.TryPickAgentMcpToolResult(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentMcpToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentMcpToolResult(
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
    /// if (instance.TryPickAgentToolUse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolUseEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentToolUse(
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
    /// if (instance.TryPickAgentToolResult(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentToolResult(
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
    /// if (instance.TryPickAgentThreadMessageReceived(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadMessageReceivedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadMessageReceived(
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
    /// if (instance.TryPickAgentThreadMessageSent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadMessageSentEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadMessageSent(
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
    /// if (instance.TryPickAgentThreadContextCompacted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentThreadContextCompactedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAgentThreadContextCompacted(
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
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out BetaManagedAgentsSessionErrorEvent? value)
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
    /// if (instance.TryPickStatusRescheduled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusRescheduledEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStatusRescheduled(
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
    /// if (instance.TryPickStatusRunning(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusRunningEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStatusRunning(
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
    /// if (instance.TryPickStatusIdle(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusIdleEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStatusIdle(
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
    /// if (instance.TryPickStatusTerminated(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionStatusTerminatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStatusTerminated(
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
    /// if (instance.TryPickThreadCreated(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadCreatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadCreated(
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
    /// if (instance.TryPickSpanOutcomeEvaluationStart(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationStart(
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
    /// if (instance.TryPickSpanOutcomeEvaluationEnd(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationEndEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationEnd(
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
    /// if (instance.TryPickSpanModelRequestStart(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanModelRequestStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanModelRequestStart(
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
    /// if (instance.TryPickSpanModelRequestEnd(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanModelRequestEndEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanModelRequestEnd(
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
    /// if (instance.TryPickSpanOutcomeEvaluationOngoing(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSpanOutcomeEvaluationOngoing(
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
    /// if (instance.TryPickUserDefineOutcome(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserDefineOutcomeEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserDefineOutcome(
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
    /// if (instance.TryPickDeleted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionDeletedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDeleted([NotNullWhen(true)] out BetaManagedAgentsSessionDeletedEvent? value)
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
    /// if (instance.TryPickThreadStatusRunning(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusRunningEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadStatusRunning(
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
    /// if (instance.TryPickThreadStatusIdle(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusIdleEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadStatusIdle(
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
    /// if (instance.TryPickThreadStatusTerminated(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusTerminatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadStatusTerminated(
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
    /// if (instance.TryPickUserToolResult(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserToolResult(
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
    /// if (instance.TryPickThreadStatusRescheduled(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionThreadStatusRescheduledEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThreadStatusRescheduled(
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
    /// if (instance.TryPickUpdated(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionUpdatedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUpdated([NotNullWhen(true)] out BetaManagedAgentsSessionUpdatedEvent? value)
    {
        value = this.Value as BetaManagedAgentsSessionUpdatedEvent;
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
    /// if (instance.TryPickSystemMessage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSystemMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystemMessage(
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
    /// if (instance.TryPickUsage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionUsageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUsage([NotNullWhen(true)] out BetaManagedAgentsSessionUsageEvent? value)
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
    ///     (BetaManagedAgentsSystemMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUsageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUserMessageEvent> userMessage,
        System::Action<BetaManagedAgentsUserInterruptEvent> userInterrupt,
        System::Action<BetaManagedAgentsUserToolConfirmationEvent> userToolConfirmation,
        System::Action<BetaManagedAgentsUserCustomToolResultEvent> userCustomToolResult,
        System::Action<BetaManagedAgentsAgentCustomToolUseEvent> agentCustomToolUse,
        System::Action<BetaManagedAgentsAgentMessageEvent> agentMessage,
        System::Action<BetaManagedAgentsAgentThinkingEvent> agentThinking,
        System::Action<BetaManagedAgentsAgentMcpToolUseEvent> agentMcpToolUse,
        System::Action<BetaManagedAgentsAgentMcpToolResultEvent> agentMcpToolResult,
        System::Action<BetaManagedAgentsAgentToolUseEvent> agentToolUse,
        System::Action<BetaManagedAgentsAgentToolResultEvent> agentToolResult,
        System::Action<BetaManagedAgentsAgentThreadMessageReceivedEvent> agentThreadMessageReceived,
        System::Action<BetaManagedAgentsAgentThreadMessageSentEvent> agentThreadMessageSent,
        System::Action<BetaManagedAgentsAgentThreadContextCompactedEvent> agentThreadContextCompacted,
        System::Action<BetaManagedAgentsSessionErrorEvent> error,
        System::Action<BetaManagedAgentsSessionStatusRescheduledEvent> statusRescheduled,
        System::Action<BetaManagedAgentsSessionStatusRunningEvent> statusRunning,
        System::Action<BetaManagedAgentsSessionStatusIdleEvent> statusIdle,
        System::Action<BetaManagedAgentsSessionStatusTerminatedEvent> statusTerminated,
        System::Action<BetaManagedAgentsSessionThreadCreatedEvent> threadCreated,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationStartEvent> spanOutcomeEvaluationStart,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationEndEvent> spanOutcomeEvaluationEnd,
        System::Action<BetaManagedAgentsSpanModelRequestStartEvent> spanModelRequestStart,
        System::Action<BetaManagedAgentsSpanModelRequestEndEvent> spanModelRequestEnd,
        System::Action<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent> spanOutcomeEvaluationOngoing,
        System::Action<BetaManagedAgentsUserDefineOutcomeEvent> userDefineOutcome,
        System::Action<BetaManagedAgentsSessionDeletedEvent> deleted,
        System::Action<BetaManagedAgentsSessionThreadStatusRunningEvent> threadStatusRunning,
        System::Action<BetaManagedAgentsSessionThreadStatusIdleEvent> threadStatusIdle,
        System::Action<BetaManagedAgentsSessionThreadStatusTerminatedEvent> threadStatusTerminated,
        System::Action<BetaManagedAgentsUserToolResultEvent> userToolResult,
        System::Action<BetaManagedAgentsSessionThreadStatusRescheduledEvent> threadStatusRescheduled,
        System::Action<BetaManagedAgentsSessionUpdatedEvent> updated,
        System::Action<BetaManagedAgentsSystemMessageEvent> systemMessage,
        System::Action<BetaManagedAgentsSessionUsageEvent> usage
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUserMessageEvent value:
                userMessage(value);
                break;
            case BetaManagedAgentsUserInterruptEvent value:
                userInterrupt(value);
                break;
            case BetaManagedAgentsUserToolConfirmationEvent value:
                userToolConfirmation(value);
                break;
            case BetaManagedAgentsUserCustomToolResultEvent value:
                userCustomToolResult(value);
                break;
            case BetaManagedAgentsAgentCustomToolUseEvent value:
                agentCustomToolUse(value);
                break;
            case BetaManagedAgentsAgentMessageEvent value:
                agentMessage(value);
                break;
            case BetaManagedAgentsAgentThinkingEvent value:
                agentThinking(value);
                break;
            case BetaManagedAgentsAgentMcpToolUseEvent value:
                agentMcpToolUse(value);
                break;
            case BetaManagedAgentsAgentMcpToolResultEvent value:
                agentMcpToolResult(value);
                break;
            case BetaManagedAgentsAgentToolUseEvent value:
                agentToolUse(value);
                break;
            case BetaManagedAgentsAgentToolResultEvent value:
                agentToolResult(value);
                break;
            case BetaManagedAgentsAgentThreadMessageReceivedEvent value:
                agentThreadMessageReceived(value);
                break;
            case BetaManagedAgentsAgentThreadMessageSentEvent value:
                agentThreadMessageSent(value);
                break;
            case BetaManagedAgentsAgentThreadContextCompactedEvent value:
                agentThreadContextCompacted(value);
                break;
            case BetaManagedAgentsSessionErrorEvent value:
                error(value);
                break;
            case BetaManagedAgentsSessionStatusRescheduledEvent value:
                statusRescheduled(value);
                break;
            case BetaManagedAgentsSessionStatusRunningEvent value:
                statusRunning(value);
                break;
            case BetaManagedAgentsSessionStatusIdleEvent value:
                statusIdle(value);
                break;
            case BetaManagedAgentsSessionStatusTerminatedEvent value:
                statusTerminated(value);
                break;
            case BetaManagedAgentsSessionThreadCreatedEvent value:
                threadCreated(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationStartEvent value:
                spanOutcomeEvaluationStart(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationEndEvent value:
                spanOutcomeEvaluationEnd(value);
                break;
            case BetaManagedAgentsSpanModelRequestStartEvent value:
                spanModelRequestStart(value);
                break;
            case BetaManagedAgentsSpanModelRequestEndEvent value:
                spanModelRequestEnd(value);
                break;
            case BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value:
                spanOutcomeEvaluationOngoing(value);
                break;
            case BetaManagedAgentsUserDefineOutcomeEvent value:
                userDefineOutcome(value);
                break;
            case BetaManagedAgentsSessionDeletedEvent value:
                deleted(value);
                break;
            case BetaManagedAgentsSessionThreadStatusRunningEvent value:
                threadStatusRunning(value);
                break;
            case BetaManagedAgentsSessionThreadStatusIdleEvent value:
                threadStatusIdle(value);
                break;
            case BetaManagedAgentsSessionThreadStatusTerminatedEvent value:
                threadStatusTerminated(value);
                break;
            case BetaManagedAgentsUserToolResultEvent value:
                userToolResult(value);
                break;
            case BetaManagedAgentsSessionThreadStatusRescheduledEvent value:
                threadStatusRescheduled(value);
                break;
            case BetaManagedAgentsSessionUpdatedEvent value:
                updated(value);
                break;
            case BetaManagedAgentsSystemMessageEvent value:
                systemMessage(value);
                break;
            case BetaManagedAgentsSessionUsageEvent value:
                usage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionEvent"
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
    ///     (BetaManagedAgentsSystemMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsSessionUsageEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUserMessageEvent, T> userMessage,
        System::Func<BetaManagedAgentsUserInterruptEvent, T> userInterrupt,
        System::Func<BetaManagedAgentsUserToolConfirmationEvent, T> userToolConfirmation,
        System::Func<BetaManagedAgentsUserCustomToolResultEvent, T> userCustomToolResult,
        System::Func<BetaManagedAgentsAgentCustomToolUseEvent, T> agentCustomToolUse,
        System::Func<BetaManagedAgentsAgentMessageEvent, T> agentMessage,
        System::Func<BetaManagedAgentsAgentThinkingEvent, T> agentThinking,
        System::Func<BetaManagedAgentsAgentMcpToolUseEvent, T> agentMcpToolUse,
        System::Func<BetaManagedAgentsAgentMcpToolResultEvent, T> agentMcpToolResult,
        System::Func<BetaManagedAgentsAgentToolUseEvent, T> agentToolUse,
        System::Func<BetaManagedAgentsAgentToolResultEvent, T> agentToolResult,
        System::Func<
            BetaManagedAgentsAgentThreadMessageReceivedEvent,
            T
        > agentThreadMessageReceived,
        System::Func<BetaManagedAgentsAgentThreadMessageSentEvent, T> agentThreadMessageSent,
        System::Func<
            BetaManagedAgentsAgentThreadContextCompactedEvent,
            T
        > agentThreadContextCompacted,
        System::Func<BetaManagedAgentsSessionErrorEvent, T> error,
        System::Func<BetaManagedAgentsSessionStatusRescheduledEvent, T> statusRescheduled,
        System::Func<BetaManagedAgentsSessionStatusRunningEvent, T> statusRunning,
        System::Func<BetaManagedAgentsSessionStatusIdleEvent, T> statusIdle,
        System::Func<BetaManagedAgentsSessionStatusTerminatedEvent, T> statusTerminated,
        System::Func<BetaManagedAgentsSessionThreadCreatedEvent, T> threadCreated,
        System::Func<
            BetaManagedAgentsSpanOutcomeEvaluationStartEvent,
            T
        > spanOutcomeEvaluationStart,
        System::Func<BetaManagedAgentsSpanOutcomeEvaluationEndEvent, T> spanOutcomeEvaluationEnd,
        System::Func<BetaManagedAgentsSpanModelRequestStartEvent, T> spanModelRequestStart,
        System::Func<BetaManagedAgentsSpanModelRequestEndEvent, T> spanModelRequestEnd,
        System::Func<
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent,
            T
        > spanOutcomeEvaluationOngoing,
        System::Func<BetaManagedAgentsUserDefineOutcomeEvent, T> userDefineOutcome,
        System::Func<BetaManagedAgentsSessionDeletedEvent, T> deleted,
        System::Func<BetaManagedAgentsSessionThreadStatusRunningEvent, T> threadStatusRunning,
        System::Func<BetaManagedAgentsSessionThreadStatusIdleEvent, T> threadStatusIdle,
        System::Func<BetaManagedAgentsSessionThreadStatusTerminatedEvent, T> threadStatusTerminated,
        System::Func<BetaManagedAgentsUserToolResultEvent, T> userToolResult,
        System::Func<
            BetaManagedAgentsSessionThreadStatusRescheduledEvent,
            T
        > threadStatusRescheduled,
        System::Func<BetaManagedAgentsSessionUpdatedEvent, T> updated,
        System::Func<BetaManagedAgentsSystemMessageEvent, T> systemMessage,
        System::Func<BetaManagedAgentsSessionUsageEvent, T> usage
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEvent value => userMessage(value),
            BetaManagedAgentsUserInterruptEvent value => userInterrupt(value),
            BetaManagedAgentsUserToolConfirmationEvent value => userToolConfirmation(value),
            BetaManagedAgentsUserCustomToolResultEvent value => userCustomToolResult(value),
            BetaManagedAgentsAgentCustomToolUseEvent value => agentCustomToolUse(value),
            BetaManagedAgentsAgentMessageEvent value => agentMessage(value),
            BetaManagedAgentsAgentThinkingEvent value => agentThinking(value),
            BetaManagedAgentsAgentMcpToolUseEvent value => agentMcpToolUse(value),
            BetaManagedAgentsAgentMcpToolResultEvent value => agentMcpToolResult(value),
            BetaManagedAgentsAgentToolUseEvent value => agentToolUse(value),
            BetaManagedAgentsAgentToolResultEvent value => agentToolResult(value),
            BetaManagedAgentsAgentThreadMessageReceivedEvent value => agentThreadMessageReceived(
                value
            ),
            BetaManagedAgentsAgentThreadMessageSentEvent value => agentThreadMessageSent(value),
            BetaManagedAgentsAgentThreadContextCompactedEvent value => agentThreadContextCompacted(
                value
            ),
            BetaManagedAgentsSessionErrorEvent value => error(value),
            BetaManagedAgentsSessionStatusRescheduledEvent value => statusRescheduled(value),
            BetaManagedAgentsSessionStatusRunningEvent value => statusRunning(value),
            BetaManagedAgentsSessionStatusIdleEvent value => statusIdle(value),
            BetaManagedAgentsSessionStatusTerminatedEvent value => statusTerminated(value),
            BetaManagedAgentsSessionThreadCreatedEvent value => threadCreated(value),
            BetaManagedAgentsSpanOutcomeEvaluationStartEvent value => spanOutcomeEvaluationStart(
                value
            ),
            BetaManagedAgentsSpanOutcomeEvaluationEndEvent value => spanOutcomeEvaluationEnd(value),
            BetaManagedAgentsSpanModelRequestStartEvent value => spanModelRequestStart(value),
            BetaManagedAgentsSpanModelRequestEndEvent value => spanModelRequestEnd(value),
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value =>
                spanOutcomeEvaluationOngoing(value),
            BetaManagedAgentsUserDefineOutcomeEvent value => userDefineOutcome(value),
            BetaManagedAgentsSessionDeletedEvent value => deleted(value),
            BetaManagedAgentsSessionThreadStatusRunningEvent value => threadStatusRunning(value),
            BetaManagedAgentsSessionThreadStatusIdleEvent value => threadStatusIdle(value),
            BetaManagedAgentsSessionThreadStatusTerminatedEvent value => threadStatusTerminated(
                value
            ),
            BetaManagedAgentsUserToolResultEvent value => userToolResult(value),
            BetaManagedAgentsSessionThreadStatusRescheduledEvent value => threadStatusRescheduled(
                value
            ),
            BetaManagedAgentsSessionUpdatedEvent value => updated(value),
            BetaManagedAgentsSystemMessageEvent value => systemMessage(value),
            BetaManagedAgentsSessionUsageEvent value => usage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionEvent"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserInterruptEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserToolConfirmationEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserCustomToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentCustomToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThinkingEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMcpToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentMcpToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentToolUseEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadMessageReceivedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadMessageSentEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsAgentThreadContextCompactedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionErrorEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusRescheduledEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusRunningEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusIdleEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionStatusTerminatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadCreatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanModelRequestStartEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanModelRequestEndEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserDefineOutcomeEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionDeletedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusRunningEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusIdleEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusTerminatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsUserToolResultEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSessionUpdatedEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
        BetaManagedAgentsSystemMessageEvent value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionEvent(
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
                "Data did not match any variant of BetaManagedAgentsSessionEvent"
            );
        }
        this.Switch(
            (userMessage) => userMessage.Validate(),
            (userInterrupt) => userInterrupt.Validate(),
            (userToolConfirmation) => userToolConfirmation.Validate(),
            (userCustomToolResult) => userCustomToolResult.Validate(),
            (agentCustomToolUse) => agentCustomToolUse.Validate(),
            (agentMessage) => agentMessage.Validate(),
            (agentThinking) => agentThinking.Validate(),
            (agentMcpToolUse) => agentMcpToolUse.Validate(),
            (agentMcpToolResult) => agentMcpToolResult.Validate(),
            (agentToolUse) => agentToolUse.Validate(),
            (agentToolResult) => agentToolResult.Validate(),
            (agentThreadMessageReceived) => agentThreadMessageReceived.Validate(),
            (agentThreadMessageSent) => agentThreadMessageSent.Validate(),
            (agentThreadContextCompacted) => agentThreadContextCompacted.Validate(),
            (error) => error.Validate(),
            (statusRescheduled) => statusRescheduled.Validate(),
            (statusRunning) => statusRunning.Validate(),
            (statusIdle) => statusIdle.Validate(),
            (statusTerminated) => statusTerminated.Validate(),
            (threadCreated) => threadCreated.Validate(),
            (spanOutcomeEvaluationStart) => spanOutcomeEvaluationStart.Validate(),
            (spanOutcomeEvaluationEnd) => spanOutcomeEvaluationEnd.Validate(),
            (spanModelRequestStart) => spanModelRequestStart.Validate(),
            (spanModelRequestEnd) => spanModelRequestEnd.Validate(),
            (spanOutcomeEvaluationOngoing) => spanOutcomeEvaluationOngoing.Validate(),
            (userDefineOutcome) => userDefineOutcome.Validate(),
            (deleted) => deleted.Validate(),
            (threadStatusRunning) => threadStatusRunning.Validate(),
            (threadStatusIdle) => threadStatusIdle.Validate(),
            (threadStatusTerminated) => threadStatusTerminated.Validate(),
            (userToolResult) => userToolResult.Validate(),
            (threadStatusRescheduled) => threadStatusRescheduled.Validate(),
            (updated) => updated.Validate(),
            (systemMessage) => systemMessage.Validate(),
            (usage) => usage.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionEvent? other) =>
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
            BetaManagedAgentsSystemMessageEvent _ => 33,
            BetaManagedAgentsSessionUsageEvent _ => 34,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionEventConverter : JsonConverter<BetaManagedAgentsSessionEvent>
{
    public override BetaManagedAgentsSessionEvent? Read(
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
                return new BetaManagedAgentsSessionEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
