using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Type a literal string at the current focus.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserTypeInput, BrowserTypeInputFromRaw>))]
public sealed record class BrowserTypeInput : JsonModel
{
    /// <summary>
    /// The text to type.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        _ = this.Text;
        _ = this.TabID;
    }

    public BrowserTypeInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserTypeInput(BrowserTypeInput browserTypeInput)
        : base(browserTypeInput) { }
#pragma warning restore CS8618

    public BrowserTypeInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserTypeInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserTypeInputFromRaw.FromRawUnchecked"/>
    public static BrowserTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserTypeInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BrowserTypeInputFromRaw : IFromRawJson<BrowserTypeInput>
{
    /// <inheritdoc/>
    public BrowserTypeInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserTypeInput.FromRawUnchecked(rawData);
}
