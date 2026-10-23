using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsUsageCostInferenceGeoConverter))]
public enum BetaAnalyticsUsageCostInferenceGeo
{
    Global,
    Us,
}

sealed class BetaAnalyticsUsageCostInferenceGeoConverter
    : JsonConverter<BetaAnalyticsUsageCostInferenceGeo>
{
    public override BetaAnalyticsUsageCostInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAnalyticsUsageCostInferenceGeo.Global,
            "us" => BetaAnalyticsUsageCostInferenceGeo.Us,
            _ => (BetaAnalyticsUsageCostInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageCostInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageCostInferenceGeo.Global => "global",
                BetaAnalyticsUsageCostInferenceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
