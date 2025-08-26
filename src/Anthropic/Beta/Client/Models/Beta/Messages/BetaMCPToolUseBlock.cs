using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMCPToolUseBlock>))]
public sealed record class BetaMCPToolUseBlock : ModelBase, IFromRaw<BetaMCPToolUseBlock>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required JsonElement Input
    {
        get
        {
            if (!this.Properties.TryGetValue("input", out JsonElement element))
                throw new ArgumentOutOfRangeException("input", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the MCP tool
    /// </summary>
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

    /// <summary>
    /// The name of the MCP server
    /// </summary>
    public required string ServerName
    {
        get
        {
            if (!this.Properties.TryGetValue("server_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("server_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("server_name");
        }
        set
        {
            this.Properties["server_name"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        _ = this.ServerName;
    }

    public BetaMCPToolUseBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolUseBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMCPToolUseBlock FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
