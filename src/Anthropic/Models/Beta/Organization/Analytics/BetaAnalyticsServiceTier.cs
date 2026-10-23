using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsServiceTierConverter))]
public enum BetaAnalyticsServiceTier
{
    Batch,
    Flex,
    FlexDiscount,
    Priority,
    PriorityOnDemand,
    Standard,
}

sealed class BetaAnalyticsServiceTierConverter : JsonConverter<BetaAnalyticsServiceTier>
{
    public override BetaAnalyticsServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => BetaAnalyticsServiceTier.Batch,
            "flex" => BetaAnalyticsServiceTier.Flex,
            "flex_discount" => BetaAnalyticsServiceTier.FlexDiscount,
            "priority" => BetaAnalyticsServiceTier.Priority,
            "priority_on_demand" => BetaAnalyticsServiceTier.PriorityOnDemand,
            "standard" => BetaAnalyticsServiceTier.Standard,
            _ => (BetaAnalyticsServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsServiceTier.Batch => "batch",
                BetaAnalyticsServiceTier.Flex => "flex",
                BetaAnalyticsServiceTier.FlexDiscount => "flex_discount",
                BetaAnalyticsServiceTier.Priority => "priority",
                BetaAnalyticsServiceTier.PriorityOnDemand => "priority_on_demand",
                BetaAnalyticsServiceTier.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
