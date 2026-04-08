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
/// Parameters for creating an MCP OAuth credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthCreateParams,
        BetaManagedAgentsMcpOAuthCreateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthCreateParams : JsonModel
{
    /// <summary>
    /// OAuth access token.
    /// </summary>
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
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

    public required ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType>
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
    /// OAuth refresh token parameters for creating a credential with refresh support.
    /// </summary>
    public BetaManagedAgentsMcpOAuthRefreshParams? Refresh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpOAuthRefreshParams>(
                "refresh"
            );
        }
        init { this._rawData.Set("refresh", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.McpServerUrl;
        this.Type.Validate();
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthCreateParams(
        BetaManagedAgentsMcpOAuthCreateParams betaManagedAgentsMcpOAuthCreateParams
    )
        : base(betaManagedAgentsMcpOAuthCreateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthCreateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthCreateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthCreateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMcpOAuthCreateParamsTypeConverter))]
public enum BetaManagedAgentsMcpOAuthCreateParamsType
{
    McpOAuth,
}

sealed class BetaManagedAgentsMcpOAuthCreateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMcpOAuthCreateParamsType>
{
    public override BetaManagedAgentsMcpOAuthCreateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_oauth" => BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            _ => (BetaManagedAgentsMcpOAuthCreateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpOAuthCreateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth => "mcp_oauth",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
