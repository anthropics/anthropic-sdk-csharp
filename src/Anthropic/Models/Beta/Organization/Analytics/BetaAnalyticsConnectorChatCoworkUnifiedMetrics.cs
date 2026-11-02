using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A connector's use in Chat and Cowork unified on one day: `chat` holds its use
/// in chat conversations and `sessions` its use in Cowork sessions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorChatCoworkUnifiedMetrics,
        BetaAnalyticsConnectorChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A connector's use in chat conversations recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A connector's use in Cowork sessions recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required BetaAnalyticsConnectorChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorChatCoworkUnifiedSessionsMetrics>(
                "sessions"
            );
        }
        init { this._rawData.Set("sessions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Chat.Validate();
        this.Sessions.Validate();
    }

    public BetaAnalyticsConnectorChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorChatCoworkUnifiedMetrics(
        BetaAnalyticsConnectorChatCoworkUnifiedMetrics betaAnalyticsConnectorChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsConnectorChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsConnectorChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsConnectorChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
