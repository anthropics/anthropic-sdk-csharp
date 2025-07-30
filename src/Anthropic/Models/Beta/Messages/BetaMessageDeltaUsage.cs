using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMessageDeltaUsage>))]
public sealed record class BetaMessageDeltaUsage : ModelBase, IFromRaw<BetaMessageDeltaUsage>
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            if (
                !this.Properties.TryGetValue("cache_creation_input_tokens", out JsonElement element)
            )
                throw new global::System.ArgumentOutOfRangeException(
                    "cache_creation_input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["cache_creation_input_tokens"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The cumulative number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_read_input_tokens", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "cache_read_input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["cache_read_input_tokens"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["input_tokens"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The cumulative number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("output_tokens", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "output_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["output_tokens"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            if (!this.Properties.TryGetValue("server_tool_use", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "server_tool_use",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaServerToolUsage?>(element);
        }
        set { this.Properties["server_tool_use"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public BetaMessageDeltaUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageDeltaUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageDeltaUsage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
