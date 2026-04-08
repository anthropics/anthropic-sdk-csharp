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
    public required ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updated OAuth access token.
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
    /// Parameters for updating OAuth refresh token configuration.
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
        this.Type.Validate();
        _ = this.AccessToken;
        _ = this.ExpiresAt;
        this.Refresh?.Validate();
    }

    public BetaManagedAgentsMcpOAuthUpdateParams() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthUpdateParams(
        ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(typeof(BetaManagedAgentsMcpOAuthUpdateParamsTypeConverter))]
public enum BetaManagedAgentsMcpOAuthUpdateParamsType
{
    McpOAuth,
}

sealed class BetaManagedAgentsMcpOAuthUpdateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMcpOAuthUpdateParamsType>
{
    public override BetaManagedAgentsMcpOAuthUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_oauth" => BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            _ => (BetaManagedAgentsMcpOAuthUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpOAuthUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth => "mcp_oauth",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
