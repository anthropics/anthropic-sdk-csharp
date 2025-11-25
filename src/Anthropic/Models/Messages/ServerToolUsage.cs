using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ServerToolUsage, ServerToolUsageFromRaw>))]
public sealed record class ServerToolUsage : ModelBase
{
    /// <summary>
    /// The number of web search tool requests.
    /// </summary>
    public required long WebSearchRequests
    {
        get
        {
            if (!this._rawData.TryGetValue("web_search_requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'web_search_requests' cannot be null",
                    new ArgumentOutOfRangeException(
                        "web_search_requests",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["web_search_requests"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    public ServerToolUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ServerToolUsage.FromRawUnchecked(rawData);
}
