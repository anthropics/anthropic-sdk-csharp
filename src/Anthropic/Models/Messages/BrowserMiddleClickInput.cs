using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Middle-click at a viewport coordinate or on an element by reference.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserMiddleClickInput, BrowserMiddleClickInputFromRaw>))]
public sealed record class BrowserMiddleClickInput : JsonModel
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

    public BrowserMiddleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserMiddleClickInput(BrowserMiddleClickInput browserMiddleClickInput)
        : base(browserMiddleClickInput) { }
#pragma warning restore CS8618

    public BrowserMiddleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserMiddleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserMiddleClickInputFromRaw.FromRawUnchecked"/>
    public static BrowserMiddleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserMiddleClickInput(BrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserMiddleClickInputFromRaw : IFromRawJson<BrowserMiddleClickInput>
{
    /// <inheritdoc/>
    public BrowserMiddleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserMiddleClickInput.FromRawUnchecked(rawData);
}
