using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces.RateLimits;

/// <summary>
/// Rate limiter type.
/// </summary>
[JsonConverter(typeof(WorkspaceRateLimitTypeConverter))]
public enum WorkspaceRateLimitType
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

sealed class WorkspaceRateLimitTypeConverter : JsonConverter<WorkspaceRateLimitType>
{
    public override WorkspaceRateLimitType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast_itpmca" => WorkspaceRateLimitType.FastItpmca,
            "fast_otpm" => WorkspaceRateLimitType.FastOtpm,
            "input_tokens_per_minute" => WorkspaceRateLimitType.InputTokensPerMinute,
            "input_tokens_per_minute_cache_aware" =>
                WorkspaceRateLimitType.InputTokensPerMinuteCacheAware,
            "output_tokens_per_minute" => WorkspaceRateLimitType.OutputTokensPerMinute,
            "requests_per_minute" => WorkspaceRateLimitType.RequestsPerMinute,
            "tokens_per_day" => WorkspaceRateLimitType.TokensPerDay,
            "tokens_per_minute" => WorkspaceRateLimitType.TokensPerMinute,
            "tool_uses_per_second" => WorkspaceRateLimitType.ToolUsesPerSecond,
            _ => (WorkspaceRateLimitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspaceRateLimitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspaceRateLimitType.FastItpmca => "fast_itpmca",
                WorkspaceRateLimitType.FastOtpm => "fast_otpm",
                WorkspaceRateLimitType.InputTokensPerMinute => "input_tokens_per_minute",
                WorkspaceRateLimitType.InputTokensPerMinuteCacheAware =>
                    "input_tokens_per_minute_cache_aware",
                WorkspaceRateLimitType.OutputTokensPerMinute => "output_tokens_per_minute",
                WorkspaceRateLimitType.RequestsPerMinute => "requests_per_minute",
                WorkspaceRateLimitType.TokensPerDay => "tokens_per_day",
                WorkspaceRateLimitType.TokensPerMinute => "tokens_per_minute",
                WorkspaceRateLimitType.ToolUsesPerSecond => "tool_uses_per_second",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
