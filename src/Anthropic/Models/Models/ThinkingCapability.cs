using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Thinking capability details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThinkingCapability, ThinkingCapabilityFromRaw>))]
public sealed record class ThinkingCapability : JsonModel
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
    public required ThinkingTypes Types
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ThinkingTypes>("types");
        }
        init { this._rawData.Set("types", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Supported;
        this.Types.Validate();
    }

    public ThinkingCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingCapability(ThinkingCapability thinkingCapability)
        : base(thinkingCapability) { }
#pragma warning restore CS8618

    public ThinkingCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingCapabilityFromRaw.FromRawUnchecked"/>
    public static ThinkingCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThinkingCapabilityFromRaw : IFromRawJson<ThinkingCapability>
{
    /// <inheritdoc/>
    public ThinkingCapability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThinkingCapability.FromRawUnchecked(rawData);
}
