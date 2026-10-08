using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Hold down a key or key-combination for a specified duration. Uses the same key
/// syntax as `key`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerHoldKeyInput, ComputerHoldKeyInputFromRaw>))]
public sealed record class ComputerHoldKeyInput : JsonModel
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

    public ComputerHoldKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerHoldKeyInput(ComputerHoldKeyInput computerHoldKeyInput)
        : base(computerHoldKeyInput) { }
#pragma warning restore CS8618

    public ComputerHoldKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerHoldKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerHoldKeyInputFromRaw.FromRawUnchecked"/>
    public static ComputerHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerHoldKeyInputFromRaw : IFromRawJson<ComputerHoldKeyInput>
{
    /// <inheritdoc/>
    public ComputerHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerHoldKeyInput.FromRawUnchecked(rawData);
}
