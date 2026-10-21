using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Move the cursor to a specified (x, y) pixel coordinate. Use this ONLY to hover
/// without clicking; otherwise use a click action directly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerMouseMoveInput, ComputerMouseMoveInputFromRaw>))]
public sealed record class ComputerMouseMoveInput : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinate;
    }

    public ComputerMouseMoveInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerMouseMoveInput(ComputerMouseMoveInput computerMouseMoveInput)
        : base(computerMouseMoveInput) { }
#pragma warning restore CS8618

    public ComputerMouseMoveInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerMouseMoveInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerMouseMoveInputFromRaw.FromRawUnchecked"/>
    public static ComputerMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComputerMouseMoveInput(IReadOnlyList<long> coordinate)
        : this()
    {
        this.Coordinate = coordinate;
    }
}

class ComputerMouseMoveInputFromRaw : IFromRawJson<ComputerMouseMoveInput>
{
    /// <inheritdoc/>
    public ComputerMouseMoveInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerMouseMoveInput.FromRawUnchecked(rawData);
}
