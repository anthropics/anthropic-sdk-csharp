using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Get the current (x, y) pixel coordinate of the cursor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComputerCursorPositionInput, ComputerCursorPositionInputFromRaw>)
)]
public sealed record class ComputerCursorPositionInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ComputerCursorPositionInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerCursorPositionInput(ComputerCursorPositionInput computerCursorPositionInput)
        : base(computerCursorPositionInput) { }
#pragma warning restore CS8618

    public ComputerCursorPositionInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerCursorPositionInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerCursorPositionInputFromRaw.FromRawUnchecked"/>
    public static ComputerCursorPositionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerCursorPositionInputFromRaw : IFromRawJson<ComputerCursorPositionInput>
{
    /// <inheritdoc/>
    public ComputerCursorPositionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerCursorPositionInput.FromRawUnchecked(rawData);
}
