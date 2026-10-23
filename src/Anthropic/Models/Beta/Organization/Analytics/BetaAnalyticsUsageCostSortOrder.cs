using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsUsageCostSortOrderConverter))]
public enum BetaAnalyticsUsageCostSortOrder
{
    Asc,
    Desc,
}

sealed class BetaAnalyticsUsageCostSortOrderConverter
    : JsonConverter<BetaAnalyticsUsageCostSortOrder>
{
    public override BetaAnalyticsUsageCostSortOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => BetaAnalyticsUsageCostSortOrder.Asc,
            "desc" => BetaAnalyticsUsageCostSortOrder.Desc,
            _ => (BetaAnalyticsUsageCostSortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageCostSortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageCostSortOrder.Asc => "asc",
                BetaAnalyticsUsageCostSortOrder.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
