using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsMcpToolset, BetaManagedAgentsMcpToolsetFromRaw>)
)]
public sealed record class BetaManagedAgentsMcpToolset : JsonModel
{
    public required IReadOnlyList<BetaManagedAgentsMcpToolConfig> Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsMcpToolConfig>>(
                "configs"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsMcpToolConfig>>(
                "configs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resolved default configuration for all tools from an MCP server.
    /// </summary>
    public required BetaManagedAgentsMcpToolsetDefaultConfig DefaultConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMcpToolsetDefaultConfig>(
                "default_config"
            );
        }
        init { this._rawData.Set("default_config", value); }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Configs)
        {
            item.Validate();
        }
        this.DefaultConfig.Validate();
        _ = this.McpServerName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_toolset")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMcpToolset()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_toolset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpToolset(BetaManagedAgentsMcpToolset betaManagedAgentsMcpToolset)
        : base(betaManagedAgentsMcpToolset) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpToolset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_toolset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpToolset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpToolsetFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpToolset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpToolsetFromRaw : IFromRawJson<BetaManagedAgentsMcpToolset>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpToolset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpToolset.FromRawUnchecked(rawData);
}
