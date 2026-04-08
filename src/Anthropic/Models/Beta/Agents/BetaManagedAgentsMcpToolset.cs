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

    public required ApiEnum<string, BetaManagedAgentsMcpToolsetType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsMcpToolsetType>>(
                "type"
            );
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
        this.Type.Validate();
    }

    public BetaManagedAgentsMcpToolset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpToolset(BetaManagedAgentsMcpToolset betaManagedAgentsMcpToolset)
        : base(betaManagedAgentsMcpToolset) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpToolset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(BetaManagedAgentsMcpToolsetTypeConverter))]
public enum BetaManagedAgentsMcpToolsetType
{
    McpToolset,
}

sealed class BetaManagedAgentsMcpToolsetTypeConverter
    : JsonConverter<BetaManagedAgentsMcpToolsetType>
{
    public override BetaManagedAgentsMcpToolsetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_toolset" => BetaManagedAgentsMcpToolsetType.McpToolset,
            _ => (BetaManagedAgentsMcpToolsetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpToolsetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpToolsetType.McpToolset => "mcp_toolset",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
