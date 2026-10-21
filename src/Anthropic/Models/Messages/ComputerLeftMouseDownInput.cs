using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Press and hold the left mouse button at the current cursor position.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComputerLeftMouseDownInput, ComputerLeftMouseDownInputFromRaw>)
)]
public sealed record class ComputerLeftMouseDownInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public ComputerLeftMouseDownInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerLeftMouseDownInput(ComputerLeftMouseDownInput computerLeftMouseDownInput)
        : base(computerLeftMouseDownInput) { }
#pragma warning restore CS8618

    public ComputerLeftMouseDownInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerLeftMouseDownInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerLeftMouseDownInputFromRaw.FromRawUnchecked"/>
    public static ComputerLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerLeftMouseDownInputFromRaw : IFromRawJson<ComputerLeftMouseDownInput>
{
    /// <inheritdoc/>
    public ComputerLeftMouseDownInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerLeftMouseDownInput.FromRawUnchecked(rawData);
}
