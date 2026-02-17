using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ServerToolUsage, ServerToolUsageFromRaw>))]
public sealed record class ServerToolUsage : JsonModel
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

    public ServerToolUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServerToolUsage(ServerToolUsage serverToolUsage)
        : base(serverToolUsage) { }
#pragma warning restore CS8618

    public ServerToolUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUsageFromRaw.FromRawUnchecked"/>
    public static ServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServerToolUsageFromRaw : IFromRawJson<ServerToolUsage>
{
    /// <inheritdoc/>
    public ServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ServerToolUsage.FromRawUnchecked(rawData);
}
