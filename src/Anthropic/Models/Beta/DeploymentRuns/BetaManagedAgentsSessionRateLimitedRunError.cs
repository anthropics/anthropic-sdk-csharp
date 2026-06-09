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
/// Session creation was rejected due to rate limiting. The schedule keeps firing;
/// subsequent runs may succeed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRateLimitedRunError,
        BetaManagedAgentsSessionRateLimitedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRateLimitedRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionRateLimitedRunErrorType>
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

    public BetaManagedAgentsSessionRateLimitedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRateLimitedRunError(
        BetaManagedAgentsSessionRateLimitedRunError betaManagedAgentsSessionRateLimitedRunError
    )
        : base(betaManagedAgentsSessionRateLimitedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRateLimitedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRateLimitedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRateLimitedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRateLimitedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionRateLimitedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRateLimitedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRateLimitedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRateLimitedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionRateLimitedRunErrorTypeConverter))]
public enum BetaManagedAgentsSessionRateLimitedRunErrorType
{
    SessionRateLimitedError,
}

sealed class BetaManagedAgentsSessionRateLimitedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionRateLimitedRunErrorType>
{
    public override BetaManagedAgentsSessionRateLimitedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session_rate_limited_error" =>
                BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
            _ => (BetaManagedAgentsSessionRateLimitedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionRateLimitedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError =>
                    "session_rate_limited_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
