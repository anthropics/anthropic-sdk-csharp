using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Click and drag the cursor from `start_coordinate` to `coordinate`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComputerLeftClickDragInput, ComputerLeftClickDragInputFromRaw>)
)]
public sealed record class ComputerLeftClickDragInput : JsonModel
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

    public ComputerLeftClickDragInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerLeftClickDragInput(ComputerLeftClickDragInput computerLeftClickDragInput)
        : base(computerLeftClickDragInput) { }
#pragma warning restore CS8618

    public ComputerLeftClickDragInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerLeftClickDragInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerLeftClickDragInputFromRaw.FromRawUnchecked"/>
    public static ComputerLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerLeftClickDragInputFromRaw : IFromRawJson<ComputerLeftClickDragInput>
{
    /// <inheritdoc/>
    public ComputerLeftClickDragInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerLeftClickDragInput.FromRawUnchecked(rawData);
}
