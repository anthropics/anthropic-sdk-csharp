using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

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
            if (!this._properties.TryGetValue("web_fetch_requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'web_fetch_requests' cannot be null",
                    new ArgumentOutOfRangeException(
                        "web_fetch_requests",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["web_fetch_requests"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("web_search_requests", out JsonElement element))
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
            this._properties["web_search_requests"] = JsonSerializer.SerializeToElement(
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

    public BetaServerToolUsage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUsage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaServerToolUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
