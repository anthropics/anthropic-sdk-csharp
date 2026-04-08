using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// URL-based MCP server connection.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUrlMcpServerParams,
        BetaManagedAgentsUrlMcpServerParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUrlMcpServerParams : JsonModel
{
    /// <summary>
    /// Unique name for this server, referenced by mcp_toolset configurations. 1-255 characters.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUrlMcpServerParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Endpoint URL for the MCP server.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type.Validate();
        _ = this.Url;
    }

    public BetaManagedAgentsUrlMcpServerParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUrlMcpServerParams(
        BetaManagedAgentsUrlMcpServerParams betaManagedAgentsUrlMcpServerParams
    )
        : base(betaManagedAgentsUrlMcpServerParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUrlMcpServerParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUrlMcpServerParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUrlMcpServerParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUrlMcpServerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUrlMcpServerParamsFromRaw : IFromRawJson<BetaManagedAgentsUrlMcpServerParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUrlMcpServerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUrlMcpServerParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUrlMcpServerParamsTypeConverter))]
public enum BetaManagedAgentsUrlMcpServerParamsType
{
    Url,
}

sealed class BetaManagedAgentsUrlMcpServerParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUrlMcpServerParamsType>
{
    public override BetaManagedAgentsUrlMcpServerParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "url" => BetaManagedAgentsUrlMcpServerParamsType.Url,
            _ => (BetaManagedAgentsUrlMcpServerParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUrlMcpServerParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUrlMcpServerParamsType.Url => "url",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
