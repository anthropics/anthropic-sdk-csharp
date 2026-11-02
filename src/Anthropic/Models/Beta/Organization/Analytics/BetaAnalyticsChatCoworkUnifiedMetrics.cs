using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Activity in Chat and Cowork unified for one user on one day: `chat` holds chat
/// activity and `sessions` holds Cowork session activity.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsChatCoworkUnifiedMetrics,
        BetaAnalyticsChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// Chat activity recorded while members had Chat and Cowork unified turned on.
    /// </summary>
    public required BetaAnalyticsChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsChatCoworkUnifiedChatMetrics>("chat");
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// Cowork session activity recorded while members had Chat and Cowork unified
    /// turned on.
    /// </summary>
    public required BetaAnalyticsChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsChatCoworkUnifiedSessionsMetrics>(
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

    public BetaAnalyticsChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsChatCoworkUnifiedMetrics(
        BetaAnalyticsChatCoworkUnifiedMetrics betaAnalyticsChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsChatCoworkUnifiedMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
