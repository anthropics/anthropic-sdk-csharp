using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ThinkingConfigEnabled, ThinkingConfigEnabledFromRaw>))]
public sealed record class ThinkingConfigEnabled : ModelBase
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
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "budget_tokens"); }
        init { ModelBase.Set(this._rawData, "budget_tokens", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public ThinkingConfigEnabled()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");
    }

    public ThinkingConfigEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingConfigEnabledFromRaw.FromRawUnchecked"/>
    public static ThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ThinkingConfigEnabled(long budgetTokens)
        : this()
    {
        this.BudgetTokens = budgetTokens;
    }
}

class ThinkingConfigEnabledFromRaw : IFromRaw<ThinkingConfigEnabled>
{
    /// <inheritdoc/>
    public ThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThinkingConfigEnabled.FromRawUnchecked(rawData);
}
