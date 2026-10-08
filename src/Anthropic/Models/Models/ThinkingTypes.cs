using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Which `thinking.type` values the model accepts on requests. Read each key on
/// its own: for example, `enabled` can be false while `disabled` is true.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ThinkingTypes, ThinkingTypesFromRaw>))]
public sealed record class ThinkingTypes : JsonModel
{
    /// <summary>
    /// Whether the model accepts thinking with type 'adaptive' (the model decides
    /// whether and how much to think).
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
    /// Whether the model accepts thinking with type 'disabled' (thinking turned
    /// off). False exactly when a request that sends it gets a 400 from this model.
    /// True on a model that does not support thinking.
    /// </summary>
    public required CapabilitySupport Disabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("disabled");
        }
        init { this._rawData.Set("disabled", value); }
    }

    /// <summary>
    /// Whether the model accepts thinking with type 'enabled' (extended thinking
    /// with a caller-set `budget_tokens`).
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
        this.Disabled.Validate();
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
