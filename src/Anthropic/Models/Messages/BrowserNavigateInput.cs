using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Navigate to a URL, or go back/forward/reload in history. The protocol may be omitted
/// (defaults to https://).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserNavigateInput, BrowserNavigateInputFromRaw>))]
public sealed record class BrowserNavigateInput : JsonModel
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

    public BrowserNavigateInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserNavigateInput(BrowserNavigateInput browserNavigateInput)
        : base(browserNavigateInput) { }
#pragma warning restore CS8618

    public BrowserNavigateInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserNavigateInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserNavigateInputFromRaw.FromRawUnchecked"/>
    public static BrowserNavigateInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserNavigateInput(string url)
        : this()
    {
        this.Url = url;
    }
}

class BrowserNavigateInputFromRaw : IFromRawJson<BrowserNavigateInput>
{
    /// <inheritdoc/>
    public BrowserNavigateInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserNavigateInput.FromRawUnchecked(rawData);
}
