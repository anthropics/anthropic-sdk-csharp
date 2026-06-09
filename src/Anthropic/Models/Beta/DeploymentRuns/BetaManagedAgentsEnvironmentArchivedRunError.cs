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
/// The deployment's environment was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentArchivedRunError,
        BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentArchivedRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentArchivedRunErrorType>
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

    public BetaManagedAgentsEnvironmentArchivedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentArchivedRunError(
        BetaManagedAgentsEnvironmentArchivedRunError betaManagedAgentsEnvironmentArchivedRunError
    )
        : base(betaManagedAgentsEnvironmentArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentArchivedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEnvironmentArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentArchivedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEnvironmentArchivedRunErrorTypeConverter))]
public enum BetaManagedAgentsEnvironmentArchivedRunErrorType
{
    EnvironmentArchivedError,
}

sealed class BetaManagedAgentsEnvironmentArchivedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentArchivedRunErrorType>
{
    public override BetaManagedAgentsEnvironmentArchivedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_archived_error" =>
                BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            _ => (BetaManagedAgentsEnvironmentArchivedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentArchivedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError =>
                    "environment_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
