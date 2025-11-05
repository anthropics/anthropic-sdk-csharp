using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

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
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("allowed_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["allowed_domains"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("blocked_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["blocked_domains"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("max_uses", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["max_uses"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("user_location", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserLocation?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["user_location"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Name;
        _ = this.Type;
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        _ = this.MaxUses;
        this.UserLocation?.Validate();
    }

    public WebSearchTool20250305()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

    public WebSearchTool20250305(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchTool20250305(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static WebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Parameters for the user's location. Used to provide more relevant search results.
/// </summary>
[JsonConverter(typeof(ModelConverter<UserLocation>))]
public sealed record class UserLocation : ModelBase, IFromRaw<UserLocation>
{
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The city of the user.
    /// </summary>
    public string? City
    {
        get
        {
            if (!this._properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["city"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The two letter [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// of the user.
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this._properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The region of the user.
    /// </summary>
    public string? Region
    {
        get
        {
            if (!this._properties.TryGetValue("region", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["region"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The [IANA timezone](https://nodatime.org/TimeZones) of the user.
    /// </summary>
    public string? Timezone
    {
        get
        {
            if (!this._properties.TryGetValue("timezone", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timezone"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Type;
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public UserLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

    public UserLocation(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserLocation(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UserLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
