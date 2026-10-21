using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Press and hold the left mouse button at a viewport coordinate. Pair with left_mouse_up
/// to perform a custom drag.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserLeftMouseDownInput, BetaBrowserLeftMouseDownInputFromRaw>)
)]
public sealed record class BetaBrowserLeftMouseDownInput : JsonModel
{
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
        this.Target.Validate();
        _ = this.TabID;
    }

    public BetaBrowserLeftMouseDownInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserLeftMouseDownInput(
        BetaBrowserLeftMouseDownInput betaBrowserLeftMouseDownInput
    )
        : base(betaBrowserLeftMouseDownInput) { }
#pragma warning restore CS8618

    public BetaBrowserLeftMouseDownInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserLeftMouseDownInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserLeftMouseDownInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserLeftMouseDownInput(BetaBrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserLeftMouseDownInputFromRaw : IFromRawJson<BetaBrowserLeftMouseDownInput>
{
    /// <inheritdoc/>
    public BetaBrowserLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserLeftMouseDownInput.FromRawUnchecked(rawData);
}
