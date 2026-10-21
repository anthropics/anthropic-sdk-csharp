using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// The OAuth access token to send to the MCP server.
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
    /// When `access_token` expires, in RFC 3339.
    ///
    /// <para>Must be in the future.</para>
    /// </summary>
    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Refresh token configuration, if the credential supports token refresh.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_oauth")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthCreateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
    }

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

        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
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
