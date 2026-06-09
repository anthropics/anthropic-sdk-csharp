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
/// A file resource referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileNotFoundRunError,
        BetaManagedAgentsFileNotFoundRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileNotFoundRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileNotFoundRunErrorType>
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

    public BetaManagedAgentsFileNotFoundRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileNotFoundRunError(
        BetaManagedAgentsFileNotFoundRunError betaManagedAgentsFileNotFoundRunError
    )
        : base(betaManagedAgentsFileNotFoundRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileNotFoundRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileNotFoundRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileNotFoundRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileNotFoundRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsFileNotFoundRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileNotFoundRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileNotFoundRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileNotFoundRunErrorTypeConverter))]
public enum BetaManagedAgentsFileNotFoundRunErrorType
{
    FileNotFoundError,
}

sealed class BetaManagedAgentsFileNotFoundRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsFileNotFoundRunErrorType>
{
    public override BetaManagedAgentsFileNotFoundRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_not_found_error" => BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
            _ => (BetaManagedAgentsFileNotFoundRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileNotFoundRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError =>
                    "file_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
