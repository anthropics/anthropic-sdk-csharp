using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Publicly documented product surfaces. `claude-tag` is Claude Tag, the Claude
/// product in Slack. `chat_cowork_unified` is Chat and Cowork unified, Cowork's
/// features inside claude.ai chat: chat and Cowork usage by a member who has it
/// turned on is reported under this value instead of `chat` or `cowork`. It is accepted
/// as a filter only on deployments that offer Chat and Cowork unified.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsProductFilterConverter))]
public enum BetaAnalyticsProductFilter
{
    Chat,
    ChatCoworkUnified,
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
            "chat_cowork_unified" => BetaAnalyticsProductFilter.ChatCoworkUnified,
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
                BetaAnalyticsProductFilter.ChatCoworkUnified => "chat_cowork_unified",
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
