using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Execute JavaScript in the page context and return the value of the last expression.
/// The code runs with access to the DOM, `window`, and page variables. Write the
/// expression you want evaluated — do NOT use `return`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaBrowserJavascriptExecInput,
        BetaBrowserJavascriptExecInputFromRaw
    >)
)]
public sealed record class BetaBrowserJavascriptExecInput : JsonModel
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

    public BetaBrowserJavascriptExecInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserJavascriptExecInput(
        BetaBrowserJavascriptExecInput betaBrowserJavascriptExecInput
    )
        : base(betaBrowserJavascriptExecInput) { }
#pragma warning restore CS8618

    public BetaBrowserJavascriptExecInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserJavascriptExecInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserJavascriptExecInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserJavascriptExecInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserJavascriptExecInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaBrowserJavascriptExecInputFromRaw : IFromRawJson<BetaBrowserJavascriptExecInput>
{
    /// <inheritdoc/>
    public BetaBrowserJavascriptExecInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserJavascriptExecInput.FromRawUnchecked(rawData);
}
