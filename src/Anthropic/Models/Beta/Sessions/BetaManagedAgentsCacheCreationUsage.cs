using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Prompt-cache creation token usage broken down by cache lifetime.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCacheCreationUsage,
        BetaManagedAgentsCacheCreationUsageFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCacheCreationUsage : JsonModel
{
    /// <summary>
    /// Tokens used to create 1-hour ephemeral cache entries.
    /// </summary>
    public int? Ephemeral1hInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("ephemeral_1h_input_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ephemeral_1h_input_tokens", value);
        }
    }

    /// <summary>
    /// Tokens used to create 5-minute ephemeral cache entries.
    /// </summary>
    public int? Ephemeral5mInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("ephemeral_5m_input_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ephemeral_5m_input_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public BetaManagedAgentsCacheCreationUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCacheCreationUsage(
        BetaManagedAgentsCacheCreationUsage betaManagedAgentsCacheCreationUsage
    )
        : base(betaManagedAgentsCacheCreationUsage) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCacheCreationUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCacheCreationUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCacheCreationUsageFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCacheCreationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCacheCreationUsageFromRaw : IFromRawJson<BetaManagedAgentsCacheCreationUsage>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCacheCreationUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCacheCreationUsage.FromRawUnchecked(rawData);
}
