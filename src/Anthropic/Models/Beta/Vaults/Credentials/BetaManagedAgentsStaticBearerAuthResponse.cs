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
/// Static bearer token credential details for an MCP server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerAuthResponse,
        BetaManagedAgentsStaticBearerAuthResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerAuthResponse : JsonModel
{
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

    public required ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsStaticBearerAuthResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.McpServerUrl;
        this.Type.Validate();
    }

    public BetaManagedAgentsStaticBearerAuthResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerAuthResponse(
        BetaManagedAgentsStaticBearerAuthResponse betaManagedAgentsStaticBearerAuthResponse
    )
        : base(betaManagedAgentsStaticBearerAuthResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerAuthResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerAuthResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerAuthResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsStaticBearerAuthResponseFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerAuthResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerAuthResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsStaticBearerAuthResponseTypeConverter))]
public enum BetaManagedAgentsStaticBearerAuthResponseType
{
    StaticBearer,
}

sealed class BetaManagedAgentsStaticBearerAuthResponseTypeConverter
    : JsonConverter<BetaManagedAgentsStaticBearerAuthResponseType>
{
    public override BetaManagedAgentsStaticBearerAuthResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "static_bearer" => BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer,
            _ => (BetaManagedAgentsStaticBearerAuthResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsStaticBearerAuthResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsStaticBearerAuthResponseType.StaticBearer => "static_bearer",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
