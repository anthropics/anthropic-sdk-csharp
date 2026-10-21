using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsClaudeTagCategoryConverter))]
public enum BetaAnalyticsClaudeTagCategory
{
    Dm,
    Engaged,
    Monitoring,
    Proactive,
    Scheduled,
}

sealed class BetaAnalyticsClaudeTagCategoryConverter : JsonConverter<BetaAnalyticsClaudeTagCategory>
{
    public override BetaAnalyticsClaudeTagCategory Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dm" => BetaAnalyticsClaudeTagCategory.Dm,
            "engaged" => BetaAnalyticsClaudeTagCategory.Engaged,
            "monitoring" => BetaAnalyticsClaudeTagCategory.Monitoring,
            "proactive" => BetaAnalyticsClaudeTagCategory.Proactive,
            "scheduled" => BetaAnalyticsClaudeTagCategory.Scheduled,
            _ => (BetaAnalyticsClaudeTagCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsClaudeTagCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsClaudeTagCategory.Dm => "dm",
                BetaAnalyticsClaudeTagCategory.Engaged => "engaged",
                BetaAnalyticsClaudeTagCategory.Monitoring => "monitoring",
                BetaAnalyticsClaudeTagCategory.Proactive => "proactive",
                BetaAnalyticsClaudeTagCategory.Scheduled => "scheduled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
