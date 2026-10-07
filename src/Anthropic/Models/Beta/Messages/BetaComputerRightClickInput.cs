using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Click the right mouse button at the specified (x, y) pixel coordinate, or the
/// current cursor position if `coordinate` is omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerRightClickInput, BetaComputerRightClickInputFromRaw>)
)]
public sealed record class BetaComputerRightClickInput : JsonModel
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

    public BetaComputerRightClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerRightClickInput(BetaComputerRightClickInput betaComputerRightClickInput)
        : base(betaComputerRightClickInput) { }
#pragma warning restore CS8618

    public BetaComputerRightClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerRightClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerRightClickInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerRightClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerRightClickInputFromRaw : IFromRawJson<BetaComputerRightClickInput>
{
    /// <inheritdoc/>
    public BetaComputerRightClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerRightClickInput.FromRawUnchecked(rawData);
}
