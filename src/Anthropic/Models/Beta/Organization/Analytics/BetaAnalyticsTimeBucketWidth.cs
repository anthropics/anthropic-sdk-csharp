using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsTimeBucketWidthConverter))]
public enum BetaAnalyticsTimeBucketWidth
{
    Day,
    Hour,
    Minute,
}

sealed class BetaAnalyticsTimeBucketWidthConverter : JsonConverter<BetaAnalyticsTimeBucketWidth>
{
    public override BetaAnalyticsTimeBucketWidth Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1d" => BetaAnalyticsTimeBucketWidth.Day,
            "1h" => BetaAnalyticsTimeBucketWidth.Hour,
            "1m" => BetaAnalyticsTimeBucketWidth.Minute,
            _ => (BetaAnalyticsTimeBucketWidth)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsTimeBucketWidth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsTimeBucketWidth.Day => "1d",
                BetaAnalyticsTimeBucketWidth.Hour => "1h",
                BetaAnalyticsTimeBucketWidth.Minute => "1m",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
