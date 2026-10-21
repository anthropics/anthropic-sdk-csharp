using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// The caller invoked the pause endpoint on the deployment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsManualDeploymentPausedReason,
        BetaManagedAgentsManualDeploymentPausedReasonFromRaw
    >)
)]
public sealed record class BetaManagedAgentsManualDeploymentPausedReason : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("manual")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsManualDeploymentPausedReason()
    {
        this.Type = JsonSerializer.SerializeToElement("manual");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsManualDeploymentPausedReason(
        BetaManagedAgentsManualDeploymentPausedReason betaManagedAgentsManualDeploymentPausedReason
    )
        : base(betaManagedAgentsManualDeploymentPausedReason) { }
#pragma warning restore CS8618

    public BetaManagedAgentsManualDeploymentPausedReason(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("manual");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsManualDeploymentPausedReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsManualDeploymentPausedReasonFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsManualDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsManualDeploymentPausedReasonFromRaw
    : IFromRawJson<BetaManagedAgentsManualDeploymentPausedReason>
{
    /// <inheritdoc/>
    public BetaManagedAgentsManualDeploymentPausedReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsManualDeploymentPausedReason.FromRawUnchecked(rawData);
}
