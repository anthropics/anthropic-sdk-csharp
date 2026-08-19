using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// ``type``'s config overrides.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserTypeConfig, BetaBrowserTypeConfigFromRaw>))]
public sealed record class BetaBrowserTypeConfig : JsonModel
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

    public BetaBrowserTypeConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserTypeConfig(BetaBrowserTypeConfig betaBrowserTypeConfig)
        : base(betaBrowserTypeConfig) { }
#pragma warning restore CS8618

    public BetaBrowserTypeConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserTypeConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserTypeConfigFromRaw.FromRawUnchecked"/>
    public static BetaBrowserTypeConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserTypeConfigFromRaw : IFromRawJson<BetaBrowserTypeConfig>
{
    /// <inheritdoc/>
    public BetaBrowserTypeConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserTypeConfig.FromRawUnchecked(rawData);
}
