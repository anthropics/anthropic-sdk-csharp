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

    public string ID
    {
        get
        {
            return Match(
                userMessageEvent: (x) => x.ID,
                userInterruptEvent: (x) => x.ID,
                userToolConfirmationEvent: (x) => x.ID,
                userCustomToolResultEvent: (x) => x.ID,
                agentCustomToolUseEvent: (x) => x.ID,
                agentMessageEvent: (x) => x.ID,
                agentThinkingEvent: (x) => x.ID,
                agentMcpToolUseEvent: (x) => x.ID,
                agentMcpToolResultEvent: (x) => x.ID,
                agentToolUseEvent: (x) => x.ID,
                agentToolResultEvent: (x) => x.ID,
                agentThreadMessageReceivedEvent: (x) => x.ID,
                agentThreadMessageSentEvent: (x) => x.ID,
                agentThreadContextCompactedEvent: (x) => x.ID,
                sessionErrorEvent: (x) => x.ID,
                sessionStatusRescheduledEvent: (x) => x.ID,
                sessionStatusRunningEvent: (x) => x.ID,
                sessionStatusIdleEvent: (x) => x.ID,
                sessionStatusTerminatedEvent: (x) => x.ID,
                sessionThreadCreatedEvent: (x) => x.ID,
                spanOutcomeEvaluationStartEvent: (x) => x.ID,
                spanOutcomeEvaluationEndEvent: (x) => x.ID,
                spanModelRequestStartEvent: (x) => x.ID,
                spanModelRequestEndEvent: (x) => x.ID,
                spanOutcomeEvaluationOngoingEvent: (x) => x.ID,
                userDefineOutcomeEvent: (x) => x.ID,
                sessionDeletedEvent: (x) => x.ID,
                sessionThreadStatusRunningEvent: (x) => x.ID,
                sessionThreadStatusIdleEvent: (x) => x.ID,
                sessionThreadStatusTerminatedEvent: (x) => x.ID,
                sessionThreadStatusRescheduledEvent: (x) => x.ID
            );
        }
    }

    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                userMessageEvent: (x) => x.ProcessedAt,
                userInterruptEvent: (x) => x.ProcessedAt,
                userToolConfirmationEvent: (x) => x.ProcessedAt,
                userCustomToolResultEvent: (x) => x.ProcessedAt,
                agentCustomToolUseEvent: (x) => x.ProcessedAt,
                agentMessageEvent: (x) => x.ProcessedAt,
                agentThinkingEvent: (x) => x.ProcessedAt,
                agentMcpToolUseEvent: (x) => x.ProcessedAt,
                agentMcpToolResultEvent: (x) => x.ProcessedAt,
                agentToolUseEvent: (x) => x.ProcessedAt,
                agentToolResultEvent: (x) => x.ProcessedAt,
                agentThreadMessageReceivedEvent: (x) => x.ProcessedAt,
                agentThreadMessageSentEvent: (x) => x.ProcessedAt,
                agentThreadContextCompactedEvent: (x) => x.ProcessedAt,
                sessionErrorEvent: (x) => x.ProcessedAt,
                sessionStatusRescheduledEvent: (x) => x.ProcessedAt,
                sessionStatusRunningEvent: (x) => x.ProcessedAt,
                sessionStatusIdleEvent: (x) => x.ProcessedAt,
                sessionStatusTerminatedEvent: (x) => x.ProcessedAt,
                sessionThreadCreatedEvent: (x) => x.ProcessedAt,
                spanOutcomeEvaluationStartEvent: (x) => x.ProcessedAt,
                spanOutcomeEvaluationEndEvent: (x) => x.ProcessedAt,
                spanModelRequestStartEvent: (x) => x.ProcessedAt,
                spanModelRequestEndEvent: (x) => x.ProcessedAt,
                spanOutcomeEvaluationOngoingEvent: (x) => x.ProcessedAt,
                userDefineOutcomeEvent: (x) => x.ProcessedAt,
                sessionDeletedEvent: (x) => x.ProcessedAt,
                sessionThreadStatusRunningEvent: (x) => x.ProcessedAt,
                sessionThreadStatusIdleEvent: (x) => x.ProcessedAt,
                sessionThreadStatusTerminatedEvent: (x) => x.ProcessedAt,
                sessionThreadStatusRescheduledEvent: (x) => x.ProcessedAt
            );
        }
    }

    public string? SessionThreadID
    {
        get
        {
            return Match<string?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (x) => x.SessionThreadID,
                userToolConfirmationEvent: (x) => x.SessionThreadID,
                userCustomToolResultEvent: (x) => x.SessionThreadID,
                agentCustomToolUseEvent: (x) => x.SessionThreadID,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (x) => x.SessionThreadID,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (x) => x.SessionThreadID,
                agentToolResultEvent: (_) => null,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (x) => x.SessionThreadID,
                spanOutcomeEvaluationStartEvent: (_) => null,
                spanOutcomeEvaluationEndEvent: (_) => null,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (_) => null,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (x) => x.SessionThreadID,
                sessionThreadStatusIdleEvent: (x) => x.SessionThreadID,
                sessionThreadStatusTerminatedEvent: (x) => x.SessionThreadID,
                sessionThreadStatusRescheduledEvent: (x) => x.SessionThreadID
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (x) => x.ToolUseID,
                userCustomToolResultEvent: (_) => null,
                agentCustomToolUseEvent: (_) => null,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (_) => null,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (_) => null,
                agentToolResultEvent: (x) => x.ToolUseID,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (_) => null,
                spanOutcomeEvaluationStartEvent: (_) => null,
                spanOutcomeEvaluationEndEvent: (_) => null,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (_) => null,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (_) => null,
                sessionThreadStatusIdleEvent: (_) => null,
                sessionThreadStatusTerminatedEvent: (_) => null,
                sessionThreadStatusRescheduledEvent: (_) => null
            );
        }
    }

    public bool? IsError
    {
        get
        {
            return Match<bool?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (_) => null,
                userCustomToolResultEvent: (x) => x.IsError,
                agentCustomToolUseEvent: (_) => null,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (_) => null,
                agentMcpToolResultEvent: (x) => x.IsError,
                agentToolUseEvent: (_) => null,
                agentToolResultEvent: (x) => x.IsError,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (_) => null,
                spanOutcomeEvaluationStartEvent: (_) => null,
                spanOutcomeEvaluationEndEvent: (_) => null,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (x) => x.IsError,
                spanOutcomeEvaluationOngoingEvent: (_) => null,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (_) => null,
                sessionThreadStatusIdleEvent: (_) => null,
                sessionThreadStatusTerminatedEvent: (_) => null,
                sessionThreadStatusRescheduledEvent: (_) => null
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (_) => null,
                userCustomToolResultEvent: (_) => null,
                agentCustomToolUseEvent: (x) => x.Name,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (x) => x.Name,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (x) => x.Name,
                agentToolResultEvent: (_) => null,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (_) => null,
                spanOutcomeEvaluationStartEvent: (_) => null,
                spanOutcomeEvaluationEndEvent: (_) => null,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (_) => null,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (_) => null,
                sessionThreadStatusIdleEvent: (_) => null,
                sessionThreadStatusTerminatedEvent: (_) => null,
                sessionThreadStatusRescheduledEvent: (_) => null
            );
        }
    }

    public string? AgentName
    {
        get
        {
            return Match<string?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (_) => null,
                userCustomToolResultEvent: (_) => null,
                agentCustomToolUseEvent: (_) => null,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (_) => null,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (_) => null,
                agentToolResultEvent: (_) => null,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (x) => x.AgentName,
                spanOutcomeEvaluationStartEvent: (_) => null,
                spanOutcomeEvaluationEndEvent: (_) => null,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (_) => null,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (x) => x.AgentName,
                sessionThreadStatusIdleEvent: (x) => x.AgentName,
                sessionThreadStatusTerminatedEvent: (x) => x.AgentName,
                sessionThreadStatusRescheduledEvent: (x) => x.AgentName
            );
        }
    }

    public int? Iteration
    {
        get
        {
            return Match<int?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (_) => null,
                userCustomToolResultEvent: (_) => null,
                agentCustomToolUseEvent: (_) => null,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (_) => null,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (_) => null,
                agentToolResultEvent: (_) => null,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (_) => null,
                spanOutcomeEvaluationStartEvent: (x) => x.Iteration,
                spanOutcomeEvaluationEndEvent: (x) => x.Iteration,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (x) => x.Iteration,
                userDefineOutcomeEvent: (_) => null,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (_) => null,
                sessionThreadStatusIdleEvent: (_) => null,
                sessionThreadStatusTerminatedEvent: (_) => null,
                sessionThreadStatusRescheduledEvent: (_) => null
            );
        }
    }

    public string? OutcomeID
    {
        get
        {
            return Match<string?>(
                userMessageEvent: (_) => null,
                userInterruptEvent: (_) => null,
                userToolConfirmationEvent: (_) => null,
                userCustomToolResultEvent: (_) => null,
                agentCustomToolUseEvent: (_) => null,
                agentMessageEvent: (_) => null,
                agentThinkingEvent: (_) => null,
                agentMcpToolUseEvent: (_) => null,
                agentMcpToolResultEvent: (_) => null,
                agentToolUseEvent: (_) => null,
                agentToolResultEvent: (_) => null,
                agentThreadMessageReceivedEvent: (_) => null,
                agentThreadMessageSentEvent: (_) => null,
                agentThreadContextCompactedEvent: (_) => null,
                sessionErrorEvent: (_) => null,
                sessionStatusRescheduledEvent: (_) => null,
                sessionStatusRunningEvent: (_) => null,
                sessionStatusIdleEvent: (_) => null,
                sessionStatusTerminatedEvent: (_) => null,
                sessionThreadCreatedEvent: (_) => null,
                spanOutcomeEvaluationStartEvent: (x) => x.OutcomeID,
                spanOutcomeEvaluationEndEvent: (x) => x.OutcomeID,
                spanModelRequestStartEvent: (_) => null,
                spanModelRequestEndEvent: (_) => null,
                spanOutcomeEvaluationOngoingEvent: (x) => x.OutcomeID,
                userDefineOutcomeEvent: (x) => x.OutcomeID,
                sessionDeletedEvent: (_) => null,
                sessionThreadStatusRunningEvent: (_) => null,
                sessionThreadStatusIdleEvent: (_) => null,
                sessionThreadStatusTerminatedEvent: (_) => null,
                sessionThreadStatusRescheduledEvent: (_) => null
            );
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
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value,
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
    ///     (BetaManagedAgentsSessionThreadStatusRescheduledEvent value) =&gt; {...}
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
        System::Action<BetaManagedAgentsSessionThreadStatusRescheduledEvent> sessionThreadStatusRescheduledEvent
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
            case BetaManagedAgentsSessionThreadStatusRescheduledEvent value:
                sessionThreadStatusRescheduledEvent(value);
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
    ///     (BetaManagedAgentsSessionThreadStatusRescheduledEvent value) =&gt; {...}
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
        System::Func<
            BetaManagedAgentsSessionThreadStatusRescheduledEvent,
            T
        > sessionThreadStatusRescheduledEvent
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
            BetaManagedAgentsSessionThreadStatusRescheduledEvent value =>
                sessionThreadStatusRescheduledEvent(value),
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
        BetaManagedAgentsSessionThreadStatusRescheduledEvent value
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
            (sessionThreadStatusRescheduledEvent) => sessionThreadStatusRescheduledEvent.Validate()
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
            BetaManagedAgentsSessionThreadStatusRescheduledEvent _ => 30,
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
