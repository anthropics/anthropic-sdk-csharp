using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCacheControlEphemeral>))]
public sealed record class BetaCacheControlEphemeral
    : ModelBase,
        IFromRaw<BetaCacheControlEphemeral>
{
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time-to-live for the cache control breakpoint.
    ///
    /// This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour
    ///
    /// Defaults to `5m`.
    /// </summary>
    public ApiEnum<string, TTL>? TTL
    {
        get
        {
            if (!this._properties.TryGetValue("ttl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TTL>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["ttl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Type;
        this.TTL?.Validate();
    }

    public BetaCacheControlEphemeral()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

    public BetaCacheControlEphemeral(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheControlEphemeral(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaCacheControlEphemeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The time-to-live for the cache control breakpoint.
///
/// This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour
///
/// Defaults to `5m`.
/// </summary>
[JsonConverter(typeof(TTLConverter))]
public enum TTL
{
    TTL5m,
    TTL1h,
}

sealed class TTLConverter : JsonConverter<TTL>
{
    public override TTL Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "5m" => TTL.TTL5m,
            "1h" => TTL.TTL1h,
            _ => (TTL)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, TTL value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TTL.TTL5m => "5m",
                TTL.TTL1h => "1h",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
