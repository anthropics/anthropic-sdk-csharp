using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Anthropic.Core;
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
        var model = startMessage.Message.Model;
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
            var mergedBlock = MergeBlock(contentBlock, blockContent.Select(e => e.Delta));
            contentBlocks.Add(mergedBlock);

            // The final hop's fallback block names the model that served the response —
            // keeps the aggregated message consistent with the relabeled non-streaming message.
            if (mergedBlock.Value is BetaFallbackBlock fallbackBlock)
            {
                model = fallbackBlock.To.Model;
            }
        }

        var stopSequence = startMessage.Message.StopSequence;
        var stopReason = startMessage.Message.StopReason;
        var stopDetails = startMessage.Message.StopDetails;
        var container = startMessage.Message.Container;
        var contextManagement = startMessage.Message.ContextManagement;
        var usage = startMessage.Message.Usage;

        // message_delta usage counters are cumulative whole-message totals, so overwrite
        // rather than add; the optional ones are omitted when they don't apply and must
        // then leave the message_start values in place.
        if (messages.TryGetValue(FilterResult.Delta, out var deltaEvents))
        {
            var deltas = deltaEvents.Select(e => e.Value).OfType<BetaRawMessageDeltaEvent>();

            foreach (var delta in deltas ?? [])
            {
                stopReason = delta.Delta.StopReason;
                stopSequence = delta.Delta.StopSequence;
                stopDetails = delta.Delta.StopDetails;

                if (delta.Delta.Container != null)
                {
                    container = delta.Delta.Container;
                }

                // context_management is a sibling of delta/usage on the event, and is
                // only ever sent here — message_start never carries it.
                if (delta.ContextManagement != null)
                {
                    contextManagement = delta.ContextManagement;
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
                if (delta.Usage.FallbackCredit != null)
                {
                    usage = usage with { FallbackCredit = delta.Usage.FallbackCredit };
                }
                // The per-hop usage chain (server-side fallbacks or the fallback handler's
                // splice) is a cumulative ledger arriving on the terminal message_delta;
                // the latest delta supersedes prior values.
                if (delta.Usage.Iterations != null)
                {
                    usage = usage with
                    {
                        Iterations =
                        [
                            .. delta.Usage.Iterations.Select(static it =>
                                it.Value switch
                                {
                                    BetaMessageIterationUsage v => new BetaUsageIteration(v),
                                    BetaCompactionIterationUsage v => new BetaUsageIteration(v),
                                    BetaAdvisorMessageIterationUsage v => new BetaUsageIteration(v),
                                    BetaFallbackMessageIterationUsage v => new BetaUsageIteration(
                                        v
                                    ),
                                    _ => new BetaUsageIteration(it.Json),
                                }
                            ),
                        ],
                    };
                }
            }
        }

        // Start from the message_start message so fields that are never re-sent
        // (service_tier, cache_creation, inference_geo, speed, ...) survive untouched.
        return startMessage.Message with
        {
            Content = [.. contentBlocks],
            Container = container,
            ContextManagement = contextManagement,
            Model = model,
            StopDetails = stopDetails,
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
            return Of<BetaInputJsonDelta>().Select(d => d.PartialJson);
        }

        // Merge the content/encrypted_content carried by compaction_delta events; the start block
        // leaves both null until the deltas arrive.
        string? MergeCompaction(
            string? seed,
            Func<BetaCompactionContentBlockDelta, string?> selector
        )
        {
            var parts = new List<string>();
            if (seed != null)
            {
                parts.Add(seed);
            }
            foreach (var delta in Of<BetaCompactionContentBlockDelta>())
            {
                var value = selector(delta);
                if (value != null)
                {
                    parts.Add(value);
                }
            }
            return parts.Count == 0 ? null : string.Concat(parts);
        }

        // Only the variants below carry deltas. Every other block type — including ones this SDK
        // version doesn't model yet — arrives complete in its content_block_start event, so its
        // wire JSON passes through unchanged.
        return contentBlock.Value switch
        {
            BetaTextBlock textBlock => new BetaTextBlock()
            {
                Text = StringJoinHelper(textBlock.Text, Of<BetaTextDelta>(), e => e.Text),
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
            },
            BetaThinkingBlock thinkingBlock => new BetaThinkingBlock()
            {
                Signature = StringJoinHelper(
                    thinkingBlock.Signature,
                    Of<BetaSignatureDelta>(),
                    e => e.Signature
                ),
                Thinking = StringJoinHelper(
                    thinkingBlock.Thinking,
                    Of<BetaThinkingDelta>(),
                    e => e.Thinking
                ),
            },
            BetaToolUseBlock block => StreamedToolInput.WithMergedInput(
                block,
                PartialJsons(),
                BetaToolUseBlock.FromRawUnchecked
            ),
            BetaServerToolUseBlock block => StreamedToolInput.WithMergedInput(
                block,
                PartialJsons(),
                BetaServerToolUseBlock.FromRawUnchecked
            ),
            BetaMcpToolUseBlock block => StreamedToolInput.WithMergedInput(
                block,
                PartialJsons(),
                BetaMcpToolUseBlock.FromRawUnchecked
            ),
            BetaCompactionBlock compactionBlock => new BetaCompactionBlock()
            {
                Content = MergeCompaction(compactionBlock.Content, d => d.Content),
                EncryptedContent = MergeCompaction(
                    compactionBlock.EncryptedContent,
                    d => d.EncryptedContent
                ),
            },
            _ => JsonSerializer.Deserialize<BetaContentBlock>(
                contentBlock.Json,
                ModelBase.SerializerOptions
            ) ?? throw new AnthropicInvalidDataException("content_block cannot be null"),
        };
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
