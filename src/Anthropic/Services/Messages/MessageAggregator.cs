using System.Collections.Generic;
using System.Linq;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.CitationsDeltaProperties;
using RawMessageStreamEventVariants = Anthropic.Client.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Client.Services.Messages;

/// <summary>
/// An implementaion of the <see cref="SseAggregator{TMessage, TResult}"/> for aggregating BlockDeltaEvents from the <see cref="IMessageService.CreateStreaming(MessageCreateParams)"/> method.
/// </summary>
public class MessageContentAggregator : SseAggregator<RawMessageStreamEvent, MessageAggregationResult>
{
    /// <summary>
    /// Creates a new instance of the <see cref="MessageContentAggregator"/>.
    /// </summary>
    /// <param name="messages">The async enumerable representing a stream of messages.</param>
    public MessageContentAggregator(IAsyncEnumerable<RawMessageStreamEvent> messages) : base(messages)
    {
    }
    
    protected override MessageAggregationResult GetResult(IReadOnlyCollection<RawMessageStreamEvent> messages)
    {
        var aggregation = new MessageAggregationResult();
        foreach (var item in messages.Cast<RawMessageStreamEventVariants::RawContentBlockDeltaEvent>().Select(e => e.Value.Delta))
        {
            item.Switch(
                e => aggregation.Text += e.Value.Text,
                e => aggregation.PartialJson += e.Value.PartialJSON,
                e => aggregation.Citations.Add(e.Value.Citation),
                e => aggregation.Thinking += e.Value.Thinking,
                e => aggregation.Thinking += e.Value.Signature);
        }

        return aggregation;
    }

    protected override FilterResult Filter(RawMessageStreamEvent message) => message switch
    {
        RawMessageStreamEventVariants::RawContentBlockStartEvent _ => FilterResult.StartMessage,
        RawMessageStreamEventVariants::RawContentBlockStopEvent _ => FilterResult.EndMessage,
        RawMessageStreamEventVariants::RawContentBlockDeltaEvent _ => FilterResult.Content,
        RawMessageStreamEventVariants::RawMessageStopEvent _ => FilterResult.EndMessage,
        _ => FilterResult.Ignore
    };
}

/// <summary>
/// The aggregation model for a stream of <see cref="RawContentBlockDeltaEvent"/>
/// </summary>
public class MessageAggregationResult
{
    /// <summary>
    /// Gets or sets the aggregated Text from an <see cref="TextDelta"/>
    /// </summary>
    public string? Text { get; set; }

    
    /// <summary>
    /// Gets or sets the aggregated Text from an <see cref="InputJSONDelta"/>
    /// </summary>
    public string? PartialJson { get; set; }


    /// <summary>
    /// Gets or sets the aggregated Text from an <see cref="CitationsDelta"/>
    /// </summary>
    public IList<Citation> Citations { get; set; } = [];
    
    
    /// <summary>
    /// Gets or sets the aggregated Text from an <see cref="ThinkingDelta"/>
    /// </summary>
    public string? Thinking { get; internal set; }
}
