using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Take a screenshot of the screen.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerScreenshotInput, BetaComputerScreenshotInputFromRaw>)
)]
public sealed record class BetaComputerScreenshotInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaComputerScreenshotInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerScreenshotInput(BetaComputerScreenshotInput betaComputerScreenshotInput)
        : base(betaComputerScreenshotInput) { }
#pragma warning restore CS8618

    public BetaComputerScreenshotInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerScreenshotInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerScreenshotInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerScreenshotInputFromRaw : IFromRawJson<BetaComputerScreenshotInput>
{
    /// <inheritdoc/>
    public BetaComputerScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerScreenshotInput.FromRawUnchecked(rawData);
}
