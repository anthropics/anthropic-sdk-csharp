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
    public required ApiEnum<
        string,
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(
    typeof(BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType
{
    EnvironmentArchivedError,
}

sealed class BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_archived_error" =>
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError,
            _ => (BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError =>
                    "environment_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
