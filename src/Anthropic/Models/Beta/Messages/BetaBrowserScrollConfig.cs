using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// ``scroll``'s config overrides.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserScrollConfig, BetaBrowserScrollConfigFromRaw>))]
public sealed record class BetaBrowserScrollConfig : JsonModel
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

    public BetaBrowserScrollConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserScrollConfig(BetaBrowserScrollConfig betaBrowserScrollConfig)
        : base(betaBrowserScrollConfig) { }
#pragma warning restore CS8618

    public BetaBrowserScrollConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserScrollConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserScrollConfigFromRaw.FromRawUnchecked"/>
    public static BetaBrowserScrollConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserScrollConfigFromRaw : IFromRawJson<BetaBrowserScrollConfig>
{
    /// <inheritdoc/>
    public BetaBrowserScrollConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserScrollConfig.FromRawUnchecked(rawData);
}
