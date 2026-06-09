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
/// An unknown or unexpected error caused the run to fail. A fallback variant; clients
/// that do not recognize a new error type can match on message alone.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnknownRunError,
        BetaManagedAgentsUnknownRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnknownRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsUnknownRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUnknownRunErrorType>
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

    public BetaManagedAgentsUnknownRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnknownRunError(
        BetaManagedAgentsUnknownRunError betaManagedAgentsUnknownRunError
    )
        : base(betaManagedAgentsUnknownRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnknownRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnknownRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnknownRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnknownRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUnknownRunErrorFromRaw : IFromRawJson<BetaManagedAgentsUnknownRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnknownRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnknownRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUnknownRunErrorTypeConverter))]
public enum BetaManagedAgentsUnknownRunErrorType
{
    UnknownError,
}

sealed class BetaManagedAgentsUnknownRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsUnknownRunErrorType>
{
    public override BetaManagedAgentsUnknownRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unknown_error" => BetaManagedAgentsUnknownRunErrorType.UnknownError,
            _ => (BetaManagedAgentsUnknownRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUnknownRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUnknownRunErrorType.UnknownError => "unknown_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
