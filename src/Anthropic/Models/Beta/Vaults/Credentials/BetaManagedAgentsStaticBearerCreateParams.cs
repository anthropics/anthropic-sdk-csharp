using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Parameters for creating a static bearer token credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerCreateParams,
        BetaManagedAgentsStaticBearerCreateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerCreateParams : JsonModel
{
    /// <summary>
    /// Static bearer token value.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// URL of the MCP server this credential authenticates against.
    /// </summary>
    public required string McpServerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_url");
        }
        init { this._rawData.Set("mcp_server_url", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsStaticBearerCreateParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.McpServerUrl;
        this.Type.Validate();
    }

    public BetaManagedAgentsStaticBearerCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerCreateParams(
        BetaManagedAgentsStaticBearerCreateParams betaManagedAgentsStaticBearerCreateParams
    )
        : base(betaManagedAgentsStaticBearerCreateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerCreateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsStaticBearerCreateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerCreateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsStaticBearerCreateParamsTypeConverter))]
public enum BetaManagedAgentsStaticBearerCreateParamsType
{
    StaticBearer,
}

sealed class BetaManagedAgentsStaticBearerCreateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsStaticBearerCreateParamsType>
{
    public override BetaManagedAgentsStaticBearerCreateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "static_bearer" => BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            _ => (BetaManagedAgentsStaticBearerCreateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsStaticBearerCreateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer => "static_bearer",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
