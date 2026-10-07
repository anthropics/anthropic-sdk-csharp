using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Hold a key or key chord down for a duration, then release it. Uses the same key
/// names and "+" chord syntax as the key action.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserHoldKeyInput, BetaBrowserHoldKeyInputFromRaw>))]
public sealed record class BetaBrowserHoldKeyInput : JsonModel
{
    /// <summary>
    /// Seconds to hold the key down (maximum 30).
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The key or chord to hold.
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
        _ = this.Duration;
        _ = this.Text;
        _ = this.TabID;
    }

    public BetaBrowserHoldKeyInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserHoldKeyInput(BetaBrowserHoldKeyInput betaBrowserHoldKeyInput)
        : base(betaBrowserHoldKeyInput) { }
#pragma warning restore CS8618

    public BetaBrowserHoldKeyInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserHoldKeyInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserHoldKeyInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserHoldKeyInputFromRaw : IFromRawJson<BetaBrowserHoldKeyInput>
{
    /// <inheritdoc/>
    public BetaBrowserHoldKeyInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserHoldKeyInput.FromRawUnchecked(rawData);
}
