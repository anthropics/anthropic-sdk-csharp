using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Press a key or key chord. Use "+" to combine modifiers with a key (e.g. "ctrl+a",
/// "cmd+shift+p") and space to sequence presses (e.g. "Backspace Backspace Delete").
/// Common names like "Return", "Tab", "Escape", "BackSpace" are supported.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserKeyInput, BetaBrowserKeyInputFromRaw>))]
public sealed record class BetaBrowserKeyInput : JsonModel
{
    /// <summary>
    /// The key, chord, or space-separated sequence to press.
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
    /// Number of times to repeat. Default 1.
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

    /// <summary>
    /// Tab to act on. Defaults to the active tab when omitted.
    /// </summary>
    public string? TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Repeat;
        _ = this.TabID;
    }

    public BetaBrowserKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserKeyInput(BetaBrowserKeyInput betaBrowserKeyInput)
        : base(betaBrowserKeyInput) { }
#pragma warning restore CS8618

    public BetaBrowserKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserKeyInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserKeyInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaBrowserKeyInputFromRaw : IFromRawJson<BetaBrowserKeyInput>
{
    /// <inheritdoc/>
    public BetaBrowserKeyInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaBrowserKeyInput.FromRawUnchecked(rawData);
}
