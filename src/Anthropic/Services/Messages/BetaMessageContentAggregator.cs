using System.Collections.Generic;
using System.Linq;
using Anthropic.Client.Models.Beta.Messages;
using Anthropic.Client.Models.Beta.Messages.BetaCitationsDeltaProperties;
using RawMessageStreamEventVariants = Anthropic.Client.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

namespace Anthropic.Client.Services.Messages;

/// <summary>
/// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
/// </summary>
public class BetaMessageContentAggregator : SseAggregator<BetaRawMessageStreamEvent, BetaMessageAggregationResult>
{
    /// <summary>
    /// Creates a new instance of the <see cref="BetaMessageContentAggregator"/>.
    /// </summary>
    /// <param name="messages">The async enumerable representing a stream of messages.</param>
    public BetaMessageContentAggregator(IAsyncEnumerable<BetaRawMessageStreamEvent> messages) : base(messages)
    {
    }

    protected override BetaMessageAggregationResult GetResult(IReadOnlyCollection<BetaRawMessageStreamEvent> messages)
    {
        var aggregation = new BetaMessageAggregationResult();
        foreach (var item in messages.Cast<RawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent>().Select(e => e.Value.Delta))
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

    protected override FilterResult Filter(BetaRawMessageStreamEvent message) => message switch
    {
        RawMessageStreamEventVariants::BetaRawContentBlockStartEvent _ => FilterResult.StartMessage,
        RawMessageStreamEventVariants::BetaRawContentBlockStopEvent _ => FilterResult.EndMessage,
        RawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent _ => FilterResult.Content,
        RawMessageStreamEventVariants::BetaRawMessageStopEvent _ => FilterResult.EndMessage,
        _ => FilterResult.Ignore            
    };
}

/// <summary>
/// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
/// </summary>
public class BetaMessageAggregationResult
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
}
