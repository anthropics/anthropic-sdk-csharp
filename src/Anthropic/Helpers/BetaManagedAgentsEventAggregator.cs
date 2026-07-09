using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Helpers;

/// <summary>
/// Folds <c>event_start</c> / <c>event_delta</c> preview events from a session stream
/// into per-event-id <see cref="BetaManagedAgentsAgentMessageEvent"/> snapshots.
///
/// <code>
/// var aggregator = new BetaManagedAgentsEventAggregator();
/// await foreach (var events in stream)
/// {
///     aggregator.Aggregate(events);
///
///     if (events.TryPickDeltaEvent(out var delta))
///     {
///         Console.Write(aggregator.TryGetAgentMessageText(delta.EventID) ?? "");
///     }
/// }
/// </code>
/// </summary>
public sealed class BetaManagedAgentsEventAggregator
{
    private readonly Dictionary<string, BetaManagedAgentsAgentMessageEvent> _agentMessages = [];

    // Event ids whose canonical agent.message has landed; straggler previews and
    // deltas for these must never clobber canonical content, so they're dropped,
    // and the canonical snapshots survive span.model_request_end.
    private readonly HashSet<string> _finalizedEventIDs = [];

    public BetaManagedAgentsEventAggregator()
    {
        this.AgentMessages = new ReadOnlyDictionary<string, BetaManagedAgentsAgentMessageEvent>(
            this._agentMessages
        );
    }

    /// <summary>
    /// The in-progress (or completed) agent message snapshot for each previewed event id,
    /// enumerating in insertion order. Snapshots built from deltas are lossy previews
    /// (their <c>ProcessedAt</c> is a placeholder until the canonical event arrives);
    /// a final <c>agent.message</c> event replaces its preview with the canonical event.
    /// <c>span.model_request_end</c> drops previews still open for the finished request
    /// (they will never be completed) while canonical snapshots survive.
    /// </summary>
    public IReadOnlyDictionary<string, BetaManagedAgentsAgentMessageEvent> AgentMessages { get; }

    /// <summary>
    /// Folds a single session stream event into the aggregated snapshots. Only
    /// <c>agent.message</c> previews are aggregated; everything else — including
    /// deltas for event ids that aren't being aggregated and stragglers arriving
    /// after an id's canonical <c>agent.message</c> — is ignored.
    /// </summary>
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when an <c>event_delta</c>'s content index skips past the end of the
    /// accumulated content, or when its content fragment is malformed.
    /// </exception>
    public void Aggregate(BetaManagedAgentsStreamSessionEvents events)
    {
        if (events.TryPickStartEvent(out var startEvent))
        {
            // agent.message is the only aggregated preview type; previews of any
            // other type (agent.thinking, types this SDK version doesn't know yet)
            // aren't tracked, so their deltas fall through to the drop below.
            if (startEvent.Event.TryPickAgentMessage(out var agentMessagePreview))
            {
                if (this._finalizedEventIDs.Contains(agentMessagePreview.ID))
                {
                    // A straggler restart must not clobber canonical content.
                    return;
                }

                this._agentMessages[agentMessagePreview.ID] = new()
                {
                    ID = agentMessagePreview.ID,
                    Content = [],
                    ProcessedAt = default,
                    Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
                };
            }
        }
        else if (events.TryPickDeltaEvent(out var deltaEvent))
        {
            if (this._finalizedEventIDs.Contains(deltaEvent.EventID))
            {
                // A straggler delta must not clobber canonical content.
                return;
            }

            if (!this._agentMessages.TryGetValue(deltaEvent.EventID, out var message))
            {
                // Not an aggregated agent.message preview — drop the delta.
                return;
            }

            var rawIndex = deltaEvent.Delta.Index ?? 0;
            var content = new List<BetaManagedAgentsTextBlock>(message.Content);
            if (rawIndex < 0 || rawIndex > content.Count)
            {
                throw new AnthropicInvalidDataException(
                    $"Received event_delta for event '{deltaEvent.EventID}' with content index {rawIndex} "
                        + $"but only {content.Count} content block(s) accumulated"
                );
            }

            // In range, so the long index fits in an int.
            int index = (int)rawIndex;
            if (index == content.Count)
            {
                content.Add(deltaEvent.Delta.Content);
            }
            else
            {
                content[index] = content[index] with
                {
                    Text = content[index].Text + deltaEvent.Delta.Content.Text,
                };
            }
            this._agentMessages[deltaEvent.EventID] = message with { Content = content };
        }
        else if (events.TryPickAgentMessageEvent(out var agentMessageEvent))
        {
            // The buffered event is canonical and replaces any lossy preview.
            this._agentMessages[agentMessageEvent.ID] = agentMessageEvent;
            this._finalizedEventIDs.Add(agentMessageEvent.ID);
        }
        else if (events.TryPickSpanModelRequestEndEvent(out _))
        {
            // The producing model request ended (possibly mid-stream); previews
            // still open will never be completed, so they're dropped. Canonical
            // agent.message snapshots survive. Rebuilding (rather than removing
            // in place) keeps enumeration in insertion order — Dictionary reuses
            // freed slots, so removals would let later ids jump the order.
            var canonical = this
                ._agentMessages.Where(entry => this._finalizedEventIDs.Contains(entry.Key))
                .ToList();
            this._agentMessages.Clear();
            foreach (var entry in canonical)
            {
                this._agentMessages[entry.Key] = entry.Value;
            }
        }
    }

    /// <summary>
    /// The concatenated text of the aggregated agent message with the given event id,
    /// or <c>null</c> if the event id is unknown.
    /// </summary>
    public string? TryGetAgentMessageText(string eventID)
    {
        return this._agentMessages.TryGetValue(eventID, out var message)
            ? string.Concat(message.Content.Select(block => block.Text))
            : null;
    }

    /// <summary>
    /// The concatenated text of the aggregated agent message with the given event id.
    /// </summary>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no agent message with the given event id is being aggregated.
    /// </exception>
    public string GetAgentMessageText(string eventID)
    {
        return this.TryGetAgentMessageText(eventID)
            ?? throw new KeyNotFoundException($"No aggregated agent message for event '{eventID}'");
    }
}
