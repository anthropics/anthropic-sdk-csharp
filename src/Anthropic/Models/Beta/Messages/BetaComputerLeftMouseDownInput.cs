using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Press and hold the left mouse button at the current cursor position.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComputerLeftMouseDownInput,
        BetaComputerLeftMouseDownInputFromRaw
    >)
)]
public sealed record class BetaComputerLeftMouseDownInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaComputerLeftMouseDownInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerLeftMouseDownInput(
        BetaComputerLeftMouseDownInput betaComputerLeftMouseDownInput
    )
        : base(betaComputerLeftMouseDownInput) { }
#pragma warning restore CS8618

    public BetaComputerLeftMouseDownInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerLeftMouseDownInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerLeftMouseDownInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerLeftMouseDownInputFromRaw : IFromRawJson<BetaComputerLeftMouseDownInput>
{
    /// <inheritdoc/>
    public BetaComputerLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerLeftMouseDownInput.FromRawUnchecked(rawData);
}
