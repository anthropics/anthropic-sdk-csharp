using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Thinking capability details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaThinkingCapability, BetaThinkingCapabilityFromRaw>))]
public sealed record class BetaThinkingCapability : JsonModel
{
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

    /// <summary>
    /// Supported thinking type configurations.
    /// </summary>
    public required BetaThinkingTypes Types
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaThinkingTypes>("types");
        }
        init { this._rawData.Set("types", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Supported;
        this.Types.Validate();
    }

    public BetaThinkingCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingCapability(BetaThinkingCapability betaThinkingCapability)
        : base(betaThinkingCapability) { }
#pragma warning restore CS8618

    public BetaThinkingCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingCapabilityFromRaw.FromRawUnchecked"/>
    public static BetaThinkingCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingCapabilityFromRaw : IFromRawJson<BetaThinkingCapability>
{
    /// <inheritdoc/>
    public BetaThinkingCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingCapability.FromRawUnchecked(rawData);
}
