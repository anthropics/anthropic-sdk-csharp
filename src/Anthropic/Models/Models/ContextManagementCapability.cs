using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Context management capability details.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ContextManagementCapability, ContextManagementCapabilityFromRaw>)
)]
public sealed record class ContextManagementCapability : JsonModel
{
    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required CapabilitySupport? ClearThinking20251015
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CapabilitySupport>("clear_thinking_20251015");
        }
        init { this._rawData.Set("clear_thinking_20251015", value); }
    }

    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required CapabilitySupport? ClearToolUses20250919
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CapabilitySupport>("clear_tool_uses_20250919");
        }
        init { this._rawData.Set("clear_tool_uses_20250919", value); }
    }

    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required CapabilitySupport? Compact20260112
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CapabilitySupport>("compact_20260112");
        }
        init { this._rawData.Set("compact_20260112", value); }
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
        this.ClearThinking20251015?.Validate();
        this.ClearToolUses20250919?.Validate();
        this.Compact20260112?.Validate();
        _ = this.Supported;
    }

    public ContextManagementCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContextManagementCapability(ContextManagementCapability contextManagementCapability)
        : base(contextManagementCapability) { }
#pragma warning restore CS8618

    public ContextManagementCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextManagementCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContextManagementCapabilityFromRaw.FromRawUnchecked"/>
    public static ContextManagementCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextManagementCapabilityFromRaw : IFromRawJson<ContextManagementCapability>
{
    /// <inheritdoc/>
    public ContextManagementCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContextManagementCapability.FromRawUnchecked(rawData);
}
