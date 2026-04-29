using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Optimistic-concurrency precondition: the update applies only if the memory's stored
/// `content_sha256` equals the supplied value. On mismatch, the request returns
/// `memory_precondition_failed_error` (HTTP 409); re-read the memory and retry against
/// the fresh state. If the precondition fails but the stored state already exactly
/// matches the requested `content` and `path`, the server returns 200 instead of 409.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsContentSha256Precondition,
        BetaManagedAgentsContentSha256PreconditionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsContentSha256Precondition : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsContentSha256PreconditionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsContentSha256PreconditionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Expected `content_sha256` of the stored memory (64 lowercase hexadecimal characters).
    /// Typically the `content_sha256` returned by a prior read or list call. Because
    /// the server applies no content normalization, clients can also compute this
    /// locally as the SHA-256 of the UTF-8 content bytes.
    /// </summary>
    public string? ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_sha256");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content_sha256", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ContentSha256;
    }

    public BetaManagedAgentsContentSha256Precondition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsContentSha256Precondition(
        BetaManagedAgentsContentSha256Precondition betaManagedAgentsContentSha256Precondition
    )
        : base(betaManagedAgentsContentSha256Precondition) { }
#pragma warning restore CS8618

    public BetaManagedAgentsContentSha256Precondition(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsContentSha256Precondition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsContentSha256PreconditionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsContentSha256Precondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsContentSha256Precondition(
        ApiEnum<string, BetaManagedAgentsContentSha256PreconditionType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsContentSha256PreconditionFromRaw
    : IFromRawJson<BetaManagedAgentsContentSha256Precondition>
{
    /// <inheritdoc/>
    public BetaManagedAgentsContentSha256Precondition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsContentSha256Precondition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsContentSha256PreconditionTypeConverter))]
public enum BetaManagedAgentsContentSha256PreconditionType
{
    ContentSha256,
}

sealed class BetaManagedAgentsContentSha256PreconditionTypeConverter
    : JsonConverter<BetaManagedAgentsContentSha256PreconditionType>
{
    public override BetaManagedAgentsContentSha256PreconditionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "content_sha256" => BetaManagedAgentsContentSha256PreconditionType.ContentSha256,
            _ => (BetaManagedAgentsContentSha256PreconditionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsContentSha256PreconditionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsContentSha256PreconditionType.ContentSha256 => "content_sha256",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
