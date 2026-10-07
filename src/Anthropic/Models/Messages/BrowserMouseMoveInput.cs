using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Move the pointer to a viewport coordinate without clicking.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserMouseMoveInput, BrowserMouseMoveInputFromRaw>))]
public sealed record class BrowserMouseMoveInput : JsonModel
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

    public BrowserMouseMoveInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserMouseMoveInput(BrowserMouseMoveInput browserMouseMoveInput)
        : base(browserMouseMoveInput) { }
#pragma warning restore CS8618

    public BrowserMouseMoveInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserMouseMoveInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserMouseMoveInputFromRaw.FromRawUnchecked"/>
    public static BrowserMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserMouseMoveInput(BrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserMouseMoveInputFromRaw : IFromRawJson<BrowserMouseMoveInput>
{
    /// <inheritdoc/>
    public BrowserMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserMouseMoveInput.FromRawUnchecked(rawData);
}
