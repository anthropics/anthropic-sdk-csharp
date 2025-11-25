using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchTool20250305, WebSearchTool20250305FromRaw>))]
public sealed record class WebSearchTool20250305 : ModelBase
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("allowed_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["allowed_domains"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("blocked_domains", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["blocked_domains"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("max_uses", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["max_uses"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("user_location", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserLocation?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["user_location"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"web_search\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
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

    public WebSearchTool20250305(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchTool20250305(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static WebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchTool20250305FromRaw : IFromRaw<WebSearchTool20250305>
{
    public WebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchTool20250305.FromRawUnchecked(rawData);
}

/// <summary>
/// Parameters for the user's location. Used to provide more relevant search results.
/// </summary>
[JsonConverter(typeof(ModelConverter<UserLocation, UserLocationFromRaw>))]
public sealed record class UserLocation : ModelBase
{
    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["city"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["country"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("region", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["region"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("timezone", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["timezone"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"approximate\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public UserLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

    public UserLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static UserLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserLocationFromRaw : IFromRaw<UserLocation>
{
    public UserLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserLocation.FromRawUnchecked(rawData);
}
