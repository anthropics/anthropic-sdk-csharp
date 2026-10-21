using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Press a key or key-combination on the keyboard. Use "+" to combine modifiers with
/// a key (e.g. "ctrl+s", "alt+Tab", "ctrl+shift+Escape"). Key names are case-insensitive;
/// common names like "Return", "Tab", "Escape", "Up", "Down", "Left", "Right", "Home",
/// "End", "Page_Up", "Page_Down", "Delete", "BackSpace" are supported.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaComputerKeyInput, BetaComputerKeyInputFromRaw>))]
public sealed record class BetaComputerKeyInput : JsonModel
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

    public BetaComputerKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerKeyInput(BetaComputerKeyInput betaComputerKeyInput)
        : base(betaComputerKeyInput) { }
#pragma warning restore CS8618

    public BetaComputerKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerKeyInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComputerKeyInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaComputerKeyInputFromRaw : IFromRawJson<BetaComputerKeyInput>
{
    /// <inheritdoc/>
    public BetaComputerKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerKeyInput.FromRawUnchecked(rawData);
}
