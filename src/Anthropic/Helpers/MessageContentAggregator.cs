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
        var container = startMessage.Message.Container;
        var usage = startMessage.Message.Usage;

        // message_delta usage counters are cumulative whole-message totals, so overwrite
        // rather than add; the optional ones are omitted when they don't apply and must
        // then leave the message_start values in place.
        if (messages.TryGetValue(FilterResult.Delta, out var deltaEvents))
        {
            var deltas = deltaEvents.Select(e => e.Value).OfType<RawMessageDeltaEvent>();
            foreach (var delta in deltas)
            {
                stopReason = delta.Delta.StopReason;
                stopSequence = delta.Delta.StopSequence;
                stopDetails = delta.Delta.StopDetails;

                // The container only ever arrives on message_delta, and only when a
                // container ran, so keep whatever we have when the key is absent.
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
                if (delta.Usage.OutputTokensDetails != null)
                {
                    usage = usage with { OutputTokensDetails = delta.Usage.OutputTokensDetails };
                }
            }
        }

        // Start from the message_start message so fields that are never re-sent
        // (service_tier, cache_creation, inference_geo, ...) survive untouched.
        return startMessage.Message with
        {
            Container = container,
            Content = [.. contentBlocks],
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

        // Start from the wire block so `citations` stays exactly as the server sent it (usually
        // absent) unless citation deltas arrive; a re-sent turn then matches the original bytes.
        TextBlock MergeText(TextBlock start)
        {
            var merged = start with
            {
                Text = StringJoinHelper(start.Text, Of<TextDelta>(), e => e.Text),
            };
            var citations = Of<CitationsDelta>()
                .Select(e => e.Citation.Match<TextCitation>(f => f, f => f, f => f, f => f, f => f))
                .ToList();
            return citations.Count == 0
                ? merged
                : merged with
                {
                    Citations = [.. (start.Citations ?? []), .. citations],
                };
        }

        // Only the variants below carry deltas. Every other block type — including ones this SDK
        // version doesn't model yet — arrives complete in its content_block_start event, so its
        // wire JSON passes through unchanged.
        return contentBlock.Value switch
        {
            TextBlock textBlock => MergeText(textBlock),
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
