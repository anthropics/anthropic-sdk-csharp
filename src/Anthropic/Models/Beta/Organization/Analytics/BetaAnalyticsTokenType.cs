using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsTokenTypeConverter))]
public enum BetaAnalyticsTokenType
{
    CacheCreationEphemeral1hInputTokens,
    CacheCreationEphemeral5mInputTokens,
    CacheReadInputTokens,
    OutputTokens,
    UncachedInputTokens,
}

sealed class BetaAnalyticsTokenTypeConverter : JsonConverter<BetaAnalyticsTokenType>
{
    public override BetaAnalyticsTokenType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cache_creation.ephemeral_1h_input_tokens" =>
                BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
            "cache_creation.ephemeral_5m_input_tokens" =>
                BetaAnalyticsTokenType.CacheCreationEphemeral5mInputTokens,
            "cache_read_input_tokens" => BetaAnalyticsTokenType.CacheReadInputTokens,
            "output_tokens" => BetaAnalyticsTokenType.OutputTokens,
            "uncached_input_tokens" => BetaAnalyticsTokenType.UncachedInputTokens,
            _ => (BetaAnalyticsTokenType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsTokenType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens =>
                    "cache_creation.ephemeral_1h_input_tokens",
                BetaAnalyticsTokenType.CacheCreationEphemeral5mInputTokens =>
                    "cache_creation.ephemeral_5m_input_tokens",
                BetaAnalyticsTokenType.CacheReadInputTokens => "cache_read_input_tokens",
                BetaAnalyticsTokenType.OutputTokens => "output_tokens",
                BetaAnalyticsTokenType.UncachedInputTokens => "uncached_input_tokens",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
