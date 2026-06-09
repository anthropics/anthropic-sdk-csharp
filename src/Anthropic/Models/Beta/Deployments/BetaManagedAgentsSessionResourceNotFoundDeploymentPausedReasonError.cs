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
    public required ApiEnum<
        string,
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
        ApiEnum<
            string,
            BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
        > type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(
    typeof(BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorTypeConverter)
)]
public enum BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType
{
    SessionResourceNotFoundError,
}

sealed class BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_resource_not_found_error" =>
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
            _ => (BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError =>
                    "session_resource_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
