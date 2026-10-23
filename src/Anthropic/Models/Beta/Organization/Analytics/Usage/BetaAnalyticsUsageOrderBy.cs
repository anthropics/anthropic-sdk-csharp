using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.Usage;

[JsonConverter(typeof(BetaAnalyticsUsageOrderByConverter))]
public enum BetaAnalyticsUsageOrderBy
{
    OutputTokens,
    Requests,
    Time,
    TotalTokens,
    UncachedInputTokens,
}

sealed class BetaAnalyticsUsageOrderByConverter : JsonConverter<BetaAnalyticsUsageOrderBy>
{
    public override BetaAnalyticsUsageOrderBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "output_tokens" => BetaAnalyticsUsageOrderBy.OutputTokens,
            "requests" => BetaAnalyticsUsageOrderBy.Requests,
            "time" => BetaAnalyticsUsageOrderBy.Time,
            "total_tokens" => BetaAnalyticsUsageOrderBy.TotalTokens,
            "uncached_input_tokens" => BetaAnalyticsUsageOrderBy.UncachedInputTokens,
            _ => (BetaAnalyticsUsageOrderBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageOrderBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageOrderBy.OutputTokens => "output_tokens",
                BetaAnalyticsUsageOrderBy.Requests => "requests",
                BetaAnalyticsUsageOrderBy.Time => "time",
                BetaAnalyticsUsageOrderBy.TotalTokens => "total_tokens",
                BetaAnalyticsUsageOrderBy.UncachedInputTokens => "uncached_input_tokens",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
