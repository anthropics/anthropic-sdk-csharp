using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUsage, BetaServerToolUsageFromRaw>))]
public sealed record class BetaServerToolUsage : ModelBase
{
    /// <summary>
    /// The number of web fetch tool requests.
    /// </summary>
    public required long WebFetchRequests
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "web_fetch_requests"); }
        init { ModelBase.Set(this._rawData, "web_fetch_requests", value); }
    }

    /// <summary>
    /// The number of web search tool requests.
    /// </summary>
    public required long WebSearchRequests
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "web_search_requests"); }
        init { ModelBase.Set(this._rawData, "web_search_requests", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebFetchRequests;
        _ = this.WebSearchRequests;
    }

    public BetaServerToolUsage() { }

    public BetaServerToolUsage(BetaServerToolUsage betaServerToolUsage)
        : base(betaServerToolUsage) { }

    public BetaServerToolUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaServerToolUsageFromRaw : IFromRaw<BetaServerToolUsage>
{
    /// <inheritdoc/>
    public BetaServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaServerToolUsage.FromRawUnchecked(rawData);
}
