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
/// Result of live-probing a credential against its configured MCP server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsCredentialValidation,
        BetaManagedAgentsCredentialValidationFromRaw
    >)
)]
public sealed record class BetaManagedAgentsCredentialValidation : JsonModel
{
    /// <summary>
    /// Unique identifier of the credential that was validated.
    /// </summary>
    public required string CredentialID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credential_id");
        }
        init { this._rawData.Set("credential_id", value); }
    }

    /// <summary>
    /// Whether the credential has a refresh token configured.
    /// </summary>
    public required bool HasRefreshToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_refresh_token");
        }
        init { this._rawData.Set("has_refresh_token", value); }
    }

    /// <summary>
    /// Details of the MCP probe step that failed, or `null` if the probe succeeded
    /// or there was no access token to test.
    /// </summary>
    public required BetaManagedAgentsMcpProbe? McpProbe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpProbe>("mcp_probe");
        }
        init { this._rawData.Set("mcp_probe", value); }
    }

    /// <summary>
    /// Details of the refresh-token exchange attempted on a 401. Null when no refresh
    /// was attempted.
    /// </summary>
    public required BetaManagedAgentsRefreshObject? Refresh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsRefreshObject>("refresh");
        }
        init { this._rawData.Set("refresh", value); }
    }

    /// <summary>
    /// Overall verdict of the validation probe.
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsCredentialValidationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsCredentialValidationStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
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
    /// When the validation probe was performed.
    /// </summary>
    public required DateTimeOffset ValidatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("validated_at");
        }
        init { this._rawData.Set("validated_at", value); }
    }

    /// <summary>
    /// Identifier of the vault containing the credential.
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vault_id");
        }
        init { this._rawData.Set("vault_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CredentialID;
        _ = this.HasRefreshToken;
        this.McpProbe?.Validate();
        this.Refresh?.Validate();
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("vault_credential_validation")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValidatedAt;
        _ = this.VaultID;
    }

    public BetaManagedAgentsCredentialValidation()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_credential_validation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCredentialValidation(
        BetaManagedAgentsCredentialValidation betaManagedAgentsCredentialValidation
    )
        : base(betaManagedAgentsCredentialValidation) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCredentialValidation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_credential_validation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCredentialValidation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCredentialValidationFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCredentialValidation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCredentialValidationFromRaw
    : IFromRawJson<BetaManagedAgentsCredentialValidation>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCredentialValidation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCredentialValidation.FromRawUnchecked(rawData);
}
