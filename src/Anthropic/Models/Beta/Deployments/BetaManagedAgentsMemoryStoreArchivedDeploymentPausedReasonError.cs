using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A memory store referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError,
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
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
                JsonSerializer.SerializeToElement("memory_store_archived_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError betaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store_archived_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
