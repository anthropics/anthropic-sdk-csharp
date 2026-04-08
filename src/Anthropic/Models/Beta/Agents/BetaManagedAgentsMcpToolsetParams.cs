using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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

    public required ApiEnum<string, BetaManagedAgentsMcpToolsetParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpToolsetParamsType>
            >("type");
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
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsMcpToolConfigParams>?>(
                "configs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default configuration for all tools from an MCP server.
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
        this.Type.Validate();
        foreach (var item in this.Configs ?? [])
        {
            item.Validate();
        }
        this.DefaultConfig?.Validate();
    }

    public BetaManagedAgentsMcpToolsetParams() { }

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
}

class BetaManagedAgentsMcpToolsetParamsFromRaw : IFromRawJson<BetaManagedAgentsMcpToolsetParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpToolsetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpToolsetParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMcpToolsetParamsTypeConverter))]
public enum BetaManagedAgentsMcpToolsetParamsType
{
    McpToolset,
}

sealed class BetaManagedAgentsMcpToolsetParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMcpToolsetParamsType>
{
    public override BetaManagedAgentsMcpToolsetParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_toolset" => BetaManagedAgentsMcpToolsetParamsType.McpToolset,
            _ => (BetaManagedAgentsMcpToolsetParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpToolsetParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpToolsetParamsType.McpToolset => "mcp_toolset",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
