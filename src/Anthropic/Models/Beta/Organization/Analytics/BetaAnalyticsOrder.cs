using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Sort direction: `asc` or `desc`. Defaults to `asc` for the endpoint's sort column
/// and to `desc` when `order_by` names a metric (a top-N ranking). Applies to `order_by`,
/// or to the endpoint's default sort field when `order_by` is omitted.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsOrderConverter))]
public enum BetaAnalyticsOrder
{
    Asc,
    Desc,
}

sealed class BetaAnalyticsOrderConverter : JsonConverter<BetaAnalyticsOrder>
{
    public override BetaAnalyticsOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => BetaAnalyticsOrder.Asc,
            "desc" => BetaAnalyticsOrder.Desc,
            _ => (BetaAnalyticsOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsOrder.Asc => "asc",
                BetaAnalyticsOrder.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
