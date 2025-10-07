using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.CitationsDeltaProperties;
using RawMessageStreamEventVariants = Anthropic.Client.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Client.Services.Messages;

public class MessageAggregator : SseAggregator<RawMessageStreamEvent, MessageAggregationResult>
{
    public MessageAggregator(IAsyncEnumerable<RawMessageStreamEvent> messages) : base(messages)
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

    protected override bool Filter(RawMessageStreamEvent message)
    {
        return message is RawMessageStreamEventVariants::RawContentBlockDeltaEvent;
    }
}

public class MessageAggregationResult
{
    public string? Text { get; set; }
    public string? PartialJson { get; set; }
    public IList<Citation> Citations { get; set; } = [];
    public string? Thinking { get; internal set; }
}
