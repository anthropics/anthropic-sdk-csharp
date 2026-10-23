using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

[JsonConverter(typeof(BetaAnalyticsCostOrderByConverter))]
public enum BetaAnalyticsCostOrderBy
{
    Amount,
    ListAmount,
    Time,
}

sealed class BetaAnalyticsCostOrderByConverter : JsonConverter<BetaAnalyticsCostOrderBy>
{
    public override BetaAnalyticsCostOrderBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount" => BetaAnalyticsCostOrderBy.Amount,
            "list_amount" => BetaAnalyticsCostOrderBy.ListAmount,
            "time" => BetaAnalyticsCostOrderBy.Time,
            _ => (BetaAnalyticsCostOrderBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsCostOrderBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsCostOrderBy.Amount => "amount",
                BetaAnalyticsCostOrderBy.ListAmount => "list_amount",
                BetaAnalyticsCostOrderBy.Time => "time",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
