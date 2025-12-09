using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Client.Services.Messages;

/// <summary>
/// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
/// </summary>
public class BetaMessageContentAggregator : SseAggregator<BetaRawMessageStreamEvent, BetaMessage>
{
    /// <summary>
    /// Creates a new instance of the <see cref="BetaMessageContentAggregator"/>.
    /// </summary>
    /// <param name="messages">The async enumerable representing a stream of messages.</param>
    public BetaMessageContentAggregator(IAsyncEnumerable<BetaRawMessageStreamEvent> messages) : base(messages)
    {
    }

    /// <summary>
    /// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
    /// </summary>
    private record BetaMessageAggregationResult
    {
        /// <summary>
        /// Gets or sets the aggregated Text from an <see cref="BetaTextDelta"/>
        /// </summary>
        public string? Text { get; set; }


        /// <summary>
        /// Gets or sets the aggregated Text from an <see cref="BetaInputJSONDelta"/>
        /// </summary>
        public string? PartialJson { get; set; }


        /// <summary>
        /// Gets or sets the aggregated Text from an <see cref="BetaCitationsDelta"/>
        /// </summary>
        public IList<Citation> Citations { get; set; } = [];


        /// <summary>
        /// Gets or sets the aggregated Text from an <see cref="BetaThinkingDelta"/>
        /// </summary>
        public string? Thinking { get; internal set; }

        /// <summary>
        /// Gets or sets the aggregated Text from an <see cref="BetaSignatureDelta"/>
        /// </summary>
        public string? Signature { get; internal set; }
    }

    protected override BetaMessage GetResult(IReadOnlyCollection<BetaRawMessageStreamEvent> messages)
    {
        var aggregation = new BetaMessageAggregationResult();

        foreach (var item in messages.Select(e => e.Value).Cast<BetaRawContentBlockDelta>())
        {
            item.Switch(
                e => aggregation.Text += e.Text,
                e => aggregation.PartialJson += e.PartialJSON,
                e => aggregation.Citations.Add(e.Citation),
                e => aggregation.Thinking += e.Thinking,
                e => aggregation.Signature += e.Signature);
        }

        var messageContents = new List<BetaContentBlock>();
        if (!string.IsNullOrWhiteSpace(aggregation.Text))
        {
            messageContents.Add(new BetaTextBlock()
            {
                Text = aggregation.Text!,
                Citations = [.. aggregation.Citations.Select(e => new BetaTextCitation(e.Json))],                
            });
        }

        if (!string.IsNullOrWhiteSpace(aggregation.Thinking))
        {
            messageContents.Add(new BetaThinkingBlock()
            {
                Thinking = aggregation.Thinking!,
                Signature = aggregation.Signature!
            });
        }

        return new()
        {
            Content = [.. messageContents],
            Container = null,
            ContextManagement = null,
            ID = Guid.NewGuid().ToString(),
            Model = null!,
            StopReason = null!,
            StopSequence = null!,
            Usage = null!            
        };
    }

    protected override FilterResult Filter(BetaRawMessageStreamEvent message) => message.Value switch
    {
        BetaRawContentBlockStartEvent _ => FilterResult.StartMessage,
        BetaRawContentBlockStopEvent _ => FilterResult.EndMessage,
        BetaRawContentBlockDeltaEvent _ => FilterResult.Content,
        BetaRawMessageStopEvent _ => FilterResult.EndMessage,
        _ => FilterResult.Ignore
    };
}
