using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        var usage = startMessage.Message.Usage;

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
                // The per-hop usage chain (server-side fallbacks or the fallback handler's
                // splice) is a cumulative ledger arriving on the terminal message_delta;
                // the latest delta supersedes prior values.
                if (delta.Usage.Iterations != null)
                {
                    // BetaMessageDeltaUsage.Iterations and BetaUsage.Iterations are the
                    // same union schema but the generator currently inlines them under two
                    // distinct C# types (Iteration / BetaUsageIteration); rewrap via the
                    // raw JSON until the shared type is restored upstream.
                    usage = usage with
                    {
                        Iterations = delta
                            .Usage.Iterations.Select(i => new BetaUsageIteration(i.Json))
                            .ToList(),
                    };
                }
            }
        }

        return new()
        {
            Content = [.. contentBlocks],
            Container = container,
            ContextManagement = startMessage.Message.ContextManagement,
            Diagnostics = startMessage.Message.Diagnostics,
            ID = startMessage.Message.ID,
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
            toolUseBlock =>
            {
                // Reconstruct the tool_use input from input_json_delta events.
                var partialJsons = Of<BetaInputJsonDelta>().Select(d => d.PartialJson);
                var mergedJson = string.Concat(partialJsons);
                IReadOnlyDictionary<string, JsonElement> input;
                if (string.IsNullOrEmpty(mergedJson))
                {
                    input = toolUseBlock.Input;
                }
                else
                {
                    var parsed = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                        mergedJson
                    );
                    input =
                        parsed != null
                            ? FrozenDictionary.ToFrozenDictionary(parsed)
                            : toolUseBlock.Input;
                }
                resultBlock = new BetaToolUseBlock()
                {
                    ID = toolUseBlock.ID,
                    Name = toolUseBlock.Name,
                    Input = input,
                };
            },
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
            compactionBlock =>
            {
                // Merge the content/encrypted_content carried by compaction_delta events; the
                // start block leaves both null until the deltas arrive.
                var deltas = Of<BetaCompactionContentBlockDelta>();
                string? Merge(string? seed, Func<BetaCompactionContentBlockDelta, string?> selector)
                {
                    var parts = new List<string>();
                    if (seed != null)
                    {
                        parts.Add(seed);
                    }
                    foreach (var delta in deltas)
                    {
                        var value = selector(delta);
                        if (value != null)
                        {
                            parts.Add(value);
                        }
                    }
                    return parts.Count == 0 ? null : string.Concat(parts);
                }
                resultBlock = new BetaCompactionBlock()
                {
                    Content = Merge(compactionBlock.Content, d => d.Content),
                    EncryptedContent = Merge(
                        compactionBlock.EncryptedContent,
                        d => d.EncryptedContent
                    ),
                };
            },
            fallbackBlock =>
            {
                // Fallback blocks arrive complete in the content_block_start event and
                // have no delta variants, so pass the start block through unchanged.
                resultBlock = fallbackBlock;
            }
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
