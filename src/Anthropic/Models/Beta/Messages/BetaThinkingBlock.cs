using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingBlock, BetaThinkingBlockFromRaw>))]
public sealed record class BetaThinkingBlock : ModelBase
{
    public required string Signature
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "signature"); }
        init { ModelBase.Set(this._rawData, "signature", value); }
    }

    public required string Thinking
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "thinking"); }
        init { ModelBase.Set(this._rawData, "thinking", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Signature;
        _ = this.Thinking;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");
    }

    public BetaThinkingBlock(BetaThinkingBlock betaThinkingBlock)
        : base(betaThinkingBlock) { }

    public BetaThinkingBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingBlockFromRaw.FromRawUnchecked"/>
    public static BetaThinkingBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingBlockFromRaw : IFromRaw<BetaThinkingBlock>
{
    /// <inheritdoc/>
    public BetaThinkingBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingBlock.FromRawUnchecked(rawData);
}
