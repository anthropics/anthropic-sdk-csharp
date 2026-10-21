using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsCostTypeConverter))]
public enum BetaAnalyticsCostType
{
    CodeExecution,
    Tokens,
    WebSearch,
}

sealed class BetaAnalyticsCostTypeConverter : JsonConverter<BetaAnalyticsCostType>
{
    public override BetaAnalyticsCostType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "code_execution" => BetaAnalyticsCostType.CodeExecution,
            "tokens" => BetaAnalyticsCostType.Tokens,
            "web_search" => BetaAnalyticsCostType.WebSearch,
            _ => (BetaAnalyticsCostType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsCostType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsCostType.CodeExecution => "code_execution",
                BetaAnalyticsCostType.Tokens => "tokens",
                BetaAnalyticsCostType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
