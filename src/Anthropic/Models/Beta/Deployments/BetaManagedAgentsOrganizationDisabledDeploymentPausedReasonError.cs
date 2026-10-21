using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The deployment's organization is disabled.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError,
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError
    : JsonModel
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
                JsonSerializer.SerializeToElement("organization_disabled_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("organization_disabled_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError betaManagedAgentsOrganizationDisabledDeploymentPausedReasonError
    )
        : base(betaManagedAgentsOrganizationDisabledDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization_disabled_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
