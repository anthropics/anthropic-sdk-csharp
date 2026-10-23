using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsSpeedConverter))]
public enum BetaAnalyticsSpeed
{
    Fast,
    Standard,
}

sealed class BetaAnalyticsSpeedConverter : JsonConverter<BetaAnalyticsSpeed>
{
    public override BetaAnalyticsSpeed Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => BetaAnalyticsSpeed.Fast,
            "standard" => BetaAnalyticsSpeed.Standard,
            _ => (BetaAnalyticsSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsSpeed.Fast => "fast",
                BetaAnalyticsSpeed.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
