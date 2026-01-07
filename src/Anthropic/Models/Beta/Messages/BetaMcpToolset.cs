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
[JsonConverter(typeof(JsonModelConverter<BetaMcpToolset, BetaMcpToolsetFromRaw>))]
public sealed record class BetaMcpToolset : JsonModel
{
    /// <summary>
    /// Name of the MCP server to configure tools for
    /// </summary>
    public required string McpServerName
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
    public IReadOnlyDictionary<string, BetaMcpToolConfig>? Configs
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, BetaMcpToolConfig>>(
                this.RawData,
                "configs"
            );
        }
        init { JsonModel.Set(this._rawData, "configs", value); }
    }

    /// <summary>
    /// Default configuration applied to all tools from this server
    /// </summary>
    public BetaMcpToolDefaultConfig? DefaultConfig
    {
        get
        {
            return JsonModel.GetNullableClass<BetaMcpToolDefaultConfig>(
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
        _ = this.McpServerName;
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

    public BetaMcpToolset()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"");
    }

    public BetaMcpToolset(BetaMcpToolset betaMcpToolset)
        : base(betaMcpToolset) { }

    public BetaMcpToolset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_toolset\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolsetFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMcpToolset(string mcpServerName)
        : this()
    {
        this.McpServerName = mcpServerName;
    }
}

class BetaMcpToolsetFromRaw : IFromRawJson<BetaMcpToolset>
{
    /// <inheritdoc/>
    public BetaMcpToolset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMcpToolset.FromRawUnchecked(rawData);
}
