using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaRawContentBlockDeltaEvent, BetaRawContentBlockDeltaEventFromRaw>)
)]
public sealed record class BetaRawContentBlockDeltaEvent : JsonModel
{
    public required BetaRawContentBlockDelta Delta
    {
        get { return this._rawData.GetNotNullClass<BetaRawContentBlockDelta>("delta"); }
        init { this._rawData.Set("delta", value); }
    }

    public required long Index
    {
        get { return this._rawData.GetNotNullStruct<long>("index"); }
        init { this._rawData.Set("index", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Delta.Validate();
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawContentBlockDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

    public BetaRawContentBlockDeltaEvent(
        BetaRawContentBlockDeltaEvent betaRawContentBlockDeltaEvent
    )
        : base(betaRawContentBlockDeltaEvent) { }

    public BetaRawContentBlockDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawContentBlockDeltaEventFromRaw.FromRawUnchecked"/>
    public static BetaRawContentBlockDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRawContentBlockDeltaEventFromRaw : IFromRawJson<BetaRawContentBlockDeltaEvent>
{
    /// <inheritdoc/>
    public BetaRawContentBlockDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawContentBlockDeltaEvent.FromRawUnchecked(rawData);
}
