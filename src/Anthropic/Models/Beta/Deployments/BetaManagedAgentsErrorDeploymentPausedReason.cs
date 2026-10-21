using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A scheduled fire recorded a failed run whose error auto-pauses the deployment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsErrorDeploymentPausedReason,
        BetaManagedAgentsErrorDeploymentPausedReasonFromRaw
    >)
)]
public sealed record class BetaManagedAgentsErrorDeploymentPausedReason : JsonModel
{
    /// <summary>
    /// The failed run's error.
    /// </summary>
    public required BetaManagedAgentsDeploymentPausedReasonError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsDeploymentPausedReasonError>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsErrorDeploymentPausedReason()
    {
        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsErrorDeploymentPausedReason(
        BetaManagedAgentsErrorDeploymentPausedReason betaManagedAgentsErrorDeploymentPausedReason
    )
        : base(betaManagedAgentsErrorDeploymentPausedReason) { }
#pragma warning restore CS8618

    public BetaManagedAgentsErrorDeploymentPausedReason(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsErrorDeploymentPausedReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsErrorDeploymentPausedReasonFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsErrorDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsErrorDeploymentPausedReason(
        BetaManagedAgentsDeploymentPausedReasonError error
    )
        : this()
    {
        this.Error = error;
    }
}

class BetaManagedAgentsErrorDeploymentPausedReasonFromRaw
    : IFromRawJson<BetaManagedAgentsErrorDeploymentPausedReason>
{
    /// <inheritdoc/>
    public BetaManagedAgentsErrorDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsErrorDeploymentPausedReason.FromRawUnchecked(rawData);
}
