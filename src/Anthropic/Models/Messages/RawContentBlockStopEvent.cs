using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<RawContentBlockStopEvent, RawContentBlockStopEventFromRaw>)
)]
public sealed record class RawContentBlockStopEvent : JsonModel
{
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
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
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("content_block_stop")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RawContentBlockStopEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("content_block_stop");
    }

    public RawContentBlockStopEvent(RawContentBlockStopEvent rawContentBlockStopEvent)
        : base(rawContentBlockStopEvent) { }

    public RawContentBlockStopEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content_block_stop");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawContentBlockStopEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RawContentBlockStopEventFromRaw.FromRawUnchecked"/>
    public static RawContentBlockStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RawContentBlockStopEvent(long index)
        : this()
    {
        this.Index = index;
    }
}

class RawContentBlockStopEventFromRaw : IFromRawJson<RawContentBlockStopEvent>
{
    /// <inheritdoc/>
    public RawContentBlockStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RawContentBlockStopEvent.FromRawUnchecked(rawData);
}
