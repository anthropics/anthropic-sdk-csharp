using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Release the left mouse button.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerLeftMouseUpInput, BetaComputerLeftMouseUpInputFromRaw>)
)]
public sealed record class BetaComputerLeftMouseUpInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaComputerLeftMouseUpInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerLeftMouseUpInput(BetaComputerLeftMouseUpInput betaComputerLeftMouseUpInput)
        : base(betaComputerLeftMouseUpInput) { }
#pragma warning restore CS8618

    public BetaComputerLeftMouseUpInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerLeftMouseUpInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerLeftMouseUpInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerLeftMouseUpInputFromRaw : IFromRawJson<BetaComputerLeftMouseUpInput>
{
    /// <inheritdoc/>
    public BetaComputerLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerLeftMouseUpInput.FromRawUnchecked(rawData);
}
