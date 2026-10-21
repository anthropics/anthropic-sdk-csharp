using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsServerToolUse, BetaAnalyticsServerToolUseFromRaw>)
)]
public sealed record class BetaAnalyticsServerToolUse : JsonModel
{
    /// <summary>
    /// The number of web search requests made.
    /// </summary>
    public required long WebSearchRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("web_search_requests");
        }
        init { this._rawData.Set("web_search_requests", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebSearchRequests;
    }

    public BetaAnalyticsServerToolUse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsServerToolUse(BetaAnalyticsServerToolUse betaAnalyticsServerToolUse)
        : base(betaAnalyticsServerToolUse) { }
#pragma warning restore CS8618

    public BetaAnalyticsServerToolUse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsServerToolUse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsServerToolUseFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsServerToolUse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsServerToolUse(long webSearchRequests)
        : this()
    {
        this.WebSearchRequests = webSearchRequests;
    }
}

class BetaAnalyticsServerToolUseFromRaw : IFromRawJson<BetaAnalyticsServerToolUse>
{
    /// <inheritdoc/>
    public BetaAnalyticsServerToolUse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsServerToolUse.FromRawUnchecked(rawData);
}
