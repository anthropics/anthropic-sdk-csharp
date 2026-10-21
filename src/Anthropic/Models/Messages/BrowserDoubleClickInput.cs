using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Double left-click at a viewport coordinate or on an element by reference.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserDoubleClickInput, BrowserDoubleClickInputFromRaw>))]
public sealed record class BrowserDoubleClickInput : JsonModel
{
    /// <summary>
    /// Where to act: either a viewport coordinate or an element reference.
    /// </summary>
    public required BrowserClickTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserClickTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Optional modifier key chord to hold for the duration of this action (e.g.
    /// "shift", "ctrl+shift", "cmd+alt").
    /// </summary>
    public string? Modifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modifiers");
        }
        init { this._rawData.Set("modifiers", value); }
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
        _ = this.Modifiers;
        _ = this.TabID;
    }

    public BrowserDoubleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserDoubleClickInput(BrowserDoubleClickInput browserDoubleClickInput)
        : base(browserDoubleClickInput) { }
#pragma warning restore CS8618

    public BrowserDoubleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserDoubleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserDoubleClickInputFromRaw.FromRawUnchecked"/>
    public static BrowserDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserDoubleClickInput(BrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserDoubleClickInputFromRaw : IFromRawJson<BrowserDoubleClickInput>
{
    /// <inheritdoc/>
    public BrowserDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserDoubleClickInput.FromRawUnchecked(rawData);
}
