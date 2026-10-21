using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A vault referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError,
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultArchivedDeploymentPausedReasonError : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("vault_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError betaManagedAgentsVaultArchivedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsVaultArchivedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultArchivedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
