using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.WebSearchTool20250305Properties;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchTool20250305>))]
public sealed record class WebSearchTool20250305 : ModelBase, IFromRaw<WebSearchTool20250305>
{
    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, only these domains will be included in results. Cannot be used
    /// alongside `blocked_domains`.
    /// </summary>
    public List<string>? AllowedDomains
    {
        get
        {
            if (!this.Properties.TryGetValue("allowed_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allowed_domains"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, these domains will never appear in results. Cannot be used alongside `allowed_domains`.
    /// </summary>
    public List<string>? BlockedDomains
    {
        get
        {
            if (!this.Properties.TryGetValue("blocked_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["blocked_domains"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get
        {
            if (!this.Properties.TryGetValue("max_uses", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["max_uses"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Parameters for the user's location. Used to provide more relevant search results.
    /// </summary>
    public UserLocation? UserLocation
    {
        get
        {
            if (!this.Properties.TryGetValue("user_location", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserLocation?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["user_location"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.AllowedDomains ?? [])
        {
            _ = item;
        }
        foreach (var item in this.BlockedDomains ?? [])
        {
            _ = item;
        }
        this.CacheControl?.Validate();
        _ = this.MaxUses;
        this.UserLocation?.Validate();
    }

    public WebSearchTool20250305()
    {
        this.Name = new();
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchTool20250305(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchTool20250305 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
