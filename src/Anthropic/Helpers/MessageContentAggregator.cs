using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Exceptions;
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

        var content = messages[FilterResult.Content].GroupBy(e =>
            e.Index
        );

        var startMessage =
            messages[FilterResult.StartMessage]
                .Select(e => e.Value)
                .OfType<RawMessageStartEvent>()
                .FirstOrDefault()
            ?? throw new AnthropicInvalidDataException("start message not yet received");

        var endMessageCount = messages[FilterResult.EndMessage].Count;
        if (endMessageCount == 0)
        {
            throw new AnthropicInvalidDataException("stop message not yet received");
        }

        var contentBlocks = new List<ContentBlock>();
        foreach (var item in content)
        {
            var startContent =
                item.Select(e => e.Value).OfType<RawContentBlockStartEvent>().FirstOrDefault()
                ?? throw new AnthropicInvalidDataException(
                    "start content message not yet received"
                );
            var blockContent = item.Select(e => e.Value)
                .OfType<RawContentBlockDeltaEvent>()
                .ToArray();

            var contentBlock = startContent.ContentBlock;
            contentBlocks.Add(MergeBlock(contentBlock, [.. blockContent.Select(e => e.Delta)]));
        }

        var stopSequence = startMessage.Message.StopSequence;
        var stopReason = startMessage.Message.StopReason;
        var usage = startMessage.Message.Usage;

        if (messages.TryGetValue(FilterResult.Delta, out var deltaEvents))
        {
            var deltas = deltaEvents
                .Select(e => e.Value)
                .OfType<RawMessageDeltaEvent>();
            foreach (var delta in deltas)
            {
                stopReason = delta.Delta.StopReason;
                stopSequence = delta.Delta.StopSequence;

                usage = usage with { OutputTokens = delta.Usage.OutputTokens };
                if (delta.Usage.InputTokens != null)
                {
                    usage = usage with { InputTokens = delta.Usage.InputTokens.Value };
                }
                if (delta.Usage.CacheCreationInputTokens != null)
                {
                    usage = usage with
                    {
                        CacheCreationInputTokens = delta.Usage.CacheCreationInputTokens,
                    };
                }
                if (delta.Usage.CacheReadInputTokens != null)
                {
                    usage = usage with { CacheReadInputTokens = delta.Usage.CacheReadInputTokens };
                }
                if (delta.Usage.ServerToolUse != null)
                {
                    usage = usage with { ServerToolUse = delta.Usage.ServerToolUse };
                }
            }
        }

        return new()
        {
            Content = [.. contentBlocks],
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopReason = stopReason,
            StopSequence = stopSequence,
            Usage = usage,
        };
    }

    private static ContentBlock MergeBlock(
        RawContentBlockStartEventContentBlock contentBlock,
        IEnumerable<RawContentBlockDelta> blockContents
    )
    {
        ContentBlock? resultBlock = null;

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
            resultBlock =
                (blockContents.Select(e => e.Value).OfType<T>().Single() as ContentBlock)
                ?? throw new AnthropicInvalidDataException(
                    "Could not convert block to content block"
                );
        }

        contentBlock.Switch(
            textBlock =>
                As<TextDelta>(blocks => new TextBlock()
                {
                    Text = StringJoinHelper(textBlock.Text, blocks, e => e.Text),
                    Citations =
                    [
                        .. (textBlock.Citations ?? []),
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

        return resultBlock ?? throw new AnthropicInvalidDataException("Missing result block");
    }

    protected override FilterResult Filter(RawMessageStreamEvent message) =>
        message.Value switch
        {
            RawContentBlockStartEvent _ => FilterResult.Content,
            RawContentBlockStopEvent _ => FilterResult.Content,
            RawContentBlockDeltaEvent _ => FilterResult.Content,
            RawMessageDeltaEvent => FilterResult.Delta,
            RawMessageStartEvent => FilterResult.StartMessage,
            RawMessageStopEvent _ => FilterResult.EndMessage,
            _ => FilterResult.Ignore,
        };
}
