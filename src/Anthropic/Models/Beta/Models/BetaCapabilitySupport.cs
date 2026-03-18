using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Indicates whether a capability is supported.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCapabilitySupport, BetaCapabilitySupportFromRaw>))]
public sealed record class BetaCapabilitySupport : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Supported;
    }

    public BetaCapabilitySupport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCapabilitySupport(BetaCapabilitySupport betaCapabilitySupport)
        : base(betaCapabilitySupport) { }
#pragma warning restore CS8618

    public BetaCapabilitySupport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCapabilitySupport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCapabilitySupportFromRaw.FromRawUnchecked"/>
    public static BetaCapabilitySupport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCapabilitySupport(bool supported)
        : this()
    {
        this.Supported = supported;
    }
}

class BetaCapabilitySupportFromRaw : IFromRawJson<BetaCapabilitySupport>
{
    /// <inheritdoc/>
    public BetaCapabilitySupport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCapabilitySupport.FromRawUnchecked(rawData);
}
