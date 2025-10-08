using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebSearchTool20250305Properties;

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
    /// The city of the user.
    /// </summary>
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["city"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("region", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["region"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("timezone", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timezone"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public UserLocation()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserLocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UserLocation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
