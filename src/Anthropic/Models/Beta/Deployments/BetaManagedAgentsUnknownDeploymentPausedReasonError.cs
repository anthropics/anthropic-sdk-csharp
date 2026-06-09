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
/// An unrecognized error auto-paused the deployment. A fallback variant; matches
/// a run whose `error.type` is `unknown_error`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnknownDeploymentPausedReasonError,
        BetaManagedAgentsUnknownDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnknownDeploymentPausedReasonError : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsUnknownDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownDeploymentPausedReasonError(
        BetaManagedAgentsUnknownDeploymentPausedReasonError betaManagedAgentsUnknownDeploymentPausedReasonError
    )
        : base(betaManagedAgentsUnknownDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnknownDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnknownDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnknownDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnknownDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsUnknownDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsUnknownDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsUnknownDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnknownDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnknownDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUnknownDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsUnknownDeploymentPausedReasonErrorType
{
    UnknownError,
}

sealed class BetaManagedAgentsUnknownDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsUnknownDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsUnknownDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown_error" => BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError,
            _ => (BetaManagedAgentsUnknownDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUnknownDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError =>
                    "unknown_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
