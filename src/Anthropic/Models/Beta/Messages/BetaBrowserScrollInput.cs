using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Scroll at a viewport position. `target` must be a coordinate target.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserScrollInput, BetaBrowserScrollInputFromRaw>))]
public sealed record class BetaBrowserScrollInput : JsonModel
{
    public required ApiEnum<string, BetaBrowserScrollDirection> ScrollDirection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaBrowserScrollDirection>>(
                "scroll_direction"
            );
        }
        init { this._rawData.Set("scroll_direction", value); }
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
    /// Scroll-wheel notches (1–10). Default 3.
    /// </summary>
    public long? ScrollAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("scroll_amount");
        }
        init { this._rawData.Set("scroll_amount", value); }
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
        this.ScrollDirection.Validate();
        this.Target.Validate();
        _ = this.ScrollAmount;
        _ = this.TabID;
    }

    public BetaBrowserScrollInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserScrollInput(BetaBrowserScrollInput betaBrowserScrollInput)
        : base(betaBrowserScrollInput) { }
#pragma warning restore CS8618

    public BetaBrowserScrollInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserScrollInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserScrollInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserScrollInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserScrollInputFromRaw : IFromRawJson<BetaBrowserScrollInput>
{
    /// <inheritdoc/>
    public BetaBrowserScrollInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserScrollInput.FromRawUnchecked(rawData);
}
