using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Services.Messages;

/// <summary>
/// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
/// </summary>
public sealed class BetaMessageContentAggregator
    : SseAggregator<BetaRawMessageStreamEvent, BetaMessage>
{
    /// <summary>
    /// Creates a new instance of the <see cref="BetaMessageContentAggregator"/>.
    /// </summary>
    /// <param name="messages">The async enumerable representing a stream of messages.</param>
    public BetaMessageContentAggregator(IAsyncEnumerable<BetaRawMessageStreamEvent> messages)
        : base(messages) { }

    protected override BetaMessage GetResult(
        IReadOnlyDictionary<FilterResult, IList<BetaRawMessageStreamEvent>> messages
    )
    {
        var content = messages[FilterResult.Content].GroupBy(e => e.Index);

        var startMessage = messages[FilterResult.StartMessage]
            .Select(e => (BetaRawMessageStartEvent)e.Value!)
            .Single();
        var endMessage = messages[FilterResult.EndMessage]
            .Select(e => (BetaRawMessageStopEvent)e.Value!)
            .Single();

        var contentBlocks = new List<BetaContentBlock>();
        foreach (var item in messages.OrderBy(e => e.Key))
        {
            var blockContents = item.Value;
            var startContent = blockContents
                .Select(e => e.Value)
                .OfType<BetaRawContentBlockStartEvent>()
                .Single();
            var blockContent = blockContents
                .Select(e => e.Value)
                .OfType<BetaRawContentBlockDelta>()
                .ToArray();
            var endContent = blockContents
                .Select(e => e.Value)
                .OfType<BetaRawContentBlockStartEvent>()
                .Single();

            var contentBlock = startContent.ContentBlock;
            contentBlocks.Add(MergeBlock(contentBlock, blockContent));
        }

        return new()
        {
            Content = [.. contentBlocks],
            Container = startMessage.Message.Container,
            ContextManagement = startMessage.Message.ContextManagement,
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopReason = startMessage.Message.StopReason,
            StopSequence = startMessage.Message.StopSequence,
            Usage = startMessage.Message.Usage,
        };
    }

    private static BetaContentBlock MergeBlock(
        ContentBlock contentBlock,
        IList<BetaRawContentBlockDelta> blockContents
    )
    {
        BetaContentBlock resultBlock = null!;

        string StringJoinHelper<T>(IEnumerable<T> sources, Func<T, string> expression)
        {
            return string.Join(null, sources.Select(expression));
        }

        IReadOnlyDictionary<TDicKey, TDicValue> DictionaryJoinHelper<TValue, TDicKey, TDicValue>(
            IEnumerable<TValue> sources,
            Func<TValue, IEnumerable<KeyValuePair<TDicKey, TDicValue>>> expression
        )
            where TDicValue : notnull
            where TDicKey : notnull
        {
            return sources.SelectMany(expression).ToDictionary(e => e.Key, e => e.Value);
        }

        void With<T>(T source, Func<IEnumerable<T>, BetaContentBlock> factory)
        {
            resultBlock = factory([source, .. blockContents.Select(e => e.Value).OfType<T>()]);
        }

        void Single<T>(T item)
        {
            resultBlock = (
                blockContents.Select(e => e.Value).OfType<T>().Single() as BetaContentBlock
            )!;
        }

        contentBlock.Switch(
            e =>
                With(
                    e,
                    blocks => new BetaTextBlock()
                    {
                        Text = StringJoinHelper(blocks, e => e.Text),
                        Citations = [.. blocks.SelectMany(f => f.Citations!)],
                    }
                ),
            e =>
                With(
                    e,
                    blocks => new BetaThinkingBlock()
                    {
                        Signature = StringJoinHelper(blocks, e => e.Signature),
                        Thinking = StringJoinHelper(blocks, e => e.Thinking),
                    }
                ),
            e =>
                With(
                    e,
                    blocks => new BetaRedactedThinkingBlock()
                    {
                        Data = StringJoinHelper(blocks, e => e.Data),
                    }
                ),
            e =>
                With(
                    e,
                    blocks => new BetaToolUseBlock()
                    {
                        ID = StringJoinHelper(blocks, e => e.ID),
                        Name = StringJoinHelper(blocks, e => e.Name),
                        Input = DictionaryJoinHelper(blocks, e => e.Input),
                    }
                ),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e)
        );

        return resultBlock;
    }

    protected override FilterResult Filter(BetaRawMessageStreamEvent message) =>
        message.Value switch
        {
            BetaRawContentBlockStartEvent _ => FilterResult.Content,
            BetaRawContentBlockStopEvent _ => FilterResult.Content,
            BetaRawContentBlockDeltaEvent _ => FilterResult.Content,
            BetaRawMessageDeltaEvent => FilterResult.Content,
            BetaRawMessageStartEvent => FilterResult.StartMessage,
            BetaRawMessageStopEvent _ => FilterResult.EndMessage,
            _ => FilterResult.Ignore,
        };
}
