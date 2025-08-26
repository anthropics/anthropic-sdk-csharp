using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUsage>))]
public sealed record class BetaServerToolUsage : ModelBase, IFromRaw<BetaServerToolUsage>
{
    /// <summary>
    /// The number of web search tool requests.
    /// </summary>
    public required long WebSearchRequests
    {
        get
        {
            if (!this.Properties.TryGetValue("web_search_requests", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "web_search_requests",
                    "Missing required argument"
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

    [SetsRequiredMembers]
    public BetaServerToolUsage(long webSearchRequests)
        : this()
    {
        this.WebSearchRequests = webSearchRequests;
    }
}
