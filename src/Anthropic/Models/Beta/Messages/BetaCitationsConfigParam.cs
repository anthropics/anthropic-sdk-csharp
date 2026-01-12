using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCitationsConfigParam, BetaCitationsConfigParamFromRaw>)
)]
public sealed record class BetaCitationsConfigParam : JsonModel
{
    public bool? Enabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "enabled"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaCitationsConfigParam() { }

    public BetaCitationsConfigParam(BetaCitationsConfigParam betaCitationsConfigParam)
        : base(betaCitationsConfigParam) { }

    public BetaCitationsConfigParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsConfigParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationsConfigParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationsConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationsConfigParamFromRaw : IFromRawJson<BetaCitationsConfigParam>
{
    /// <inheritdoc/>
    public BetaCitationsConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationsConfigParam.FromRawUnchecked(rawData);
}
