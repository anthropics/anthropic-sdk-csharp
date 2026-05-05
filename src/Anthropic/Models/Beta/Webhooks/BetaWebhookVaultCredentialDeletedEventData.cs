using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebhookVaultCredentialDeletedEventData,
        BetaWebhookVaultCredentialDeletedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookVaultCredentialDeletedEventData : JsonModel
{
    /// <summary>
    /// ID of the resource that triggered the event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
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
    /// ID of the vault that owns this credential.
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

    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.OrganizationID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("vault_credential.deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.VaultID;
        _ = this.WorkspaceID;
    }

    public BetaWebhookVaultCredentialDeletedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_credential.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookVaultCredentialDeletedEventData(
        BetaWebhookVaultCredentialDeletedEventData betaWebhookVaultCredentialDeletedEventData
    )
        : base(betaWebhookVaultCredentialDeletedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookVaultCredentialDeletedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_credential.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookVaultCredentialDeletedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookVaultCredentialDeletedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookVaultCredentialDeletedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookVaultCredentialDeletedEventDataFromRaw
    : IFromRawJson<BetaWebhookVaultCredentialDeletedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookVaultCredentialDeletedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookVaultCredentialDeletedEventData.FromRawUnchecked(rawData);
}
