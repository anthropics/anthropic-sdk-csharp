using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Publicly documented product surfaces. `claude_tag` is Claude Tag, the Claude
/// product in Slack. `chat_cowork_unified` is Chat and Cowork unified, Cowork's
/// features inside claude.ai chat: chat and Cowork usage by a member who has it
/// turned on is reported under this value instead of `chat` or `cowork`. It is accepted
/// as a filter only where Chat and Cowork unified is available.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUsageCostProductFilterConverter))]
public enum BetaAnalyticsUsageCostProductFilter
{
    Chat = 0,
    ChatCoworkUnified = 1,
    ClaudeCode = 2,
    ClaudeConsole = 3,
    ClaudeDesign = 4,
    ClaudeInChrome = 5,
    ClaudeTag = 6,
    Cowork = 7,
    ManagedAgentsApi = 8,
    MessageBatchesApi = 9,
    MessagesApi = 10,
    OfficeAgent = 11,
}

sealed class BetaAnalyticsUsageCostProductFilterConverter
    : JsonConverter<BetaAnalyticsUsageCostProductFilter>
{
    public override BetaAnalyticsUsageCostProductFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "chat" => BetaAnalyticsUsageCostProductFilter.Chat,
            "chat_cowork_unified" => BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified,
            "claude_code" => BetaAnalyticsUsageCostProductFilter.ClaudeCode,
            "claude_console" => BetaAnalyticsUsageCostProductFilter.ClaudeConsole,
            "claude_design" => BetaAnalyticsUsageCostProductFilter.ClaudeDesign,
            "claude_in_chrome" => BetaAnalyticsUsageCostProductFilter.ClaudeInChrome,
            "claude_tag" => BetaAnalyticsUsageCostProductFilter.ClaudeTag,
            "cowork" => BetaAnalyticsUsageCostProductFilter.Cowork,
            "managed_agents_api" => BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi,
            "message_batches_api" => BetaAnalyticsUsageCostProductFilter.MessageBatchesApi,
            "messages_api" => BetaAnalyticsUsageCostProductFilter.MessagesApi,
            "office_agent" => BetaAnalyticsUsageCostProductFilter.OfficeAgent,
            _ => (BetaAnalyticsUsageCostProductFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageCostProductFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageCostProductFilter.Chat => "chat",
                BetaAnalyticsUsageCostProductFilter.ChatCoworkUnified => "chat_cowork_unified",
                BetaAnalyticsUsageCostProductFilter.ClaudeCode => "claude_code",
                BetaAnalyticsUsageCostProductFilter.ClaudeConsole => "claude_console",
                BetaAnalyticsUsageCostProductFilter.ClaudeDesign => "claude_design",
                BetaAnalyticsUsageCostProductFilter.ClaudeInChrome => "claude_in_chrome",
                BetaAnalyticsUsageCostProductFilter.ClaudeTag => "claude_tag",
                BetaAnalyticsUsageCostProductFilter.Cowork => "cowork",
                BetaAnalyticsUsageCostProductFilter.ManagedAgentsApi => "managed_agents_api",
                BetaAnalyticsUsageCostProductFilter.MessageBatchesApi => "message_batches_api",
                BetaAnalyticsUsageCostProductFilter.MessagesApi => "messages_api",
                BetaAnalyticsUsageCostProductFilter.OfficeAgent => "office_agent",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
