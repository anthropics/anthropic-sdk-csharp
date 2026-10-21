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
    /// When the credential's access token expires, in RFC 3339. Absent if the expiry
    /// isn't known.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_oauth")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthAuthResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
    }

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

        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthAuthResponse(string mcpServerUrl)
        : this()
    {
        this.McpServerUrl = mcpServerUrl;
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
