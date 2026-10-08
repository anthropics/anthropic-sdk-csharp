using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Type a string of text on the keyboard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerTypeInput, ComputerTypeInputFromRaw>))]
public sealed record class ComputerTypeInput : JsonModel
{
    /// <summary>
    /// The text to type.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
    }

    public ComputerTypeInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerTypeInput(ComputerTypeInput computerTypeInput)
        : base(computerTypeInput) { }
#pragma warning restore CS8618

    public ComputerTypeInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerTypeInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerTypeInputFromRaw.FromRawUnchecked"/>
    public static ComputerTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComputerTypeInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class ComputerTypeInputFromRaw : IFromRawJson<ComputerTypeInput>
{
    /// <inheritdoc/>
    public ComputerTypeInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComputerTypeInput.FromRawUnchecked(rawData);
}
