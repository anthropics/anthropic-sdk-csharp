using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// List all open tabs with each tab's tab_id, title, and URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserListTabsInput, BrowserListTabsInputFromRaw>))]
public sealed record class BrowserListTabsInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BrowserListTabsInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserListTabsInput(BrowserListTabsInput browserListTabsInput)
        : base(browserListTabsInput) { }
#pragma warning restore CS8618

    public BrowserListTabsInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserListTabsInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserListTabsInputFromRaw.FromRawUnchecked"/>
    public static BrowserListTabsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserListTabsInputFromRaw : IFromRawJson<BrowserListTabsInput>
{
    /// <inheritdoc/>
    public BrowserListTabsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserListTabsInput.FromRawUnchecked(rawData);
}
