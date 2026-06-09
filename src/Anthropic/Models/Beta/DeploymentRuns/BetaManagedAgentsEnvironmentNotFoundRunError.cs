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
/// The deployment's environment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentNotFoundRunError,
        BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentNotFoundRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentNotFoundRunErrorType>
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

    public BetaManagedAgentsEnvironmentNotFoundRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentNotFoundRunError(
        BetaManagedAgentsEnvironmentNotFoundRunError betaManagedAgentsEnvironmentNotFoundRunError
    )
        : base(betaManagedAgentsEnvironmentNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentNotFoundRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEnvironmentNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentNotFoundRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEnvironmentNotFoundRunErrorTypeConverter))]
public enum BetaManagedAgentsEnvironmentNotFoundRunErrorType
{
    EnvironmentNotFoundError,
}

sealed class BetaManagedAgentsEnvironmentNotFoundRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentNotFoundRunErrorType>
{
    public override BetaManagedAgentsEnvironmentNotFoundRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_not_found_error" =>
                BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
            _ => (BetaManagedAgentsEnvironmentNotFoundRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentNotFoundRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError =>
                    "environment_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
