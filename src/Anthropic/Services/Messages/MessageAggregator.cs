using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Messages;

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
        foreach (var item in messages.Select(e => e.Value).Cast<RawContentBlockDeltaEvent>().Select(e => e.Delta))
        {
            item.Switch(
                e => aggregation.Text += e.Text,
                e => aggregation.PartialJson += e.PartialJSON,
                e => aggregation.Citations.Add(e.Citation),
                e => aggregation.Thinking += e.Thinking,
                e => aggregation.Signature += e.Signature);
        }

        return aggregation;
    }

    protected override FilterResult Filter(RawMessageStreamEvent message) => message.Value switch
    {
        RawContentBlockStartEvent _ => FilterResult.StartMessage,
        RawContentBlockStopEvent _ => FilterResult.EndMessage,
        RawContentBlockDeltaEvent _ => FilterResult.Content,
        RawMessageStopEvent _ => FilterResult.EndMessage,
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
    
    /// <summary>
    /// Gets or sets the aggregated Signature from an <see cref="SignatureDelta"/>
    /// </summary>
    public string? Signature { get; internal set; }    
}
