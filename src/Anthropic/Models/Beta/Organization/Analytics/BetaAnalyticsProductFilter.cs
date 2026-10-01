using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Publicly documented product surfaces. `claude-tag` is Claude Tag, the Claude
/// product in Slack.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsProductFilterConverter))]
public enum BetaAnalyticsProductFilter
{
    Chat,
    ClaudeTag,
    ClaudeCode,
    ClaudeDesign,
    ClaudeInChrome,
    Cowork,
    OfficeAgent,
}

sealed class BetaAnalyticsProductFilterConverter : JsonConverter<BetaAnalyticsProductFilter>
{
    public override BetaAnalyticsProductFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chat" => BetaAnalyticsProductFilter.Chat,
            "claude-tag" => BetaAnalyticsProductFilter.ClaudeTag,
            "claude_code" => BetaAnalyticsProductFilter.ClaudeCode,
            "claude_design" => BetaAnalyticsProductFilter.ClaudeDesign,
            "claude_in_chrome" => BetaAnalyticsProductFilter.ClaudeInChrome,
            "cowork" => BetaAnalyticsProductFilter.Cowork,
            "office_agent" => BetaAnalyticsProductFilter.OfficeAgent,
            _ => (BetaAnalyticsProductFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsProductFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsProductFilter.Chat => "chat",
                BetaAnalyticsProductFilter.ClaudeTag => "claude-tag",
                BetaAnalyticsProductFilter.ClaudeCode => "claude_code",
                BetaAnalyticsProductFilter.ClaudeDesign => "claude_design",
                BetaAnalyticsProductFilter.ClaudeInChrome => "claude_in_chrome",
                BetaAnalyticsProductFilter.Cowork => "cowork",
                BetaAnalyticsProductFilter.OfficeAgent => "office_agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
