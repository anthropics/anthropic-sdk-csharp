using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingConfigEnabled, BetaThinkingConfigEnabledFromRaw>))]
public sealed record class BetaThinkingConfigEnabled : ModelBase
{
    /// <summary>
    /// Determines how many tokens Claude can use for its internal reasoning process.
    /// Larger budgets can enable more thorough analysis for complex problems, improving
    /// response quality.
    ///
    /// <para>Must be ≥1024 and less than `max_tokens`.</para>
    ///
    /// <para>See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
    /// for details.</para>
    /// </summary>
    public required long BudgetTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("budget_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'budget_tokens' cannot be null",
                    new ArgumentOutOfRangeException("budget_tokens", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["budget_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BudgetTokens;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"enabled\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingConfigEnabled()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");
    }

    public BetaThinkingConfigEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaThinkingConfigEnabled(long budgetTokens)
        : this()
    {
        this.BudgetTokens = budgetTokens;
    }
}

class BetaThinkingConfigEnabledFromRaw : IFromRaw<BetaThinkingConfigEnabled>
{
    public BetaThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingConfigEnabled.FromRawUnchecked(rawData);
}
