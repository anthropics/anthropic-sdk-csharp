using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<PlainTextSource, PlainTextSourceFromRaw>))]
public sealed record class PlainTextSource : ModelBase
{
    public required string Data
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public JsonElement MediaType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "media_type"); }
        init { ModelBase.Set(this._rawData, "media_type", value); }
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
                this.MediaType,
                JsonSerializer.Deserialize<JsonElement>("\"text/plain\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"text\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public PlainTextSource()
    {
        this.MediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public PlainTextSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.MediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlainTextSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlainTextSourceFromRaw.FromRawUnchecked"/>
    public static PlainTextSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlainTextSource(string data)
        : this()
    {
        this.Data = data;
    }
}

class PlainTextSourceFromRaw : IFromRaw<PlainTextSource>
{
    /// <inheritdoc/>
    public PlainTextSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlainTextSource.FromRawUnchecked(rawData);
}
