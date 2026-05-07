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
        BetaWebhookVaultCredentialArchivedEventData,
        BetaWebhookVaultCredentialArchivedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookVaultCredentialArchivedEventData : JsonModel
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
                JsonSerializer.SerializeToElement("vault_credential.archived")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.VaultID;
        _ = this.WorkspaceID;
    }

    public BetaWebhookVaultCredentialArchivedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_credential.archived");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookVaultCredentialArchivedEventData(
        BetaWebhookVaultCredentialArchivedEventData betaWebhookVaultCredentialArchivedEventData
    )
        : base(betaWebhookVaultCredentialArchivedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookVaultCredentialArchivedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_credential.archived");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookVaultCredentialArchivedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookVaultCredentialArchivedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookVaultCredentialArchivedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookVaultCredentialArchivedEventDataFromRaw
    : IFromRawJson<BetaWebhookVaultCredentialArchivedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookVaultCredentialArchivedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookVaultCredentialArchivedEventData.FromRawUnchecked(rawData);
}
