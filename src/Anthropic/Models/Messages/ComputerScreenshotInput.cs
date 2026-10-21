using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Take a screenshot of the screen.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerScreenshotInput, ComputerScreenshotInputFromRaw>))]
public sealed record class ComputerScreenshotInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ComputerScreenshotInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerScreenshotInput(ComputerScreenshotInput computerScreenshotInput)
        : base(computerScreenshotInput) { }
#pragma warning restore CS8618

    public ComputerScreenshotInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerScreenshotInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerScreenshotInputFromRaw.FromRawUnchecked"/>
    public static ComputerScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerScreenshotInputFromRaw : IFromRawJson<ComputerScreenshotInput>
{
    /// <inheritdoc/>
    public ComputerScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerScreenshotInput.FromRawUnchecked(rawData);
}
