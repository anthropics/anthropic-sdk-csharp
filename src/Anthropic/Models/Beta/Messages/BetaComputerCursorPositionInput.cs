using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Get the current (x, y) pixel coordinate of the cursor.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComputerCursorPositionInput,
        BetaComputerCursorPositionInputFromRaw
    >)
)]
public sealed record class BetaComputerCursorPositionInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaComputerCursorPositionInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerCursorPositionInput(
        BetaComputerCursorPositionInput betaComputerCursorPositionInput
    )
        : base(betaComputerCursorPositionInput) { }
#pragma warning restore CS8618

    public BetaComputerCursorPositionInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerCursorPositionInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerCursorPositionInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerCursorPositionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerCursorPositionInputFromRaw : IFromRawJson<BetaComputerCursorPositionInput>
{
    /// <inheritdoc/>
    public BetaComputerCursorPositionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerCursorPositionInput.FromRawUnchecked(rawData);
}
