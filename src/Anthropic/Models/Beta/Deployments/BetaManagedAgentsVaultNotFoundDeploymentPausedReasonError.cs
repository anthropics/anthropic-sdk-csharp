using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A vault referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError,
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError : JsonModel
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
                JsonSerializer.SerializeToElement("vault_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError betaManagedAgentsVaultNotFoundDeploymentPausedReasonError
    )
        : base(betaManagedAgentsVaultNotFoundDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("vault_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
