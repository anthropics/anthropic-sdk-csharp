using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestMCPServerURLDefinition>))]
public sealed record class BetaRequestMCPServerURLDefinition
    : ModelBase,
        IFromRaw<BetaRequestMCPServerURLDefinition>
{
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
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
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? AuthorizationToken
    {
        get
        {
            if (!this.Properties.TryGetValue("authorization_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["authorization_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaRequestMCPServerToolConfiguration? ToolConfiguration
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaRequestMCPServerToolConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["tool_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMCPServerURLDefinition(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRequestMCPServerURLDefinition FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
