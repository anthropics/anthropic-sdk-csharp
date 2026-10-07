using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Navigate to a URL, or go back/forward/reload in history. The protocol may be omitted
/// (defaults to https://).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserNavigateInput, BetaBrowserNavigateInputFromRaw>)
)]
public sealed record class BetaBrowserNavigateInput : JsonModel
{
    /// <summary>
    /// The URL to navigate to, or "back" / "forward" / "reload" for history navigation.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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
        _ = this.Url;
        _ = this.TabID;
    }

    public BetaBrowserNavigateInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserNavigateInput(BetaBrowserNavigateInput betaBrowserNavigateInput)
        : base(betaBrowserNavigateInput) { }
#pragma warning restore CS8618

    public BetaBrowserNavigateInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserNavigateInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserNavigateInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserNavigateInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserNavigateInput(string url)
        : this()
    {
        this.Url = url;
    }
}

class BetaBrowserNavigateInputFromRaw : IFromRawJson<BetaBrowserNavigateInput>
{
    /// <inheritdoc/>
    public BetaBrowserNavigateInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserNavigateInput.FromRawUnchecked(rawData);
}
