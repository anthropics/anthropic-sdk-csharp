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
/// A memory store referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryStoreArchivedRunError,
        BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryStoreArchivedRunError : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryStoreArchivedRunErrorType>
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

    public BetaManagedAgentsMemoryStoreArchivedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreArchivedRunError(
        BetaManagedAgentsMemoryStoreArchivedRunError betaManagedAgentsMemoryStoreArchivedRunError
    )
        : base(betaManagedAgentsMemoryStoreArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStoreArchivedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStoreArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStoreArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryStoreArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryStoreArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStoreArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStoreArchivedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryStoreArchivedRunErrorTypeConverter))]
public enum BetaManagedAgentsMemoryStoreArchivedRunErrorType
{
    MemoryStoreArchivedError,
}

sealed class BetaManagedAgentsMemoryStoreArchivedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryStoreArchivedRunErrorType>
{
    public override BetaManagedAgentsMemoryStoreArchivedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store_archived_error" =>
                BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
            _ => (BetaManagedAgentsMemoryStoreArchivedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryStoreArchivedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError =>
                    "memory_store_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
