using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Anthropic.Services;

namespace Anthropic.Helpers;

/// <summary>
/// An implementation of the <see cref="SseAggregator{TMessage, TResult}"/> for aggregating BlockDeltaEvents from the <see cref="IMessageService.CreateStreaming"/> method.
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
        var stopDetails = startMessage.Message.StopDetails;
        var usage = startMessage.Message.Usage;

        if (messages.TryGetValue(FilterResult.Delta, out var deltaEvents))
        {
            var deltas = deltaEvents.Select(e => e.Value).OfType<RawMessageDeltaEvent>();
            foreach (var delta in deltas)
            {
                stopReason = delta.Delta.StopReason;
                stopSequence = delta.Delta.StopSequence;
                stopDetails = delta.Delta.StopDetails;

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
            Container = null,
            Content = [.. contentBlocks],
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopDetails = stopDetails,
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
        string StringJoinHelper<T>(
            string source,
            IEnumerable<T> sources,
            Func<T, string> expression
        )
        {
            return string.Join(null, (string[])[source, .. sources.Select(expression)]);
        }

        IEnumerable<TDelta> Of<TDelta>()
        {
            return blockContents.Select(e => e.Value).OfType<TDelta>();
        }

        IEnumerable<string> PartialJsons()
        {
            return Of<InputJsonDelta>().Select(d => d.PartialJson);
        }

        // Only the variants below carry deltas. Every other block type — including ones this SDK
        // version doesn't model yet — arrives complete in its content_block_start event, so its
        // wire JSON passes through unchanged.
        return contentBlock.Value switch
        {
            TextBlock textBlock => new TextBlock()
            {
                Text = StringJoinHelper(textBlock.Text, Of<TextDelta>(), e => e.Text),
                Citations =
                [
                    .. (textBlock.Citations ?? []),
                    .. Of<CitationsDelta>()
                        .Select(e =>
                            e.Citation.Match<TextCitation>(f => f, f => f, f => f, f => f, f => f)
                        ),
                ],
            },
            ThinkingBlock thinkingBlock => new ThinkingBlock()
            {
                Signature = StringJoinHelper(
                    thinkingBlock.Signature,
                    Of<SignatureDelta>(),
                    e => e.Signature
                ),
                Thinking = StringJoinHelper(
                    thinkingBlock.Thinking,
                    Of<ThinkingDelta>(),
                    e => e.Thinking
                ),
            },
            ToolUseBlock block => StreamedToolInput.WithMergedInput(
                block,
                PartialJsons(),
                ToolUseBlock.FromRawUnchecked
            ),
            ServerToolUseBlock block => StreamedToolInput.WithMergedInput(
                block,
                PartialJsons(),
                ServerToolUseBlock.FromRawUnchecked
            ),
            _ => JsonSerializer.Deserialize<ContentBlock>(
                contentBlock.Json,
                ModelBase.SerializerOptions
            ) ?? throw new AnthropicInvalidDataException("content_block cannot be null"),
        };
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
