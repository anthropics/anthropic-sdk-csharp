using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

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
    /// See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
    /// for details.
    /// </summary>
    public required long BudgetTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("budget_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'budget_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "budget_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["budget_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BudgetTokens;
        _ = this.Type;
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

    [SetsRequiredMembers]
    public ThinkingConfigEnabled(long budgetTokens)
        : this()
    {
        this.BudgetTokens = budgetTokens;
    }
}
