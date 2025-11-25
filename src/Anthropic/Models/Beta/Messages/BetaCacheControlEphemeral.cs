using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCacheControlEphemeral>))]
public sealed record class BetaCacheControlEphemeral
    : ModelBase,
        IFromRaw<BetaCacheControlEphemeral>
{
    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time-to-live for the cache control breakpoint.
    ///
    /// <para>This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour</para>
    ///
    /// <para>Defaults to `5m`.</para>
    /// </summary>
    public ApiEnum<string, TTL>? TTL
    {
        get
        {
            if (!this._rawData.TryGetValue("ttl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TTL>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["ttl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.TTL?.Validate();
    }

    public BetaCacheControlEphemeral()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

    public BetaCacheControlEphemeral(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheControlEphemeral(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaCacheControlEphemeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// The time-to-live for the cache control breakpoint.
///
/// <para>This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour</para>
///
/// <para>Defaults to `5m`.</para>
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
