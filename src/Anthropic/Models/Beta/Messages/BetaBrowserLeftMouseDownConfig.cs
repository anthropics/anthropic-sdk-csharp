using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// ``left_mouse_down``'s config overrides.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaBrowserLeftMouseDownConfig,
        BetaBrowserLeftMouseDownConfigFromRaw
    >)
)]
public sealed record class BetaBrowserLeftMouseDownConfig : JsonModel
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

    public BetaBrowserLeftMouseDownConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserLeftMouseDownConfig(
        BetaBrowserLeftMouseDownConfig betaBrowserLeftMouseDownConfig
    )
        : base(betaBrowserLeftMouseDownConfig) { }
#pragma warning restore CS8618

    public BetaBrowserLeftMouseDownConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserLeftMouseDownConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserLeftMouseDownConfigFromRaw.FromRawUnchecked"/>
    public static BetaBrowserLeftMouseDownConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserLeftMouseDownConfigFromRaw : IFromRawJson<BetaBrowserLeftMouseDownConfig>
{
    /// <inheritdoc/>
    public BetaBrowserLeftMouseDownConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserLeftMouseDownConfig.FromRawUnchecked(rawData);
}
