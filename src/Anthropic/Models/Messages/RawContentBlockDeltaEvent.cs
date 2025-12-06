using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawContentBlockDeltaEvent, RawContentBlockDeltaEventFromRaw>))]
public sealed record class RawContentBlockDeltaEvent : ModelBase
{
    public required RawContentBlockDelta Delta
    {
        get { return ModelBase.GetNotNullClass<RawContentBlockDelta>(this.RawData, "delta"); }
        init { ModelBase.Set(this._rawData, "delta", value); }
    }

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

    public RawContentBlockDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

    public RawContentBlockDeltaEvent(RawContentBlockDeltaEvent rawContentBlockDeltaEvent)
        : base(rawContentBlockDeltaEvent) { }

    public RawContentBlockDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawContentBlockDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RawContentBlockDeltaEventFromRaw.FromRawUnchecked"/>
    public static RawContentBlockDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RawContentBlockDeltaEventFromRaw : IFromRaw<RawContentBlockDeltaEvent>
{
    /// <inheritdoc/>
    public RawContentBlockDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RawContentBlockDeltaEvent.FromRawUnchecked(rawData);
}
