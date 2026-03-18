using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Indicates whether a capability is supported.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CapabilitySupport, CapabilitySupportFromRaw>))]
public sealed record class CapabilitySupport : JsonModel
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

    public CapabilitySupport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilitySupport(CapabilitySupport capabilitySupport)
        : base(capabilitySupport) { }
#pragma warning restore CS8618

    public CapabilitySupport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilitySupport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CapabilitySupportFromRaw.FromRawUnchecked"/>
    public static CapabilitySupport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CapabilitySupport(bool supported)
        : this()
    {
        this.Supported = supported;
    }
}

class CapabilitySupportFromRaw : IFromRawJson<CapabilitySupport>
{
    /// <inheritdoc/>
    public CapabilitySupport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CapabilitySupport.FromRawUnchecked(rawData);
}
