using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Context management capability details.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaContextManagementCapability,
        BetaContextManagementCapabilityFromRaw
    >)
)]
public sealed record class BetaContextManagementCapability : JsonModel
{
    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required BetaCapabilitySupport? ClearThinking20251015
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCapabilitySupport>("clear_thinking_20251015");
        }
        init { this._rawData.Set("clear_thinking_20251015", value); }
    }

    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required BetaCapabilitySupport? ClearToolUses20250919
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCapabilitySupport>(
                "clear_tool_uses_20250919"
            );
        }
        init { this._rawData.Set("clear_tool_uses_20250919", value); }
    }

    /// <summary>
    /// Indicates whether a capability is supported.
    /// </summary>
    public required BetaCapabilitySupport? Compact20260112
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCapabilitySupport>("compact_20260112");
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

    public BetaContextManagementCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaContextManagementCapability(
        BetaContextManagementCapability betaContextManagementCapability
    )
        : base(betaContextManagementCapability) { }
#pragma warning restore CS8618

    public BetaContextManagementCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContextManagementCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContextManagementCapabilityFromRaw.FromRawUnchecked"/>
    public static BetaContextManagementCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaContextManagementCapabilityFromRaw : IFromRawJson<BetaContextManagementCapability>
{
    /// <inheritdoc/>
    public BetaContextManagementCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContextManagementCapability.FromRawUnchecked(rawData);
}
