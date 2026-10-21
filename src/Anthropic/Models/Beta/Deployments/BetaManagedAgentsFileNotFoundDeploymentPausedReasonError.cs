using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A file resource referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonError,
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileNotFoundDeploymentPausedReasonError : JsonModel
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
                JsonSerializer.SerializeToElement("file_not_found_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("file_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonError betaManagedAgentsFileNotFoundDeploymentPausedReasonError
    )
        : base(betaManagedAgentsFileNotFoundDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsFileNotFoundDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileNotFoundDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
