using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ThinkingConfigEnabled>))]
public sealed record class ThinkingConfigEnabled : ModelBase, IFromRaw<ThinkingConfigEnabled>
{
    /// <summary>
    /// Determines how many tokens Claude can use for its internal reasoning process.
    /// Larger budgets can enable more thorough analysis for complex problems, improving
    /// response quality.
    ///
    /// Must be ≥1024 and less than `max_tokens`.
    ///
    /// See [extended thinking](https://docs.anthropic.com/en/docs/build-with-claude/extended-thinking)
    /// for details.
    /// </summary>
    public required long BudgetTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("budget_tokens", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "budget_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["budget_tokens"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BudgetTokens;
    }

    public ThinkingConfigEnabled()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigEnabled(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThinkingConfigEnabled FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
