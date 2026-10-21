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
/// Parameters for updating an MCP OAuth credential. The `mcp_server_url` is immutable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthUpdateParams,
        BetaManagedAgentsMcpOAuthUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthUpdateParams : JsonModel
{
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
    /// The new OAuth access token to replace the stored one.
    /// </summary>
    public string? AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    /// <summary>
    /// When the credential's access token expires, in RFC 3339. Leave it out to keep
    /// the stored expiry.
    ///
    /// <para>If you send a new `access_token`, send its `expires_at` too, or the
    /// new token keeps the old expiry.</para>
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
    /// Updated refresh token configuration.
    /// </summary>
    public BetaManagedAgentsMcpOAuthRefreshUpdateParams? Refresh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpOAuthRefreshUpdateParams>(
                "refresh"
            );
        }
        init { this._rawData.Set("refresh", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_oauth")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.AccessToken;
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthUpdateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthUpdateParams(
        BetaManagedAgentsMcpOAuthUpdateParams betaManagedAgentsMcpOAuthUpdateParams
    )
        : base(betaManagedAgentsMcpOAuthUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthUpdateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_oauth");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthUpdateParams.FromRawUnchecked(rawData);
}
