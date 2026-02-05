using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaCompactionContentBlockDelta,
        BetaCompactionContentBlockDeltaFromRaw
    >)
)]
public sealed record class BetaCompactionContentBlockDelta : JsonModel
{
    public required string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("compaction_delta")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCompactionContentBlockDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("compaction_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionContentBlockDelta(
        BetaCompactionContentBlockDelta betaCompactionContentBlockDelta
    )
        : base(betaCompactionContentBlockDelta) { }
#pragma warning restore CS8618

    public BetaCompactionContentBlockDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compaction_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionContentBlockDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionContentBlockDeltaFromRaw.FromRawUnchecked"/>
    public static BetaCompactionContentBlockDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCompactionContentBlockDelta(string? content)
        : this()
    {
        this.Content = content;
    }
}

class BetaCompactionContentBlockDeltaFromRaw : IFromRawJson<BetaCompactionContentBlockDelta>
{
    /// <inheritdoc/>
    public BetaCompactionContentBlockDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompactionContentBlockDelta.FromRawUnchecked(rawData);
}
