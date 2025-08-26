using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages.CacheControlEphemeralProperties;

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
        Type typeToConvert,
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
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
