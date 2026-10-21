using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Scroll the screen at the specified (x, y) pixel coordinate, or the current cursor
/// position if `coordinate` is omitted. Do NOT use PageUp/PageDown to scroll.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaComputerScrollInput, BetaComputerScrollInputFromRaw>))]
public sealed record class BetaComputerScrollInput : JsonModel
{
    /// <summary>
    /// Number of 'clicks' of the scroll wheel.
    /// </summary>
    public required long ScrollAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("scroll_amount");
        }
        init { this._rawData.Set("scroll_amount", value); }
    }

    public required ApiEnum<string, BetaComputerScrollDirection> ScrollDirection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaComputerScrollDirection>>(
                "scroll_direction"
            );
        }
        init { this._rawData.Set("scroll_direction", value); }
    }

    /// <summary>
    /// (x, y): x pixels from the left edge, y pixels from the top edge.
    /// </summary>
    public IReadOnlyList<long>? Coordinate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("coordinate");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "coordinate",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional key combination to hold down during this action (e.g. "ctrl", "shift", "ctrl+shift").
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScrollAmount;
        this.ScrollDirection.Validate();
        _ = this.Coordinate;
        _ = this.Text;
    }

    public BetaComputerScrollInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerScrollInput(BetaComputerScrollInput betaComputerScrollInput)
        : base(betaComputerScrollInput) { }
#pragma warning restore CS8618

    public BetaComputerScrollInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerScrollInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerScrollInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerScrollInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerScrollInputFromRaw : IFromRawJson<BetaComputerScrollInput>
{
    /// <inheritdoc/>
    public BetaComputerScrollInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerScrollInput.FromRawUnchecked(rawData);
}
