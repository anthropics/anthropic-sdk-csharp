using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Pause for the given duration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserWaitInput, BetaBrowserWaitInputFromRaw>))]
public sealed record class BetaBrowserWaitInput : JsonModel
{
    /// <summary>
    /// Seconds to wait (maximum 30).
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
        _ = this.TabID;
    }

    public BetaBrowserWaitInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserWaitInput(BetaBrowserWaitInput betaBrowserWaitInput)
        : base(betaBrowserWaitInput) { }
#pragma warning restore CS8618

    public BetaBrowserWaitInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserWaitInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserWaitInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserWaitInput(double duration)
        : this()
    {
        this.Duration = duration;
    }
}

class BetaBrowserWaitInputFromRaw : IFromRawJson<BetaBrowserWaitInput>
{
    /// <inheritdoc/>
    public BetaBrowserWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserWaitInput.FromRawUnchecked(rawData);
}
