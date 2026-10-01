using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CacheMissUnavailable, CacheMissUnavailableFromRaw>))]
public sealed record class CacheMissUnavailable : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unavailable")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CacheMissUnavailable()
    {
        this.Type = JsonSerializer.SerializeToElement("unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CacheMissUnavailable(CacheMissUnavailable cacheMissUnavailable)
        : base(cacheMissUnavailable) { }
#pragma warning restore CS8618

    public CacheMissUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheMissUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheMissUnavailableFromRaw.FromRawUnchecked"/>
    public static CacheMissUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CacheMissUnavailableFromRaw : IFromRawJson<CacheMissUnavailable>
{
    /// <inheritdoc/>
    public CacheMissUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CacheMissUnavailable.FromRawUnchecked(rawData);
}
