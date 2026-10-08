using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Execute JavaScript in the page context and return the value of the last expression.
/// The code runs with access to the DOM, `window`, and page variables. Write the
/// expression you want evaluated — do NOT use `return`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BrowserJavascriptExecInput, BrowserJavascriptExecInputFromRaw>)
)]
public sealed record class BrowserJavascriptExecInput : JsonModel
{
    /// <summary>
    /// JavaScript to execute in the page context.
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

    public BrowserJavascriptExecInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserJavascriptExecInput(BrowserJavascriptExecInput browserJavascriptExecInput)
        : base(browserJavascriptExecInput) { }
#pragma warning restore CS8618

    public BrowserJavascriptExecInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserJavascriptExecInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserJavascriptExecInputFromRaw.FromRawUnchecked"/>
    public static BrowserJavascriptExecInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserJavascriptExecInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BrowserJavascriptExecInputFromRaw : IFromRawJson<BrowserJavascriptExecInput>
{
    /// <inheritdoc/>
    public BrowserJavascriptExecInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserJavascriptExecInput.FromRawUnchecked(rawData);
}
