using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Double-click the left mouse button at the specified (x, y) pixel coordinate,
/// or the current cursor position if `coordinate` is omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerDoubleClickInput, BetaComputerDoubleClickInputFromRaw>)
)]
public sealed record class BetaComputerDoubleClickInput : JsonModel
{
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
        _ = this.Coordinate;
        _ = this.Text;
    }

    public BetaComputerDoubleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerDoubleClickInput(BetaComputerDoubleClickInput betaComputerDoubleClickInput)
        : base(betaComputerDoubleClickInput) { }
#pragma warning restore CS8618

    public BetaComputerDoubleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerDoubleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerDoubleClickInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerDoubleClickInputFromRaw : IFromRawJson<BetaComputerDoubleClickInput>
{
    /// <inheritdoc/>
    public BetaComputerDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerDoubleClickInput.FromRawUnchecked(rawData);
}
