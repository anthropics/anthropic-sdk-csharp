using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Configuration for tools from an MCP server defined in `mcp_servers`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpToolsetParams,
        BetaManagedAgentsMcpToolsetParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpToolsetParams : JsonModel
{
    /// <summary>
    /// Name of the MCP server. Must match a server name from the mcp_servers array.
    /// 1-255 characters.
    /// </summary>
    public required string McpServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_name");
        }
        init { this._rawData.Set("mcp_server_name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Per-tool configuration overrides.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsMcpToolConfigParams>? Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsMcpToolConfigParams>
            >("configs");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("configs");
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsMcpToolConfigParams>?>(
                "configs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default configuration for all tools from this server.
    /// </summary>
    public BetaManagedAgentsMcpToolsetDefaultConfigParams? DefaultConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpToolsetDefaultConfigParams>(
                "default_config"
            );
        }
        init { this._rawData.Set("default_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.McpServerName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_toolset")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Configs ?? [])
        {
            item.Validate();
        }
        this.DefaultConfig?.Validate();
    }

    public BetaManagedAgentsMcpToolsetParams()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_toolset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpToolsetParams(
        BetaManagedAgentsMcpToolsetParams betaManagedAgentsMcpToolsetParams
    )
        : base(betaManagedAgentsMcpToolsetParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpToolsetParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_toolset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpToolsetParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpToolsetParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpToolsetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMcpToolsetParams(string mcpServerName)
        : this()
    {
        this.McpServerName = mcpServerName;
    }
}

class BetaManagedAgentsMcpToolsetParamsFromRaw : IFromRawJson<BetaManagedAgentsMcpToolsetParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpToolsetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpToolsetParams.FromRawUnchecked(rawData);
}
