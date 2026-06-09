using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    public required ApiEnum<
        string,
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(
    typeof(BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType
{
    MemoryStoreArchivedError,
}

sealed class BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store_archived_error" =>
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
            _ => (BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError =>
                    "memory_store_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
