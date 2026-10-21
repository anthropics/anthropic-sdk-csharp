using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The deployment configures resources, but its environment is self-hosted and cannot
/// mount them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError,
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError
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
                JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError betaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("self_hosted_resources_unsupported_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError.FromRawUnchecked(
            rawData
        );
}
