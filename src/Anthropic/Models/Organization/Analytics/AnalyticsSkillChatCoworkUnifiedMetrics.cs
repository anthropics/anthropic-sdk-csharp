using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A skill's use in Chat and Cowork unified on one day: `chat` holds its use in
/// chat conversations and `sessions` its use in Cowork sessions.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsSkillChatCoworkUnifiedMetrics,
        AnalyticsSkillChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class AnalyticsSkillChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A skill's use in chat conversations recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required AnalyticsSkillChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillChatCoworkUnifiedChatMetrics>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A skill's use in Cowork sessions recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required AnalyticsSkillChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillChatCoworkUnifiedSessionsMetrics>(
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

    public AnalyticsSkillChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsSkillChatCoworkUnifiedMetrics(
        AnalyticsSkillChatCoworkUnifiedMetrics analyticsSkillChatCoworkUnifiedMetrics
    )
        : base(analyticsSkillChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public AnalyticsSkillChatCoworkUnifiedMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsSkillChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsSkillChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsSkillChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsSkillChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<AnalyticsSkillChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public AnalyticsSkillChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsSkillChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
