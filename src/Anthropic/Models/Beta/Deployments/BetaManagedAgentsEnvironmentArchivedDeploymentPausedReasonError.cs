using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The deployment's environment was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError,
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError
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
                JsonSerializer.SerializeToElement("environment_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError betaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("environment_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
