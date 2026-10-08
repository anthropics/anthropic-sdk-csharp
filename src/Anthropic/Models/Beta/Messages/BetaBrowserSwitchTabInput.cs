using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Make the tab with the given tab_id the active tab — the tab that actions without
/// a tab_id apply to.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserSwitchTabInput, BetaBrowserSwitchTabInputFromRaw>)
)]
public sealed record class BetaBrowserSwitchTabInput : JsonModel
{
    /// <summary>
    /// The tab to switch to.
    /// </summary>
    public required string TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
    }

    public BetaBrowserSwitchTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserSwitchTabInput(BetaBrowserSwitchTabInput betaBrowserSwitchTabInput)
        : base(betaBrowserSwitchTabInput) { }
#pragma warning restore CS8618

    public BetaBrowserSwitchTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserSwitchTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserSwitchTabInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserSwitchTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserSwitchTabInput(string tabID)
        : this()
    {
        this.TabID = tabID;
    }
}

class BetaBrowserSwitchTabInputFromRaw : IFromRawJson<BetaBrowserSwitchTabInput>
{
    /// <inheritdoc/>
    public BetaBrowserSwitchTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserSwitchTabInput.FromRawUnchecked(rawData);
}
