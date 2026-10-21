using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Press a key or key-combination on the keyboard. Use "+" to combine modifiers with
/// a key (e.g. "ctrl+s", "alt+Tab", "ctrl+shift+Escape"). Key names are case-insensitive;
/// common names like "Return", "Tab", "Escape", "Up", "Down", "Left", "Right", "Home",
/// "End", "Page_Up", "Page_Down", "Delete", "BackSpace" are supported.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerKeyInput, ComputerKeyInputFromRaw>))]
public sealed record class ComputerKeyInput : JsonModel
{
    /// <summary>
    /// The key or key-combination to press.
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

    /// <summary>
    /// Number of times to repeat the key press. Default is 1.
    /// </summary>
    public long? Repeat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("repeat");
        }
        init { this._rawData.Set("repeat", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Repeat;
    }

    public ComputerKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerKeyInput(ComputerKeyInput computerKeyInput)
        : base(computerKeyInput) { }
#pragma warning restore CS8618

    public ComputerKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerKeyInputFromRaw.FromRawUnchecked"/>
    public static ComputerKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComputerKeyInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class ComputerKeyInputFromRaw : IFromRawJson<ComputerKeyInput>
{
    /// <inheritdoc/>
    public ComputerKeyInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComputerKeyInput.FromRawUnchecked(rawData);
}
