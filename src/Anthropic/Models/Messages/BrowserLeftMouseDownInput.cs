using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Press and hold the left mouse button at a viewport coordinate. Pair with left_mouse_up
/// to perform a custom drag.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BrowserLeftMouseDownInput, BrowserLeftMouseDownInputFromRaw>)
)]
public sealed record class BrowserLeftMouseDownInput : JsonModel
{
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
        this.Target.Validate();
        _ = this.TabID;
    }

    public BrowserLeftMouseDownInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserLeftMouseDownInput(BrowserLeftMouseDownInput browserLeftMouseDownInput)
        : base(browserLeftMouseDownInput) { }
#pragma warning restore CS8618

    public BrowserLeftMouseDownInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserLeftMouseDownInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserLeftMouseDownInputFromRaw.FromRawUnchecked"/>
    public static BrowserLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserLeftMouseDownInput(BrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserLeftMouseDownInputFromRaw : IFromRawJson<BrowserLeftMouseDownInput>
{
    /// <inheritdoc/>
    public BrowserLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserLeftMouseDownInput.FromRawUnchecked(rawData);
}
