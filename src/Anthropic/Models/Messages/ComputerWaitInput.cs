using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Wait for a specified duration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerWaitInput, ComputerWaitInputFromRaw>))]
public sealed record class ComputerWaitInput : JsonModel
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

    public ComputerWaitInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerWaitInput(ComputerWaitInput computerWaitInput)
        : base(computerWaitInput) { }
#pragma warning restore CS8618

    public ComputerWaitInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerWaitInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerWaitInputFromRaw.FromRawUnchecked"/>
    public static ComputerWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComputerWaitInput(long duration)
        : this()
    {
        this.Duration = duration;
    }
}

class ComputerWaitInputFromRaw : IFromRawJson<ComputerWaitInput>
{
    /// <inheritdoc/>
    public ComputerWaitInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComputerWaitInput.FromRawUnchecked(rawData);
}
