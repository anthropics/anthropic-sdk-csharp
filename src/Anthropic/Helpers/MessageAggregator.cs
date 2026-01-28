using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Messages;
using Anthropic.Services;

namespace Anthropic.Helpers;

/// <summary>
/// An implementation of the <see cref="SseAggregator{TMessage, TResult}"/> for aggregating BlockDeltaEvents from the <see cref="IMessageService.CreateStreaming(MessageCreateParams)"/> method.
/// </summary>
public sealed class MessageContentAggregator : SseAggregator<RawMessageStreamEvent, Message>
{
    protected override Message GetResult(
        IReadOnlyDictionary<FilterResult, IList<RawMessageStreamEvent>> messages
    )
    {
        var content = messages[FilterResult.Content].GroupBy(e => e.Index);

        var startMessage =
            messages[FilterResult.StartMessage]
                .Select(e => e.Value!)
                .OfType<RawMessageStartEvent>()
                .SingleOrDefault()
            ?? throw new InvalidOperationException(
                $"Expected to find exactly one {nameof(RawMessageStartEvent)} but found either none or more then one."
            );

        var contentBlocks = new List<ContentBlock>();
        foreach (var item in content)
        {
            var startContent = item.Select(e => e.Value)
                .OfType<RawContentBlockStartEvent>()
                .Single();
            var blockContent = item.Select(e => e.Value)
                .OfType<RawContentBlockDeltaEvent>()
                .ToArray();

            var contentBlock = startContent.ContentBlock;
            contentBlocks.Add(MergeBlock(contentBlock, [.. blockContent.Select(e => e.Delta)]));
        }

        return new()
        {
            Content = [.. contentBlocks],
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopReason = startMessage.Message.StopReason,
            StopSequence = startMessage.Message.StopSequence,
            Usage = startMessage.Message.Usage,
        };
    }

    private static ContentBlock MergeBlock(
        RawContentBlockStartEventContentBlock contentBlock,
        IEnumerable<RawContentBlockDelta> blockContents
    )
    {
        ContentBlock resultBlock = null!;

        string StringJoinHelper<T>(
            string source,
            IEnumerable<T> sources,
            Func<T, string> expression
        )
        {
            return string.Join(null, (string[])[source, .. sources.Select(expression)]);
        }

        void As<TDelta>(Func<IEnumerable<TDelta>, ContentBlock> factory)
        {
            // those blocks are delta variants not the source block
            // e.g TextBlock and TextDelta
            resultBlock = factory([.. blockContents.Select(e => e.Value).OfType<TDelta>()]);
        }

        IEnumerable<TDelta> Of<TDelta>()
        {
            return blockContents.Select(e => e.Value).OfType<TDelta>();
        }

        void Single<T>(T item)
        {
            resultBlock = (
                blockContents.Select(e => e.Value).OfType<T>().Single() as ContentBlock
            )!;
        }

        contentBlock.Switch(
            textBlock =>
                As<TextDelta>(blocks => new TextBlock()
                {
                    Text = StringJoinHelper(textBlock.Text, blocks, e => e.Text),
                    Citations =
                    [
                        .. textBlock.Citations!,
                        .. Of<CitationsDelta>()
                            .Select(e =>
                                e.Citation.Match<TextCitation>(
                                    f => f,
                                    f => f,
                                    f => f,
                                    f => f,
                                    f => f
                                )
                            ),
                    ],
                }),
            thinkingBlock =>
                As<ThinkingDelta>(blocks => new ThinkingBlock()
                {
                    Signature = StringJoinHelper(
                        thinkingBlock.Signature,
                        Of<SignatureDelta>(),
                        e => e.Signature
                    ),
                    Thinking = StringJoinHelper(thinkingBlock.Thinking, blocks, e => e.Thinking),
                }),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e)
        );

        return resultBlock;
    }

    protected override FilterResult Filter(RawMessageStreamEvent message) =>
        message.Value switch
        {
            RawContentBlockStartEvent _ => FilterResult.Content,
            RawContentBlockStopEvent _ => FilterResult.Content,
            RawContentBlockDeltaEvent _ => FilterResult.Content,
            RawMessageDeltaEvent => FilterResult.Content,
            RawMessageStartEvent => FilterResult.StartMessage,
            RawMessageStopEvent _ => FilterResult.EndMessage,
            _ => FilterResult.Ignore,
        };
}
