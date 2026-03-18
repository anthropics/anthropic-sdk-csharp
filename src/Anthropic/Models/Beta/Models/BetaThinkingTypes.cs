using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Supported thinking type configurations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaThinkingTypes, BetaThinkingTypesFromRaw>))]
public sealed record class BetaThinkingTypes : JsonModel
{
    /// <summary>
    /// Whether the model supports thinking with type 'adaptive' (auto).
    /// </summary>
    public required BetaCapabilitySupport Adaptive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("adaptive");
        }
        init { this._rawData.Set("adaptive", value); }
    }

    /// <summary>
    /// Whether the model supports thinking with type 'enabled'.
    /// </summary>
    public required BetaCapabilitySupport Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adaptive.Validate();
        this.Enabled.Validate();
    }

    public BetaThinkingTypes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingTypes(BetaThinkingTypes betaThinkingTypes)
        : base(betaThinkingTypes) { }
#pragma warning restore CS8618

    public BetaThinkingTypes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingTypes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingTypesFromRaw.FromRawUnchecked"/>
    public static BetaThinkingTypes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingTypesFromRaw : IFromRawJson<BetaThinkingTypes>
{
    /// <inheritdoc/>
    public BetaThinkingTypes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingTypes.FromRawUnchecked(rawData);
}
