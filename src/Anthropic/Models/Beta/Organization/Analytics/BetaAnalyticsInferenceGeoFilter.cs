using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsInferenceGeoFilterConverter))]
public enum BetaAnalyticsInferenceGeoFilter
{
    Global,
    NotAvailable,
    Us,
}

sealed class BetaAnalyticsInferenceGeoFilterConverter
    : JsonConverter<BetaAnalyticsInferenceGeoFilter>
{
    public override BetaAnalyticsInferenceGeoFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAnalyticsInferenceGeoFilter.Global,
            "not_available" => BetaAnalyticsInferenceGeoFilter.NotAvailable,
            "us" => BetaAnalyticsInferenceGeoFilter.Us,
            _ => (BetaAnalyticsInferenceGeoFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsInferenceGeoFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsInferenceGeoFilter.Global => "global",
                BetaAnalyticsInferenceGeoFilter.NotAvailable => "not_available",
                BetaAnalyticsInferenceGeoFilter.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
