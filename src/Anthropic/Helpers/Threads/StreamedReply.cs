using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Threads;

/// <summary>The events of a streamed reply from <c>message_start</c> on.</summary>
internal sealed class StreamedReply(BetaRawMessageStartEvent start)
{
    readonly List<BetaRawMessageStreamEvent> _content = [];
    readonly List<BetaRawMessageDeltaEvent> _deltas = [];

    // The content block that has started and not finished.
    BetaRawContentBlockStartEvent? _open;

    /// <summary>Whether the reply stopped with a refusal, which shows before <c>message_stop</c>.</summary>
    internal bool IsRefusal =>
        _deltas.Any(delta => delta.Delta.StopReason?.Value() == BetaStopReason.Refusal);

    /// <summary>Returns the whole reply when the event is its <c>message_stop</c>.</summary>
    internal BetaMessage? Add(BetaRawMessageStreamEvent streamEvent)
    {
        switch (streamEvent.Value)
        {
            case BetaRawMessageDeltaEvent delta:
                _deltas.Add(delta);
                break;
            case BetaRawMessageStopEvent:
                return BetaMessageContentAggregator.Build(start, _content, _deltas);
            case BetaRawContentBlockStartEvent blockStart:
                _open = blockStart;
                _content.Add(streamEvent);
                break;
            case BetaRawContentBlockDeltaEvent:
                _content.Add(streamEvent);
                break;
            case BetaRawContentBlockStopEvent:
                _open = null;
                _content.Add(streamEvent);
                break;
        }

        return null;
    }

    /// <summary>
    /// The part worth keeping when the stream ended early: the content blocks that finished, and
    /// the text of a text block that did not. Any other unfinished block is left out, because its
    /// input or signature is incomplete. <c>null</c> when nothing is left.
    /// </summary>
    internal BetaMessage? Partial()
    {
        var incomplete =
            _open?.ContentBlock.TryPickBetaText(out _) == false ? _open.Index : (long?)null;
        var reply = BetaMessageContentAggregator.Build(
            start,
            _content.Where(streamEvent => streamEvent.Index != incomplete),
            _deltas
        );
        var content = reply.Content.ToList();
        var endsWithOpenText = _open != null && incomplete == null;
        if (endsWithOpenText && content.Last().Value is BetaTextBlock { Text: "" })
        {
            content.RemoveAt(content.Count - 1);
        }
        return content.Count == 0 ? null : reply with { Content = content };
    }
}
