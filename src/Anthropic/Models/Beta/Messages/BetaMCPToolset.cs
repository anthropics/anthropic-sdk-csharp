using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Configuration for a group of tools from an MCP server.
///
/// <para>Allows configuring enabled status and defer_loading for all tools from
/// an MCP server, with optional per-tool overrides.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaMCPToolset, BetaMCPToolsetFromRaw>))]
public sealed record class BetaMCPToolset : ModelBase
{
    /// <summary>
    /// Name of the MCP server to configure tools for
    /// </summary>
    public required string MCPServerName
    {
        get
        {
            if (!this._rawData.TryGetValue("mcp_server_name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'mcp_server_name' cannot be null",
                    new ArgumentOutOfRangeException("mcp_server_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'mcp_server_name' cannot be null",
                    new ArgumentNullException("mcp_server_name")
                );
        }
        init
        {
            this._rawData["mcp_server_name"] = JsonSerializer.SerializeToElement(
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
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
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
    /// Configuration overrides for specific tools, keyed by tool name
    /// </summary>
    public Dictionary<string, BetaMCPToolConfig>? Configs
    {
        get
        {
            if (!this._rawData.TryGetValue("configs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, BetaMCPToolConfig>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["configs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Default configuration applied to all tools from this server
    /// </summary>
    public BetaMCPToolDefaultConfig? DefaultConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("default_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaMCPToolDefaultConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["default_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MCPServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        if (this.Configs != null)
        {
            foreach (var item in this.Configs.Values)
            {
                item.Validate();
            }
        }
        this.DefaultConfig?.Validate();
    }

    public BetaMCPToolset()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"");
    }

    public BetaMCPToolset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaMCPToolset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMCPToolset(string mcpServerName)
        : this()
    {
        this.MCPServerName = mcpServerName;
    }
}

class BetaMCPToolsetFromRaw : IFromRaw<BetaMCPToolset>
{
    public BetaMCPToolset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMCPToolset.FromRawUnchecked(rawData);
}
