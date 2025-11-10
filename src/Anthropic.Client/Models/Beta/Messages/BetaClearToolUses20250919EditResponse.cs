using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaClearToolUses20250919EditResponse>))]
public sealed record class BetaClearToolUses20250919EditResponse
    : ModelBase,
        IFromRaw<BetaClearToolUses20250919EditResponse>
{
    /// <summary>
    /// Number of input tokens cleared by this edit.
    /// </summary>
    public required long ClearedInputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("cleared_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cleared_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cleared_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cleared_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of tool uses that were cleared.
    /// </summary>
    public required long ClearedToolUses
    {
        get
        {
            if (!this._properties.TryGetValue("cleared_tool_uses", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cleared_tool_uses' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cleared_tool_uses",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cleared_tool_uses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of context management edit applied.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ClearedInputTokens;
        _ = this.ClearedToolUses;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClearToolUses20250919EditResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

    public BetaClearToolUses20250919EditResponse(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919EditResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaClearToolUses20250919EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
