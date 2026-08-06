using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(BetaCurrencyConverter))]
public enum BetaCurrency
{
    Usd,
}

sealed class BetaCurrencyConverter : JsonConverter<BetaCurrency>
{
    public override BetaCurrency Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "USD" => BetaCurrency.Usd,
            _ => (BetaCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaCurrency.Usd => "USD",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
