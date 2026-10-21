using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsContextWindowConverter))]
public enum BetaAnalyticsContextWindow
{
    From0To200k,
    From200kTo1M,
}

sealed class BetaAnalyticsContextWindowConverter : JsonConverter<BetaAnalyticsContextWindow>
{
    public override BetaAnalyticsContextWindow Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "0-200k" => BetaAnalyticsContextWindow.From0To200k,
            "200k-1M" => BetaAnalyticsContextWindow.From200kTo1M,
            _ => (BetaAnalyticsContextWindow)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsContextWindow value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsContextWindow.From0To200k => "0-200k",
                BetaAnalyticsContextWindow.From200kTo1M => "200k-1M",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
