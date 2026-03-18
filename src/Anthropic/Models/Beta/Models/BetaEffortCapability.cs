using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Effort (reasoning_effort) capability details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaEffortCapability, BetaEffortCapabilityFromRaw>))]
public sealed record class BetaEffortCapability : JsonModel
{
    /// <summary>
    /// Whether the model supports high effort level.
    /// </summary>
    public required BetaCapabilitySupport High
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("high");
        }
        init { this._rawData.Set("high", value); }
    }

    /// <summary>
    /// Whether the model supports low effort level.
    /// </summary>
    public required BetaCapabilitySupport Low
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("low");
        }
        init { this._rawData.Set("low", value); }
    }

    /// <summary>
    /// Whether the model supports max effort level.
    /// </summary>
    public required BetaCapabilitySupport Max
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("max");
        }
        init { this._rawData.Set("max", value); }
    }

    /// <summary>
    /// Whether the model supports medium effort level.
    /// </summary>
    public required BetaCapabilitySupport Medium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("medium");
        }
        init { this._rawData.Set("medium", value); }
    }

    /// <summary>
    /// Whether this capability is supported by the model.
    /// </summary>
    public required bool Supported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("supported");
        }
        init { this._rawData.Set("supported", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.High.Validate();
        this.Low.Validate();
        this.Max.Validate();
        this.Medium.Validate();
        _ = this.Supported;
    }

    public BetaEffortCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEffortCapability(BetaEffortCapability betaEffortCapability)
        : base(betaEffortCapability) { }
#pragma warning restore CS8618

    public BetaEffortCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEffortCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEffortCapabilityFromRaw.FromRawUnchecked"/>
    public static BetaEffortCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEffortCapabilityFromRaw : IFromRawJson<BetaEffortCapability>
{
    /// <inheritdoc/>
    public BetaEffortCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEffortCapability.FromRawUnchecked(rawData);
}
