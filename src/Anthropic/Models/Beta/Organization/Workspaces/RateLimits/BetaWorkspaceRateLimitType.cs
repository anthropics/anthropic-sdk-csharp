using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

/// <summary>
/// Rate limiter type.
/// </summary>
[JsonConverter(typeof(BetaWorkspaceRateLimitTypeConverter))]
public enum BetaWorkspaceRateLimitType
{
    FastItpmca,
    FastOtpm,
    InputTokensPerMinute,
    InputTokensPerMinuteCacheAware,
    OutputTokensPerMinute,
    RequestsPerMinute,
    TokensPerDay,
    TokensPerMinute,
    ToolUsesPerSecond,
}

sealed class BetaWorkspaceRateLimitTypeConverter : JsonConverter<BetaWorkspaceRateLimitType>
{
    public override BetaWorkspaceRateLimitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast_itpmca" => BetaWorkspaceRateLimitType.FastItpmca,
            "fast_otpm" => BetaWorkspaceRateLimitType.FastOtpm,
            "input_tokens_per_minute" => BetaWorkspaceRateLimitType.InputTokensPerMinute,
            "input_tokens_per_minute_cache_aware" =>
                BetaWorkspaceRateLimitType.InputTokensPerMinuteCacheAware,
            "output_tokens_per_minute" => BetaWorkspaceRateLimitType.OutputTokensPerMinute,
            "requests_per_minute" => BetaWorkspaceRateLimitType.RequestsPerMinute,
            "tokens_per_day" => BetaWorkspaceRateLimitType.TokensPerDay,
            "tokens_per_minute" => BetaWorkspaceRateLimitType.TokensPerMinute,
            "tool_uses_per_second" => BetaWorkspaceRateLimitType.ToolUsesPerSecond,
            _ => (BetaWorkspaceRateLimitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkspaceRateLimitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkspaceRateLimitType.FastItpmca => "fast_itpmca",
                BetaWorkspaceRateLimitType.FastOtpm => "fast_otpm",
                BetaWorkspaceRateLimitType.InputTokensPerMinute => "input_tokens_per_minute",
                BetaWorkspaceRateLimitType.InputTokensPerMinuteCacheAware =>
                    "input_tokens_per_minute_cache_aware",
                BetaWorkspaceRateLimitType.OutputTokensPerMinute => "output_tokens_per_minute",
                BetaWorkspaceRateLimitType.RequestsPerMinute => "requests_per_minute",
                BetaWorkspaceRateLimitType.TokensPerDay => "tokens_per_day",
                BetaWorkspaceRateLimitType.TokensPerMinute => "tokens_per_minute",
                BetaWorkspaceRateLimitType.ToolUsesPerSecond => "tool_uses_per_second",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
