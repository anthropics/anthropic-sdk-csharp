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
/// OAuth credential details for an MCP server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthAuthResponse,
        BetaManagedAgentsMcpOAuthAuthResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthAuthResponse : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// OAuth refresh token configuration returned in credential responses.
    /// </summary>
    public BetaManagedAgentsMcpOAuthRefreshResponse? Refresh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpOAuthRefreshResponse>(
                "refresh"
            );
        }
        init { this._rawData.Set("refresh", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.McpServerUrl;
        this.Type.Validate();
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthAuthResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthAuthResponse(
        BetaManagedAgentsMcpOAuthAuthResponse betaManagedAgentsMcpOAuthAuthResponse
    )
        : base(betaManagedAgentsMcpOAuthAuthResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthAuthResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthAuthResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthAuthResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthAuthResponseFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthAuthResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthAuthResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMcpOAuthAuthResponseTypeConverter))]
public enum BetaManagedAgentsMcpOAuthAuthResponseType
{
    McpOAuth,
}

sealed class BetaManagedAgentsMcpOAuthAuthResponseTypeConverter
    : JsonConverter<BetaManagedAgentsMcpOAuthAuthResponseType>
{
    public override BetaManagedAgentsMcpOAuthAuthResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_oauth" => BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            _ => (BetaManagedAgentsMcpOAuthAuthResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpOAuthAuthResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth => "mcp_oauth",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
