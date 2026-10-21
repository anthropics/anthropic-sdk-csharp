using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Move the pointer to a viewport coordinate without clicking.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserMouseMoveInput, BetaBrowserMouseMoveInputFromRaw>)
)]
public sealed record class BetaBrowserMouseMoveInput : JsonModel
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

    public BetaBrowserMouseMoveInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserMouseMoveInput(BetaBrowserMouseMoveInput betaBrowserMouseMoveInput)
        : base(betaBrowserMouseMoveInput) { }
#pragma warning restore CS8618

    public BetaBrowserMouseMoveInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserMouseMoveInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserMouseMoveInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserMouseMoveInput(BetaBrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserMouseMoveInputFromRaw : IFromRawJson<BetaBrowserMouseMoveInput>
{
    /// <inheritdoc/>
    public BetaBrowserMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserMouseMoveInput.FromRawUnchecked(rawData);
}
