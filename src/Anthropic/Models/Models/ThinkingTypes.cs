using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Supported thinking type configurations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThinkingTypes, ThinkingTypesFromRaw>))]
public sealed record class ThinkingTypes : JsonModel
{
    /// <summary>
    /// Whether the model supports thinking with type 'adaptive' (auto).
    /// </summary>
    public required CapabilitySupport Adaptive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("adaptive");
        }
        init { this._rawData.Set("adaptive", value); }
    }

    /// <summary>
    /// Whether the model supports thinking with type 'enabled'.
    /// </summary>
    public required CapabilitySupport Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adaptive.Validate();
        this.Enabled.Validate();
    }

    public ThinkingTypes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingTypes(ThinkingTypes thinkingTypes)
        : base(thinkingTypes) { }
#pragma warning restore CS8618

    public ThinkingTypes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingTypes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingTypesFromRaw.FromRawUnchecked"/>
    public static ThinkingTypes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThinkingTypesFromRaw : IFromRawJson<ThinkingTypes>
{
    /// <inheritdoc/>
    public ThinkingTypes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThinkingTypes.FromRawUnchecked(rawData);
}
