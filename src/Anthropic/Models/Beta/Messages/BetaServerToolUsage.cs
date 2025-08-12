using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaServerToolUsage>))]
public sealed record class BetaServerToolUsage
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaServerToolUsage>
{
    /// <summary>
    /// The number of web search tool requests.
    /// </summary>
    public required long WebSearchRequests
    {
        get
        {
            if (!this.Properties.TryGetValue("web_search_requests", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "web_search_requests",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["web_search_requests"] = JsonSerializer.SerializeToElement(value); }
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
