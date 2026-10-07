using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Press at `from`, drag to `target`, release. Both must be coordinate targets.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BrowserLeftClickDragInput, BrowserLeftClickDragInputFromRaw>)
)]
public sealed record class BrowserLeftClickDragInput : JsonModel
{
    /// <summary>
    /// A point in the browser viewport, in viewport pixels (the same frame as a
    /// full-viewport screenshot).
    /// </summary>
    public required BrowserCoordinateTarget From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserCoordinateTarget>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// A point in the browser viewport, in viewport pixels (the same frame as a
    /// full-viewport screenshot).
    /// </summary>
    public required BrowserCoordinateTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserCoordinateTarget>("target");
        }
        init { this._rawData.Set("target", value); }
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
        this.From.Validate();
        this.Target.Validate();
        _ = this.TabID;
    }

    public BrowserLeftClickDragInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserLeftClickDragInput(BrowserLeftClickDragInput browserLeftClickDragInput)
        : base(browserLeftClickDragInput) { }
#pragma warning restore CS8618

    public BrowserLeftClickDragInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserLeftClickDragInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserLeftClickDragInputFromRaw.FromRawUnchecked"/>
    public static BrowserLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserLeftClickDragInputFromRaw : IFromRawJson<BrowserLeftClickDragInput>
{
    /// <inheritdoc/>
    public BrowserLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserLeftClickDragInput.FromRawUnchecked(rawData);
}
