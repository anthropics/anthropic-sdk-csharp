using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Compaction capability details: whether the model accepts the top-level `compaction`
/// request parameter, with one entry per supported `compaction.type` value.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaCompactionCapability, BetaCompactionCapabilityFromRaw>)
)]
public sealed record class BetaCompactionCapability : JsonModel
{
    /// <summary>
    /// Whether the summarize compaction type is supported.
    /// </summary>
    public required BetaCapabilitySupport Summarize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("summarize");
        }
        init { this._rawData.Set("summarize", value); }
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
        this.Summarize.Validate();
        _ = this.Supported;
    }

    public BetaCompactionCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionCapability(BetaCompactionCapability betaCompactionCapability)
        : base(betaCompactionCapability) { }
#pragma warning restore CS8618

    public BetaCompactionCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionCapabilityFromRaw.FromRawUnchecked"/>
    public static BetaCompactionCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCompactionCapabilityFromRaw : IFromRawJson<BetaCompactionCapability>
{
    /// <inheritdoc/>
    public BetaCompactionCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompactionCapability.FromRawUnchecked(rawData);
}
