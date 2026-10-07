using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Set the value of a form element (input, textarea, select, checkbox). Use a boolean
/// for checkboxes, an option value or text for selects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserFormInputInput, BrowserFormInputInputFromRaw>))]
public sealed record class BrowserFormInputInput : JsonModel
{
    /// <summary>
    /// An element on the page, identified by a reference from a prior `read_page`
    /// or `find` result. References are scoped to the tab that produced them and
    /// become stale after navigation or a major re-render.
    /// </summary>
    public required BrowserRefTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserRefTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// The value to set.
    /// </summary>
    public required BrowserFormInputValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserFormInputValue>("value");
        }
        init { this._rawData.Set("value", value); }
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
        this.Target.Validate();
        this.Value.Validate();
        _ = this.TabID;
    }

    public BrowserFormInputInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserFormInputInput(BrowserFormInputInput browserFormInputInput)
        : base(browserFormInputInput) { }
#pragma warning restore CS8618

    public BrowserFormInputInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserFormInputInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFormInputInputFromRaw.FromRawUnchecked"/>
    public static BrowserFormInputInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFormInputInputFromRaw : IFromRawJson<BrowserFormInputInput>
{
    /// <inheritdoc/>
    public BrowserFormInputInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserFormInputInput.FromRawUnchecked(rawData);
}
