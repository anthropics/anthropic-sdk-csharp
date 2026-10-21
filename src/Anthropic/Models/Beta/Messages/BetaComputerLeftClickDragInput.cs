using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Click and drag the cursor from `start_coordinate` to `coordinate`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComputerLeftClickDragInput,
        BetaComputerLeftClickDragInputFromRaw
    >)
)]
public sealed record class BetaComputerLeftClickDragInput : JsonModel
{
    /// <summary>
    /// (x, y): x pixels from the left edge, y pixels from the top edge.
    /// </summary>
    public required IReadOnlyList<long> Coordinate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("coordinate");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "coordinate",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// (x, y): x pixels from the left edge, y pixels from the top edge.
    /// </summary>
    public required IReadOnlyList<long> StartCoordinate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("start_coordinate");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "start_coordinate",
                ImmutableArray.ToImmutableArray(value)
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
        _ = this.StartCoordinate;
        _ = this.Text;
    }

    public BetaComputerLeftClickDragInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerLeftClickDragInput(
        BetaComputerLeftClickDragInput betaComputerLeftClickDragInput
    )
        : base(betaComputerLeftClickDragInput) { }
#pragma warning restore CS8618

    public BetaComputerLeftClickDragInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerLeftClickDragInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerLeftClickDragInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerLeftClickDragInputFromRaw : IFromRawJson<BetaComputerLeftClickDragInput>
{
    /// <inheritdoc/>
    public BetaComputerLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerLeftClickDragInput.FromRawUnchecked(rawData);
}
