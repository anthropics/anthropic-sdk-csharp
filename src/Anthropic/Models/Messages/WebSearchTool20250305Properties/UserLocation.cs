using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.WebSearchTool20250305Properties;

/// <summary>
/// Parameters for the user's location. Used to provide more relevant search results.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<UserLocation>))]
public sealed record class UserLocation : Anthropic::ModelBase, Anthropic::IFromRaw<UserLocation>
{
    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The city of the user.
    /// </summary>
    public string? City
    {
        get
        {
            if (!this.Properties.TryGetValue("city", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["city"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The two letter [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// of the user.
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["country"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The region of the user.
    /// </summary>
    public string? Region
    {
        get
        {
            if (!this.Properties.TryGetValue("region", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["region"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The [IANA timezone](https://nodatime.org/TimeZones) of the user.
    /// </summary>
    public string? Timezone
    {
        get
        {
            if (!this.Properties.TryGetValue("timezone", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["timezone"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"approximate\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    UserLocation(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UserLocation FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
