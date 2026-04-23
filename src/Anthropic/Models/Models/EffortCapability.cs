using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Effort (reasoning_effort) capability details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EffortCapability, EffortCapabilityFromRaw>))]
public sealed record class EffortCapability : JsonModel
{
    /// <summary>
    /// Whether the model supports high effort level.
    /// </summary>
    public required CapabilitySupport High
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("high");
        }
        init { this._rawData.Set("high", value); }
    }

    /// <summary>
    /// Whether the model supports low effort level.
    /// </summary>
    public required CapabilitySupport Low
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("low");
        }
        init { this._rawData.Set("low", value); }
    }

    /// <summary>
    /// Whether the model supports max effort level.
    /// </summary>
    public required CapabilitySupport Max
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("max");
        }
        init { this._rawData.Set("max", value); }
    }

    /// <summary>
    /// Whether the model supports medium effort level.
    /// </summary>
    public required CapabilitySupport Medium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("medium");
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

    public EffortCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EffortCapability(EffortCapability effortCapability)
        : base(effortCapability) { }
#pragma warning restore CS8618

    public EffortCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EffortCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EffortCapabilityFromRaw.FromRawUnchecked"/>
    public static EffortCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EffortCapabilityFromRaw : IFromRawJson<EffortCapability>
{
    /// <inheritdoc/>
    public EffortCapability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EffortCapability.FromRawUnchecked(rawData);
}
