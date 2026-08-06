using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Cumulative count of server-executed tool invocations, broken down by tool.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsServerToolUsage,
        BetaManagedAgentsServerToolUsageFromRaw
    >)
)]
public sealed record class BetaManagedAgentsServerToolUsage : JsonModel
{
    /// <summary>
    /// Number of server-executed web fetch requests.
    /// </summary>
    public int? WebFetchRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("web_fetch_requests");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("web_fetch_requests", value);
        }
    }

    /// <summary>
    /// Number of server-executed web search requests.
    /// </summary>
    public int? WebSearchRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("web_search_requests");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("web_search_requests", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebFetchRequests;
        _ = this.WebSearchRequests;
    }

    public BetaManagedAgentsServerToolUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsServerToolUsage(
        BetaManagedAgentsServerToolUsage betaManagedAgentsServerToolUsage
    )
        : base(betaManagedAgentsServerToolUsage) { }
#pragma warning restore CS8618

    public BetaManagedAgentsServerToolUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsServerToolUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsServerToolUsageFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsServerToolUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsServerToolUsageFromRaw : IFromRawJson<BetaManagedAgentsServerToolUsage>
{
    /// <inheritdoc/>
    public BetaManagedAgentsServerToolUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsServerToolUsage.FromRawUnchecked(rawData);
}
