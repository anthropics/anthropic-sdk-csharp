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
/// A referenced resource no longer exists and its kind was not reported.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionResourceNotFoundRunError,
        BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionResourceNotFoundRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionResourceNotFoundRunErrorType>
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

    public BetaManagedAgentsSessionResourceNotFoundRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionResourceNotFoundRunError(
        BetaManagedAgentsSessionResourceNotFoundRunError betaManagedAgentsSessionResourceNotFoundRunError
    )
        : base(betaManagedAgentsSessionResourceNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionResourceNotFoundRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionResourceNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionResourceNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionResourceNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionResourceNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionResourceNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionResourceNotFoundRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionResourceNotFoundRunErrorTypeConverter))]
public enum BetaManagedAgentsSessionResourceNotFoundRunErrorType
{
    SessionResourceNotFoundError,
}

sealed class BetaManagedAgentsSessionResourceNotFoundRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionResourceNotFoundRunErrorType>
{
    public override BetaManagedAgentsSessionResourceNotFoundRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_resource_not_found_error" =>
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
            _ => (BetaManagedAgentsSessionResourceNotFoundRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionResourceNotFoundRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError =>
                    "session_resource_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
