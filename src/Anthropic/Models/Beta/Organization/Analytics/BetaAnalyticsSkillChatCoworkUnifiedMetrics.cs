using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A skill's use in Chat and Cowork unified on one day: `chat` holds its use in
/// chat conversations and `sessions` its use in Cowork sessions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSkillChatCoworkUnifiedMetrics,
        BetaAnalyticsSkillChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsSkillChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A skill's use in chat conversations recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required BetaAnalyticsSkillChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillChatCoworkUnifiedChatMetrics>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A skill's use in Cowork sessions recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics>(
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

    public BetaAnalyticsSkillChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillChatCoworkUnifiedMetrics(
        BetaAnalyticsSkillChatCoworkUnifiedMetrics betaAnalyticsSkillChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsSkillChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsSkillChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsSkillChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
