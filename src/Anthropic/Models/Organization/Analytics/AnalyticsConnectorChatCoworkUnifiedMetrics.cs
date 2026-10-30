using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A connector's use in Chat and Cowork unified on one day: `chat` holds its use
/// in chat conversations and `sessions` its use in Cowork sessions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorChatCoworkUnifiedMetrics,
        AnalyticsConnectorChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A connector's use in chat conversations recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required AnalyticsConnectorChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorChatCoworkUnifiedChatMetrics>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A connector's use in Cowork sessions recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required AnalyticsConnectorChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorChatCoworkUnifiedSessionsMetrics>(
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

    public AnalyticsConnectorChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorChatCoworkUnifiedMetrics(
        AnalyticsConnectorChatCoworkUnifiedMetrics analyticsConnectorChatCoworkUnifiedMetrics
    )
        : base(analyticsConnectorChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsConnectorChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<AnalyticsConnectorChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
