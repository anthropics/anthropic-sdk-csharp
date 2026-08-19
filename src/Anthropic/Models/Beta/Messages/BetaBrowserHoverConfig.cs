using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// ``hover``'s config overrides.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserHoverConfig, BetaBrowserHoverConfigFromRaw>))]
public sealed record class BetaBrowserHoverConfig : JsonModel
{
    /// <summary>
    /// Defer loading for this member. Must resolve to the same value on every enabled
    /// member of the toolset.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init { this._rawData.Set("defer_loading", value); }
    }

    /// <summary>
    /// Whether this member is offered to the model. Default is per member, per the
    /// toolset's documentation. A member whose enabled resolves false is withheld
    /// from the served schema.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public BetaBrowserHoverConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserHoverConfig(BetaBrowserHoverConfig betaBrowserHoverConfig)
        : base(betaBrowserHoverConfig) { }
#pragma warning restore CS8618

    public BetaBrowserHoverConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserHoverConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserHoverConfigFromRaw.FromRawUnchecked"/>
    public static BetaBrowserHoverConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserHoverConfigFromRaw : IFromRawJson<BetaBrowserHoverConfig>
{
    /// <inheritdoc/>
    public BetaBrowserHoverConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserHoverConfig.FromRawUnchecked(rawData);
}
