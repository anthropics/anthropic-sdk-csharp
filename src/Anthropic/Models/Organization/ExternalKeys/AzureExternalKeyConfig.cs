using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

[JsonConverter(typeof(JsonModelConverter<AzureExternalKeyConfig, AzureExternalKeyConfigFromRaw>))]
public sealed record class AzureExternalKeyConfig : JsonModel
{
    /// <summary>
    /// Name of the key within the vault.
    /// </summary>
    public required string KeyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key_name");
        }
        init { this._rawData.Set("key_name", value); }
    }

    /// <summary>
    /// Azure AD tenant ID.
    /// </summary>
    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
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
    /// Key Vault data-plane URI — `https://{vault-name}.vault.azure.net` or `https://{hsm-name}.managedhsm.azure.net`.
    /// </summary>
    public required string VaultUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vault_uri");
        }
        init { this._rawData.Set("vault_uri", value); }
    }

    /// <summary>
    /// Azure AD application (client) ID. Omit to use Anthropic's multitenant app.
    /// Provide only if using a single-tenant app registration in the customer's directory.
    /// </summary>
    public string? ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.KeyName;
        _ = this.TenantID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("azure")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.VaultUri;
        _ = this.ClientID;
    }

    public AzureExternalKeyConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureExternalKeyConfig(AzureExternalKeyConfig azureExternalKeyConfig)
        : base(azureExternalKeyConfig) { }
#pragma warning restore CS8618

    public AzureExternalKeyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureExternalKeyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureExternalKeyConfigFromRaw.FromRawUnchecked"/>
    public static AzureExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureExternalKeyConfigFromRaw : IFromRawJson<AzureExternalKeyConfig>
{
    /// <inheritdoc/>
    public AzureExternalKeyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AzureExternalKeyConfig.FromRawUnchecked(rawData);
}
