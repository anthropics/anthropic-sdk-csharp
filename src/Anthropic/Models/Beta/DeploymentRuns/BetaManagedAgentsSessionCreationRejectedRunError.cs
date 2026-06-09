using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The session create request was rejected with a non-retryable validation error.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionCreationRejectedRunError,
        BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionCreationRejectedRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionCreationRejectedRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionCreationRejectedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionCreationRejectedRunError(
        BetaManagedAgentsSessionCreationRejectedRunError betaManagedAgentsSessionCreationRejectedRunError
    )
        : base(betaManagedAgentsSessionCreationRejectedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionCreationRejectedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionCreationRejectedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionCreationRejectedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionCreationRejectedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionCreationRejectedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionCreationRejectedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionCreationRejectedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionCreationRejectedRunErrorTypeConverter))]
public enum BetaManagedAgentsSessionCreationRejectedRunErrorType
{
    SessionCreationRejectedError,
}

sealed class BetaManagedAgentsSessionCreationRejectedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionCreationRejectedRunErrorType>
{
    public override BetaManagedAgentsSessionCreationRejectedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_creation_rejected_error" =>
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
            _ => (BetaManagedAgentsSessionCreationRejectedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionCreationRejectedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError =>
                    "session_creation_rejected_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
