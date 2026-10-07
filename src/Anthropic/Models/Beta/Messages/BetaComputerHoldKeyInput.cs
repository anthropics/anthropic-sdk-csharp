using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Hold down a key or key-combination for a specified duration. Uses the same key
/// syntax as `key`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerHoldKeyInput, BetaComputerHoldKeyInputFromRaw>)
)]
public sealed record class BetaComputerHoldKeyInput : JsonModel
{
    /// <summary>
    /// Duration to hold the key, in seconds.
    /// </summary>
    public required long Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The key or key-combination to hold.
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
        _ = this.Duration;
        _ = this.Text;
    }

    public BetaComputerHoldKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerHoldKeyInput(BetaComputerHoldKeyInput betaComputerHoldKeyInput)
        : base(betaComputerHoldKeyInput) { }
#pragma warning restore CS8618

    public BetaComputerHoldKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerHoldKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerHoldKeyInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerHoldKeyInputFromRaw : IFromRawJson<BetaComputerHoldKeyInput>
{
    /// <inheritdoc/>
    public BetaComputerHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerHoldKeyInput.FromRawUnchecked(rawData);
}
