using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUsage>))]
public sealed record class BetaServerToolUsage : ModelBase, IFromRaw<BetaServerToolUsage>
{
    /// <summary>
    /// The number of web fetch tool requests.
    /// </summary>
    public required long WebFetchRequests
    {
        get
        {
            if (!this.Properties.TryGetValue("web_fetch_requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'web_fetch_requests' cannot be null",
                    new ArgumentOutOfRangeException(
                        "web_fetch_requests",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["web_fetch_requests"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of web search tool requests.
    /// </summary>
    public required long WebSearchRequests
    {
        get
        {
            if (!this.Properties.TryGetValue("web_search_requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'web_search_requests' cannot be null",
                    new ArgumentOutOfRangeException(
                        "web_search_requests",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["web_search_requests"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.WebFetchRequests;
        _ = this.WebSearchRequests;
    }

    public BetaServerToolUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaServerToolUsage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
