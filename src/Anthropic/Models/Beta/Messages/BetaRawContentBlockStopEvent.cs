using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<BetaRawContentBlockStopEvent, BetaRawContentBlockStopEventFromRaw>)
)]
public sealed record class BetaRawContentBlockStopEvent : ModelBase
{
    public required long Index
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "index"); }
        init { ModelBase.Set(this._rawData, "index", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawContentBlockStopEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"");
    }

    public BetaRawContentBlockStopEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockStopEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawContentBlockStopEventFromRaw.FromRawUnchecked"/>
    public static BetaRawContentBlockStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRawContentBlockStopEvent(long index)
        : this()
    {
        this.Index = index;
    }
}

class BetaRawContentBlockStopEventFromRaw : IFromRaw<BetaRawContentBlockStopEvent>
{
    /// <inheritdoc/>
    public BetaRawContentBlockStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawContentBlockStopEvent.FromRawUnchecked(rawData);
}
