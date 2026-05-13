using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCacheMissUnavailable, BetaCacheMissUnavailableFromRaw>)
)]
public sealed record class BetaCacheMissUnavailable : JsonModel
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

    public BetaCacheMissUnavailable()
    {
        this.Type = JsonSerializer.SerializeToElement("unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCacheMissUnavailable(BetaCacheMissUnavailable betaCacheMissUnavailable)
        : base(betaCacheMissUnavailable) { }
#pragma warning restore CS8618

    public BetaCacheMissUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheMissUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheMissUnavailableFromRaw.FromRawUnchecked"/>
    public static BetaCacheMissUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCacheMissUnavailableFromRaw : IFromRawJson<BetaCacheMissUnavailable>
{
    /// <inheritdoc/>
    public BetaCacheMissUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCacheMissUnavailable.FromRawUnchecked(rawData);
}
