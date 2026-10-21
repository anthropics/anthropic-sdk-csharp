using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Make the tab with the given tab_id the active tab — the tab that actions without
/// a tab_id apply to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserSwitchTabInput, BrowserSwitchTabInputFromRaw>))]
public sealed record class BrowserSwitchTabInput : JsonModel
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

    public BrowserSwitchTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserSwitchTabInput(BrowserSwitchTabInput browserSwitchTabInput)
        : base(browserSwitchTabInput) { }
#pragma warning restore CS8618

    public BrowserSwitchTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserSwitchTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserSwitchTabInputFromRaw.FromRawUnchecked"/>
    public static BrowserSwitchTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserSwitchTabInput(string tabID)
        : this()
    {
        this.TabID = tabID;
    }
}

class BrowserSwitchTabInputFromRaw : IFromRawJson<BrowserSwitchTabInput>
{
    /// <inheritdoc/>
    public BrowserSwitchTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserSwitchTabInput.FromRawUnchecked(rawData);
}
