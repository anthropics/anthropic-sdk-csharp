using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Activity in Chat and Cowork unified for one user on one day: `chat` holds chat
/// activity and `sessions` holds Cowork session activity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsChatCoworkUnifiedMetrics,
        AnalyticsChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class AnalyticsChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// Chat activity recorded while members had Chat and Cowork unified turned on.
    /// </summary>
    public required AnalyticsChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsChatCoworkUnifiedChatMetrics>("chat");
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// Cowork session activity recorded while members had Chat and Cowork unified
    /// turned on.
    /// </summary>
    public required AnalyticsChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsChatCoworkUnifiedSessionsMetrics>(
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

    public AnalyticsChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsChatCoworkUnifiedMetrics(
        AnalyticsChatCoworkUnifiedMetrics analyticsChatCoworkUnifiedMetrics
    )
        : base(analyticsChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public AnalyticsChatCoworkUnifiedMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsChatCoworkUnifiedMetricsFromRaw : IFromRawJson<AnalyticsChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public AnalyticsChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
