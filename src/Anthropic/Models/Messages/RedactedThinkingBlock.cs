using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RedactedThinkingBlock, RedactedThinkingBlockFromRaw>))]
public sealed record class RedactedThinkingBlock : JsonModel
{
    public required string Data
    {
        get { return this._rawData.GetNotNullClass<string>("data"); }
        init { this._rawData.Set("data", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RedactedThinkingBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

    public RedactedThinkingBlock(RedactedThinkingBlock redactedThinkingBlock)
        : base(redactedThinkingBlock) { }

    public RedactedThinkingBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RedactedThinkingBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RedactedThinkingBlockFromRaw.FromRawUnchecked"/>
    public static RedactedThinkingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RedactedThinkingBlock(string data)
        : this()
    {
        this.Data = data;
    }
}

class RedactedThinkingBlockFromRaw : IFromRawJson<RedactedThinkingBlock>
{
    /// <inheritdoc/>
    public RedactedThinkingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RedactedThinkingBlock.FromRawUnchecked(rawData);
}
