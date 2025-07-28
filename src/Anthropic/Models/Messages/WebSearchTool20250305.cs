using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;
using WebSearchTool20250305Properties = Anthropic.Models.Messages.WebSearchTool20250305Properties;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<WebSearchTool20250305>))]
public sealed record class WebSearchTool20250305
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<WebSearchTool20250305>
{
    /// <summary>
    /// Name of the tool.
    ///
    /// This is how the tool will be called by the model and in `tool_use` blocks.
    /// </summary>
    public Json::JsonElement Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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
    /// If provided, only these domains will be included in results. Cannot be used
    /// alongside `blocked_domains`.
    /// </summary>
    public Generic::List<string>? AllowedDomains
    {
        get
        {
            if (!this.Properties.TryGetValue("allowed_domains", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set { this.Properties["allowed_domains"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If provided, these domains will never appear in results. Cannot be used alongside `allowed_domains`.
    /// </summary>
    public Generic::List<string>? BlockedDomains
    {
        get
        {
            if (!this.Properties.TryGetValue("blocked_domains", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set { this.Properties["blocked_domains"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get
        {
            if (!this.Properties.TryGetValue("max_uses", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["max_uses"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Parameters for the user's location. Used to provide more relevant search results.
    /// </summary>
    public WebSearchTool20250305Properties::UserLocation? UserLocation
    {
        get
        {
            if (!this.Properties.TryGetValue("user_location", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<WebSearchTool20250305Properties::UserLocation?>(
                element
            );
        }
        set { this.Properties["user_location"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        if (
            !this.Name.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search\""))
        )
        {
            throw new System::Exception();
        }
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search_20250305\"")
            )
        )
        {
            throw new System::Exception();
        }
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
        this.Name = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search\"");
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search_20250305\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    WebSearchTool20250305(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchTool20250305 FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
