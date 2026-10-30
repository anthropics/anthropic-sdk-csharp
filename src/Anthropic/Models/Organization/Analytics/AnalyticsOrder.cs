using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Sort direction: `asc` or `desc`. Defaults to `asc` for the endpoint's sort column
/// and to `desc` when `order_by` names a metric (a top-N ranking). Applies to `order_by`,
/// or to the endpoint's default sort field when `order_by` is omitted.
/// </summary>
[JsonConverter(typeof(AnalyticsOrderConverter))]
public enum AnalyticsOrder
{
    Asc,
    Desc,
}

sealed class AnalyticsOrderConverter : JsonConverter<AnalyticsOrder>
{
    public override AnalyticsOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => AnalyticsOrder.Asc,
            "desc" => AnalyticsOrder.Desc,
            _ => (AnalyticsOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsOrder.Asc => "asc",
                AnalyticsOrder.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
