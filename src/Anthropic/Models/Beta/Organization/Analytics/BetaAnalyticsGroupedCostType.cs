using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsGroupedCostTypeConverter))]
public enum BetaAnalyticsGroupedCostType
{
    CodeExecution,
    SessionUsage,
    Tokens,
    WebSearch,
}

sealed class BetaAnalyticsGroupedCostTypeConverter : JsonConverter<BetaAnalyticsGroupedCostType>
{
    public override BetaAnalyticsGroupedCostType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "code_execution" => BetaAnalyticsGroupedCostType.CodeExecution,
            "session_usage" => BetaAnalyticsGroupedCostType.SessionUsage,
            "tokens" => BetaAnalyticsGroupedCostType.Tokens,
            "web_search" => BetaAnalyticsGroupedCostType.WebSearch,
            _ => (BetaAnalyticsGroupedCostType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsGroupedCostType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsGroupedCostType.CodeExecution => "code_execution",
                BetaAnalyticsGroupedCostType.SessionUsage => "session_usage",
                BetaAnalyticsGroupedCostType.Tokens => "tokens",
                BetaAnalyticsGroupedCostType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
