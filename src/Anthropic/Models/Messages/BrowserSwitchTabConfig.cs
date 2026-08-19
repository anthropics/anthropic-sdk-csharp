using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// ``switch_tab``'s config overrides.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserSwitchTabConfig, BrowserSwitchTabConfigFromRaw>))]
public sealed record class BrowserSwitchTabConfig : JsonModel
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

    public BrowserSwitchTabConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserSwitchTabConfig(BrowserSwitchTabConfig browserSwitchTabConfig)
        : base(browserSwitchTabConfig) { }
#pragma warning restore CS8618

    public BrowserSwitchTabConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSwitchTabConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserSwitchTabConfigFromRaw.FromRawUnchecked"/>
    public static BrowserSwitchTabConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserSwitchTabConfigFromRaw : IFromRawJson<BrowserSwitchTabConfig>
{
    /// <inheritdoc/>
    public BrowserSwitchTabConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserSwitchTabConfig.FromRawUnchecked(rawData);
}
