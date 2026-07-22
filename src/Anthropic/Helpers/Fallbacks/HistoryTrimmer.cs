using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// Removes content the server would reject from message history replayed from an earlier
/// fallback turn (see <see cref="BetaRefusalFallbackHandler"/>).
/// </summary>
internal static class HistoryTrimmer
{
    /// <summary>
    /// Trims each assistant turn that contains a <c>fallback</c> block: the fallback block itself
    /// (it only parses under the server-side <c>fallbacks</c> beta, which the handler never
    /// sends), and everything before it that belongs to the model that refused: thinking,
    /// connector text, and tool calls that never got a result. Blocks after the fallback block
    /// are what the serving model produced and stay as written; a turn left empty is dropped
    /// whole. Returns whether anything changed, so an untouched body keeps its original bytes.
    ///
    /// <para>Blocks are classified through <see cref="BetaContentBlockParam"/>, but kept blocks
    /// always emit their original nodes; the deserialized models are never written back.</para>
    /// </summary>
    public static bool TrimFallbackTurns(JsonObject body)
    {
        if (body["messages"] is not JsonArray messages)
        {
            return false;
        }

        // Tool calls whose result appears anywhere in the history are kept.
        HashSet<string> resolved = [];
        foreach (var message in messages)
        {
            if ((message as JsonObject)?["content"] is not JsonArray content)
            {
                continue;
            }
            foreach (var block in content)
            {
                if (ParseBlock(block) is { } parsed && ResolvedToolUseID(parsed) is { } toolUseId)
                {
                    resolved.Add(toolUseId);
                }
            }
        }

        var changed = false;
        for (var i = messages.Count - 1; i >= 0; i--)
        {
            if (
                messages[i] is not JsonObject message
                || JsonNodes.GetString(message["role"]) != "assistant"
                || message["content"] is not JsonArray content
            )
            {
                continue;
            }
            var parsed = new BetaContentBlockParam?[content.Count];
            var lastFallback = -1;
            for (var j = 0; j < content.Count; j++)
            {
                parsed[j] = ParseBlock(content[j]);
                if (parsed[j] is { } block && block.TryPickFallback(out _))
                {
                    lastFallback = j;
                }
            }
            if (lastFallback == -1)
            {
                continue;
            }
            for (var j = content.Count - 1; j >= 0; j--)
            {
                if (parsed[j] is not { } block)
                {
                    continue;
                }
                if (
                    block.TryPickFallback(out _)
                    || (j < lastFallback && IsRefusedAttempt(block, resolved))
                )
                {
                    content.RemoveAt(j);
                    changed = true;
                }
            }
            if (content.Count == 0)
            {
                messages.RemoveAt(i);
            }
        }
        return changed;
    }

    /// <summary>
    /// Reads a content element into the request-side block union for classification, or
    /// <c>null</c> if it isn't an object. An unrecognized block type still parses, with a null
    /// <see cref="BetaContentBlockParam.Value"/> and the element preserved as
    /// <see cref="BetaContentBlockParam.Json"/>.
    /// </summary>
    static BetaContentBlockParam? ParseBlock(JsonNode? block) =>
        block is JsonObject
            ? JsonSerializer.Deserialize<BetaContentBlockParam>(block, ModelBase.SerializerOptions)
            : null;

    /// <summary>
    /// Whether a block sitting before the transition belongs to the refused model's attempt and must
    /// be trimmed: thinking, connector text, or a tool call that never got a result. Unknown
    /// variants classify as keep, since we never drop a block type this SDK version doesn't
    /// recognize; hence TryPick chains rather than <c>Switch</c>/<c>Match</c>, which throw on
    /// them.
    /// </summary>
    static bool IsRefusedAttempt(BetaContentBlockParam block, HashSet<string> resolved)
    {
        if (
            block.TryPickThinking(out _)
            || block.TryPickRedactedThinking(out _)
            || block.TryPickToolUse(out _)
        )
        {
            return true;
        }
        if (block.TryPickServerToolUse(out var serverToolUse))
        {
            return ServerToolUseID(serverToolUse) is not { } id || !resolved.Contains(id);
        }
        // connector_text has no request-union variant (the SDK doesn't model it at all yet), so
        // it's the one block type still classified by its raw tag.
        return block.Value == null && RawType(block) == "connector_text";
    }

    /// <summary>
    /// The <c>tool_use_id</c> a result block resolves, or <c>null</c> for any other block. An
    /// unrecognized <c>*_tool_result</c> type still resolves its call by its raw fields, erring
    /// toward keeping the <c>server_tool_use</c> it answers.
    /// </summary>
    static string? ResolvedToolUseID(BetaContentBlockParam block)
    {
        if (block.Value != null)
        {
            try
            {
                // Non-null exactly for the union's result variants.
                return block.ToolUseID;
            }
            catch (AnthropicInvalidDataException)
            {
                return null; // a result block with a malformed tool_use_id resolves nothing
            }
        }
        return
            RawType(block) is { } type
            && type.EndsWith("_tool_result", StringComparison.Ordinal)
            && block.Json.TryGetProperty("tool_use_id", out var toolUseId)
            && toolUseId.ValueKind == JsonValueKind.String
            ? toolUseId.GetString()
            : null;
    }

    /// <summary>The block's <c>id</c>, or <c>null</c> when the replayed JSON lacks a usable one
    /// (the model's lazy property parse throws rather than returning null).</summary>
    static string? ServerToolUseID(BetaServerToolUseBlockParam serverToolUse)
    {
        try
        {
            return serverToolUse.ID;
        }
        catch (AnthropicInvalidDataException)
        {
            return null;
        }
    }

    /// <summary>The raw <c>type</c> tag, for block types the request union doesn't model.</summary>
    static string? RawType(BetaContentBlockParam block) =>
        block.Json.ValueKind == JsonValueKind.Object
        && block.Json.TryGetProperty("type", out var type)
        && type.ValueKind == JsonValueKind.String
            ? type.GetString()
            : null;
}
