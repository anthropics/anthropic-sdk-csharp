using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Find elements matching a natural-language description (e.g. "search bar", "add
/// to cart button") and return up to 20 matches with element references.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserFindInput, BrowserFindInputFromRaw>))]
public sealed record class BrowserFindInput : JsonModel
{
    /// <summary>
    /// Natural-language description of the element(s) to find.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

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
        _ = this.Query;
        _ = this.TabID;
    }

    public BrowserFindInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserFindInput(BrowserFindInput browserFindInput)
        : base(browserFindInput) { }
#pragma warning restore CS8618

    public BrowserFindInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserFindInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFindInputFromRaw.FromRawUnchecked"/>
    public static BrowserFindInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserFindInput(string query)
        : this()
    {
        this.Query = query;
    }
}

class BrowserFindInputFromRaw : IFromRawJson<BrowserFindInput>
{
    /// <inheritdoc/>
    public BrowserFindInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserFindInput.FromRawUnchecked(rawData);
}
