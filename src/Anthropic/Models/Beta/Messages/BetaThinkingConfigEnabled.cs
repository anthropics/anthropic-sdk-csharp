using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaThinkingConfigEnabled, BetaThinkingConfigEnabledFromRaw>)
)]
public sealed record class BetaThinkingConfigEnabled : JsonModel
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
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "budget_tokens"); }
        init { JsonModel.Set(this._rawData, "budget_tokens", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
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

    public BetaThinkingConfigEnabled(BetaThinkingConfigEnabled betaThinkingConfigEnabled)
        : base(betaThinkingConfigEnabled) { }

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

    /// <inheritdoc cref="BetaThinkingConfigEnabledFromRaw.FromRawUnchecked"/>
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

class BetaThinkingConfigEnabledFromRaw : IFromRawJson<BetaThinkingConfigEnabled>
{
    /// <inheritdoc/>
    public BetaThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingConfigEnabled.FromRawUnchecked(rawData);
}
