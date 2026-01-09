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
[JsonConverter(typeof(JsonModelConverter<BetaMCPToolset, BetaMCPToolsetFromRaw>))]
public sealed record class BetaMCPToolset : JsonModel
{
    /// <summary>
    /// Name of the MCP server to configure tools for
    /// </summary>
    public required string MCPServerName
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "mcp_server_name"); }
        init { JsonModel.Set(this._rawData, "mcp_server_name", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    /// <summary>
    /// Configuration overrides for specific tools, keyed by tool name
    /// </summary>
    public IReadOnlyDictionary<string, BetaMCPToolConfig>? Configs
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, BetaMCPToolConfig>>(
                this.RawData,
                "configs"
            );
        }
        init { JsonModel.Set(this._rawData, "configs", value); }
    }

    /// <summary>
    /// Default configuration applied to all tools from this server
    /// </summary>
    public BetaMCPToolDefaultConfig? DefaultConfig
    {
        get
        {
            return JsonModel.GetNullableClass<BetaMCPToolDefaultConfig>(
                this.RawData,
                "default_config"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "default_config", value);
        }
    }

    /// <inheritdoc/>
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

    public BetaMCPToolset(BetaMCPToolset betaMCPToolset)
        : base(betaMCPToolset) { }

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

    /// <inheritdoc cref="BetaMCPToolsetFromRaw.FromRawUnchecked"/>
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

class BetaMCPToolsetFromRaw : IFromRawJson<BetaMCPToolset>
{
    /// <inheritdoc/>
    public BetaMCPToolset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMCPToolset.FromRawUnchecked(rawData);
}
