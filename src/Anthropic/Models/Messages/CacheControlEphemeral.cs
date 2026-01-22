using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CacheControlEphemeral, CacheControlEphemeralFromRaw>))]
public sealed record class CacheControlEphemeral : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The time-to-live for the cache control breakpoint.
    ///
    /// <para>This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour</para>
    ///
    /// <para>Defaults to `5m`.</para>
    /// </summary>
    public ApiEnum<string, Ttl>? Ttl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Ttl>>("ttl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ttl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("ephemeral")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Ttl?.Validate();
    }

    public CacheControlEphemeral()
    {
        this.Type = JsonSerializer.SerializeToElement("ephemeral");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CacheControlEphemeral(CacheControlEphemeral cacheControlEphemeral)
        : base(cacheControlEphemeral) { }
#pragma warning restore CS8618

    public CacheControlEphemeral(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ephemeral");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheControlEphemeral(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheControlEphemeralFromRaw.FromRawUnchecked"/>
    public static CacheControlEphemeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CacheControlEphemeralFromRaw : IFromRawJson<CacheControlEphemeral>
{
    /// <inheritdoc/>
    public CacheControlEphemeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CacheControlEphemeral.FromRawUnchecked(rawData);
}

/// <summary>
/// The time-to-live for the cache control breakpoint.
///
/// <para>This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour</para>
///
/// <para>Defaults to `5m`.</para>
/// </summary>
[JsonConverter(typeof(TtlConverter))]
public enum Ttl
{
    Ttl5m,
    Ttl1h,
}

sealed class TtlConverter : JsonConverter<Ttl>
{
    public override Ttl Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "5m" => Ttl.Ttl5m,
            "1h" => Ttl.Ttl1h,
            _ => (Ttl)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Ttl value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Ttl.Ttl5m => "5m",
                Ttl.Ttl1h => "1h",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
