using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Release the left mouse button.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComputerLeftMouseUpInput, ComputerLeftMouseUpInputFromRaw>)
)]
public sealed record class ComputerLeftMouseUpInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ComputerLeftMouseUpInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerLeftMouseUpInput(ComputerLeftMouseUpInput computerLeftMouseUpInput)
        : base(computerLeftMouseUpInput) { }
#pragma warning restore CS8618

    public ComputerLeftMouseUpInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerLeftMouseUpInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerLeftMouseUpInputFromRaw.FromRawUnchecked"/>
    public static ComputerLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerLeftMouseUpInputFromRaw : IFromRawJson<ComputerLeftMouseUpInput>
{
    /// <inheritdoc/>
    public ComputerLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerLeftMouseUpInput.FromRawUnchecked(rawData);
}
