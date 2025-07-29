using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaRequestMCPServerURLDefinition>))]
public sealed record class BetaRequestMCPServerURLDefinition
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRequestMCPServerURLDefinition>
{
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("url", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("url");
        }
        set { this.Properties["url"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? AuthorizationToken
    {
        get
        {
            if (!this.Properties.TryGetValue("authorization_token", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["authorization_token"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public BetaRequestMCPServerToolConfiguration? ToolConfiguration
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_configuration", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaRequestMCPServerToolConfiguration?>(
                element
            );
        }
        set
        {
            this.Properties["tool_configuration"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.Name;
        _ = this.URL;
        _ = this.AuthorizationToken;
        this.ToolConfiguration?.Validate();
    }

    public BetaRequestMCPServerURLDefinition()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaRequestMCPServerURLDefinition(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRequestMCPServerURLDefinition FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
