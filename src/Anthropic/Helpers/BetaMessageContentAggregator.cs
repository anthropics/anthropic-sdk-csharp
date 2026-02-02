using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// The aggregation model for a stream of <see cref="BetaRawContentBlockDeltaEvent"/>
/// </summary>
public sealed class BetaMessageContentAggregator
    : SseAggregator<BetaRawMessageStreamEvent, BetaMessage>
{
    protected override BetaMessage GetResult(
        IReadOnlyDictionary<FilterResult, IList<BetaRawMessageStreamEvent>> messages
    )
    {
        var content = messages[FilterResult.Content].GroupBy(e => e.Index);

        var startMessage =
            messages[FilterResult.StartMessage]
                .Select(e => e.Value)
                .OfType<BetaRawMessageStartEvent>()
                .FirstOrDefault()
            ?? throw new AnthropicInvalidDataException("start message not yet received");
        var endMessage =
            messages[FilterResult.EndMessage]
                .Select(e => e.Value)
                .OfType<BetaRawMessageStopEvent>()
                .FirstOrDefault()
            ?? throw new AnthropicInvalidDataException("stop message not yet received");

        var contentBlocks = new List<BetaContentBlock>();
        foreach (var item in content)
        {
            var startContent =
                item.Select(e => e.Value).OfType<BetaRawContentBlockStartEvent>().FirstOrDefault()
                ?? throw new AnthropicInvalidDataException(
                    "start content message not yet received"
                );
            var blockContent = item.Select(e => e.Value)
                .OfType<BetaRawContentBlockDeltaEvent>()
                .ToArray();

            var contentBlock = startContent.ContentBlock;
            contentBlocks.Add(MergeBlock(contentBlock, blockContent.Select(e => e.Delta)));
        }

        var stopSequence = startMessage.Message.StopSequence;
        var stopReason = startMessage.Message.StopReason;
        var container = startMessage.Message.Container;
        var usage = startMessage.Message.Usage;

        var deltas = (messages.GetValueOrDefault(FilterResult.Delta) ?? [])
            .Select(e => e.Value)
            .OfType<BetaRawMessageDeltaEvent>();
        foreach (var delta in deltas)
        {
            stopReason = delta.Delta.StopReason;
            stopSequence = delta.Delta.StopSequence;

            if (delta.Delta.Container != null)
            {
                container = delta.Delta.Container;
            }

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

        return new()
        {
            Content = [.. contentBlocks],
            Container = container,
            ContextManagement = startMessage.Message.ContextManagement,
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopReason = stopReason,
            StopSequence = stopSequence,
            Usage = usage,
        };
    }

    private static BetaContentBlock MergeBlock(
        ContentBlock contentBlock,
        IEnumerable<BetaRawContentBlockDelta> blockContents
    )
    {
        BetaContentBlock? resultBlock = null;

        string StringJoinHelper<T>(
            string source,
            IEnumerable<T> sources,
            Func<T, string> expression
        )
        {
            return string.Join(null, (string[])[source, .. sources.Select(expression)]);
        }

        void As<TDelta>(Func<IEnumerable<TDelta>, BetaContentBlock> factory)
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
                blockContents.Select(e => e.Value).OfType<T>().Single() as BetaContentBlock
            );
        }

        contentBlock.Switch(
            textBlock =>
                As<BetaTextDelta>(blocks => new BetaTextBlock()
                {
                    Text = StringJoinHelper(textBlock.Text, blocks, e => e.Text),
                    Citations =
                    [
                        .. (textBlock.Citations ?? []),
                        .. Of<BetaCitationsDelta>()
                            .Select(e =>
                                e.Citation.Match<BetaTextCitation>(
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
                As<BetaThinkingDelta>(blocks => new BetaThinkingBlock()
                {
                    Signature = StringJoinHelper(
                        thinkingBlock.Signature,
                        Of<BetaSignatureDelta>(),
                        e => e.Signature
                    ),
                    Thinking = StringJoinHelper(thinkingBlock.Thinking, blocks, e => e.Thinking),
                }),
            e => Single(e),
            e => Single(e),
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

        return resultBlock ?? throw new AnthropicInvalidDataException("Missing result block");
    }

    protected override FilterResult Filter(BetaRawMessageStreamEvent message) =>
        message.Value switch
        {
            BetaRawContentBlockStartEvent _ => FilterResult.Content,
            BetaRawContentBlockStopEvent _ => FilterResult.Content,
            BetaRawContentBlockDeltaEvent _ => FilterResult.Content,
            BetaRawMessageDeltaEvent => FilterResult.Delta,
            BetaRawMessageStartEvent => FilterResult.StartMessage,
            BetaRawMessageStopEvent _ => FilterResult.EndMessage,
            _ => FilterResult.Ignore,
        };
}
