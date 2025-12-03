using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ServerToolUsage, ServerToolUsageFromRaw>))]
public sealed record class ServerToolUsage : ModelBase
{
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
        _ = this.WebSearchRequests;
    }

    public ServerToolUsage() { }

    public ServerToolUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUsageFromRaw.FromRawUnchecked"/>
    public static ServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ServerToolUsage(long webSearchRequests)
        : this()
    {
        this.WebSearchRequests = webSearchRequests;
    }
}

class ServerToolUsageFromRaw : IFromRaw<ServerToolUsage>
{
    /// <inheritdoc/>
    public ServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ServerToolUsage.FromRawUnchecked(rawData);
}
