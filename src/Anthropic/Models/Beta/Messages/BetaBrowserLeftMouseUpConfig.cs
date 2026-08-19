using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// ``left_mouse_up``'s config overrides.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserLeftMouseUpConfig, BetaBrowserLeftMouseUpConfigFromRaw>)
)]
public sealed record class BetaBrowserLeftMouseUpConfig : JsonModel
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

    public BetaBrowserLeftMouseUpConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserLeftMouseUpConfig(BetaBrowserLeftMouseUpConfig betaBrowserLeftMouseUpConfig)
        : base(betaBrowserLeftMouseUpConfig) { }
#pragma warning restore CS8618

    public BetaBrowserLeftMouseUpConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserLeftMouseUpConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserLeftMouseUpConfigFromRaw.FromRawUnchecked"/>
    public static BetaBrowserLeftMouseUpConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserLeftMouseUpConfigFromRaw : IFromRawJson<BetaBrowserLeftMouseUpConfig>
{
    /// <inheritdoc/>
    public BetaBrowserLeftMouseUpConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserLeftMouseUpConfig.FromRawUnchecked(rawData);
}
