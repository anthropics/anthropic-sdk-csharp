using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A referenced resource no longer exists and its kind was not reported.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError,
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
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
                JsonSerializer.SerializeToElement("session_resource_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("session_resource_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError betaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError
    )
        : base(betaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session_resource_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError.FromRawUnchecked(
            rawData
        );
}
