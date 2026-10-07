using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Find elements matching a natural-language description (e.g. "search bar", "add
/// to cart button") and return up to 20 matches with element references.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserFindInput, BetaBrowserFindInputFromRaw>))]
public sealed record class BetaBrowserFindInput : JsonModel
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

    public BetaBrowserFindInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserFindInput(BetaBrowserFindInput betaBrowserFindInput)
        : base(betaBrowserFindInput) { }
#pragma warning restore CS8618

    public BetaBrowserFindInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserFindInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserFindInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserFindInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserFindInput(string query)
        : this()
    {
        this.Query = query;
    }
}

class BetaBrowserFindInputFromRaw : IFromRawJson<BetaBrowserFindInput>
{
    /// <inheritdoc/>
    public BetaBrowserFindInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserFindInput.FromRawUnchecked(rawData);
}
