using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ServerToolUsage>))]
public sealed record class ServerToolUsage : ModelBase, IFromRaw<ServerToolUsage>
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

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["web_search_requests"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.WebSearchRequests;
    }

    public ServerToolUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ServerToolUsage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
