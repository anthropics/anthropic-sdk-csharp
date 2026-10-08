using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Return the page's visible text content as plain text, prioritizing article content.
/// Suited to articles, documentation, and other text-heavy pages.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserGetPageTextInput, BetaBrowserGetPageTextInputFromRaw>)
)]
public sealed record class BetaBrowserGetPageTextInput : JsonModel
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

    public BetaBrowserGetPageTextInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserGetPageTextInput(BetaBrowserGetPageTextInput betaBrowserGetPageTextInput)
        : base(betaBrowserGetPageTextInput) { }
#pragma warning restore CS8618

    public BetaBrowserGetPageTextInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserGetPageTextInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserGetPageTextInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserGetPageTextInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserGetPageTextInputFromRaw : IFromRawJson<BetaBrowserGetPageTextInput>
{
    /// <inheritdoc/>
    public BetaBrowserGetPageTextInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserGetPageTextInput.FromRawUnchecked(rawData);
}
