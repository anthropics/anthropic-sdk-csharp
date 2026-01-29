using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaServerToolUsage, BetaServerToolUsageFromRaw>))]
public sealed record class BetaServerToolUsage : JsonModel
{
    /// <summary>
    /// The number of web fetch tool requests.
    /// </summary>
    public required long WebFetchRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("web_fetch_requests");
        }
        init { this._rawData.Set("web_fetch_requests", value); }
    }

    /// <summary>
    /// The number of web search tool requests.
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
        _ = this.WebFetchRequests;
        _ = this.WebSearchRequests;
    }

    public BetaServerToolUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServerToolUsage(BetaServerToolUsage betaServerToolUsage)
        : base(betaServerToolUsage) { }
#pragma warning restore CS8618

    public BetaServerToolUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServerToolUsageFromRaw.FromRawUnchecked"/>
    public static BetaServerToolUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaServerToolUsageFromRaw : IFromRawJson<BetaServerToolUsage>
{
    /// <inheritdoc/>
    public BetaServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaServerToolUsage.FromRawUnchecked(rawData);
}
