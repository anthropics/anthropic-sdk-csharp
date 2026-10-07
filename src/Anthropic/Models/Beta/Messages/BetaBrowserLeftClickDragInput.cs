using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Press at `from`, drag to `target`, release. Both must be coordinate targets.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserLeftClickDragInput, BetaBrowserLeftClickDragInputFromRaw>)
)]
public sealed record class BetaBrowserLeftClickDragInput : JsonModel
{
    /// <summary>
    /// A point in the browser viewport, in viewport pixels (the same frame as a
    /// full-viewport screenshot).
    /// </summary>
    public required BetaBrowserCoordinateTarget From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserCoordinateTarget>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// A point in the browser viewport, in viewport pixels (the same frame as a
    /// full-viewport screenshot).
    /// </summary>
    public required BetaBrowserCoordinateTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserCoordinateTarget>("target");
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

    public BetaBrowserLeftClickDragInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserLeftClickDragInput(
        BetaBrowserLeftClickDragInput betaBrowserLeftClickDragInput
    )
        : base(betaBrowserLeftClickDragInput) { }
#pragma warning restore CS8618

    public BetaBrowserLeftClickDragInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserLeftClickDragInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserLeftClickDragInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserLeftClickDragInputFromRaw : IFromRawJson<BetaBrowserLeftClickDragInput>
{
    /// <inheritdoc/>
    public BetaBrowserLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserLeftClickDragInput.FromRawUnchecked(rawData);
}
