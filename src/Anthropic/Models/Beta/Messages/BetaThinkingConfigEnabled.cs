using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaThinkingConfigEnabled>))]
public sealed record class BetaThinkingConfigEnabled
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaThinkingConfigEnabled>
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
            if (!this.Properties.TryGetValue("budget_tokens", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "budget_tokens",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["budget_tokens"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.BudgetTokens;
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"enabled\"")))
        {
            throw new System::Exception();
        }
    }

    public BetaThinkingConfigEnabled()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"enabled\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaThinkingConfigEnabled(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaThinkingConfigEnabled FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
