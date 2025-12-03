using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRedactedThinkingBlock, BetaRedactedThinkingBlockFromRaw>))]
public sealed record class BetaRedactedThinkingBlock : ModelBase
{
    public required string Data
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public BetaRedactedThinkingBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

    public BetaRedactedThinkingBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRedactedThinkingBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRedactedThinkingBlockFromRaw.FromRawUnchecked"/>
    public static BetaRedactedThinkingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRedactedThinkingBlock(string data)
        : this()
    {
        this.Data = data;
    }
}

class BetaRedactedThinkingBlockFromRaw : IFromRaw<BetaRedactedThinkingBlock>
{
    /// <inheritdoc/>
    public BetaRedactedThinkingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRedactedThinkingBlock.FromRawUnchecked(rawData);
}
