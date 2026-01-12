using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CitationsConfigParam, CitationsConfigParamFromRaw>))]
public sealed record class CitationsConfigParam : JsonModel
{
    public bool? Enabled
    {
        get { return this._rawData.GetNullableStruct<bool>("enabled"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
    }

    public CitationsConfigParam() { }

    public CitationsConfigParam(CitationsConfigParam citationsConfigParam)
        : base(citationsConfigParam) { }

    public CitationsConfigParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsConfigParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsConfigParamFromRaw.FromRawUnchecked"/>
    public static CitationsConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationsConfigParamFromRaw : IFromRawJson<CitationsConfigParam>
{
    /// <inheritdoc/>
    public CitationsConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationsConfigParam.FromRawUnchecked(rawData);
}
