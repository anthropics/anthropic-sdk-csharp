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
/// The deployment's environment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError,
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
    : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError betaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError
    )
        : base(betaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType
{
    EnvironmentNotFoundError,
}

sealed class BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_not_found_error" =>
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
            _ => (BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError =>
                    "environment_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
