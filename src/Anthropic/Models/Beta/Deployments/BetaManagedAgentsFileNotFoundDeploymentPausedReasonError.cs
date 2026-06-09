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
    public required ApiEnum<
        string,
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(typeof(BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType
{
    FileNotFoundError,
}

sealed class BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_not_found_error" =>
                BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType.FileNotFoundError,
            _ => (BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType.FileNotFoundError =>
                    "file_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
