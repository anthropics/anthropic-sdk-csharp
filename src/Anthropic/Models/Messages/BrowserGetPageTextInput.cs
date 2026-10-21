using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Return the page's visible text content as plain text, prioritizing article content.
/// Suited to articles, documentation, and other text-heavy pages.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserGetPageTextInput, BrowserGetPageTextInputFromRaw>))]
public sealed record class BrowserGetPageTextInput : JsonModel
{
    /// <summary>
    /// Tab to act on. Defaults to the active tab when omitted.
    /// </summary>
    public string? TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
    }

    public BrowserGetPageTextInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserGetPageTextInput(BrowserGetPageTextInput browserGetPageTextInput)
        : base(browserGetPageTextInput) { }
#pragma warning restore CS8618

    public BrowserGetPageTextInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserGetPageTextInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserGetPageTextInputFromRaw.FromRawUnchecked"/>
    public static BrowserGetPageTextInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserGetPageTextInputFromRaw : IFromRawJson<BrowserGetPageTextInput>
{
    /// <inheritdoc/>
    public BrowserGetPageTextInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserGetPageTextInput.FromRawUnchecked(rawData);
}
