using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Wait for a specified duration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaComputerWaitInput, BetaComputerWaitInputFromRaw>))]
public sealed record class BetaComputerWaitInput : JsonModel
{
    /// <summary>
    /// Duration to wait, in seconds.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
    }

    public BetaComputerWaitInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerWaitInput(BetaComputerWaitInput betaComputerWaitInput)
        : base(betaComputerWaitInput) { }
#pragma warning restore CS8618

    public BetaComputerWaitInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerWaitInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerWaitInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComputerWaitInput(long duration)
        : this()
    {
        this.Duration = duration;
    }
}

class BetaComputerWaitInputFromRaw : IFromRawJson<BetaComputerWaitInput>
{
    /// <inheritdoc/>
    public BetaComputerWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerWaitInput.FromRawUnchecked(rawData);
}
