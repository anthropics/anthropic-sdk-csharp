using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Type a string of text on the keyboard.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaComputerTypeInput, BetaComputerTypeInputFromRaw>))]
public sealed record class BetaComputerTypeInput : JsonModel
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

    public BetaComputerTypeInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerTypeInput(BetaComputerTypeInput betaComputerTypeInput)
        : base(betaComputerTypeInput) { }
#pragma warning restore CS8618

    public BetaComputerTypeInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerTypeInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerTypeInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComputerTypeInput(string text)
        : this()
    {
        this.Text = text;
    }
}

class BetaComputerTypeInputFromRaw : IFromRawJson<BetaComputerTypeInput>
{
    /// <inheritdoc/>
    public BetaComputerTypeInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerTypeInput.FromRawUnchecked(rawData);
}
