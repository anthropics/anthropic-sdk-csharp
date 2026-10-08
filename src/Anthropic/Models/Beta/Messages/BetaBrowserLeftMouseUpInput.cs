using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Release the left mouse button at a viewport coordinate.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserLeftMouseUpInput, BetaBrowserLeftMouseUpInputFromRaw>)
)]
public sealed record class BetaBrowserLeftMouseUpInput : JsonModel
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

    public BetaBrowserLeftMouseUpInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserLeftMouseUpInput(BetaBrowserLeftMouseUpInput betaBrowserLeftMouseUpInput)
        : base(betaBrowserLeftMouseUpInput) { }
#pragma warning restore CS8618

    public BetaBrowserLeftMouseUpInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserLeftMouseUpInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserLeftMouseUpInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserLeftMouseUpInput(BetaBrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserLeftMouseUpInputFromRaw : IFromRawJson<BetaBrowserLeftMouseUpInput>
{
    /// <inheritdoc/>
    public BetaBrowserLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserLeftMouseUpInput.FromRawUnchecked(rawData);
}
