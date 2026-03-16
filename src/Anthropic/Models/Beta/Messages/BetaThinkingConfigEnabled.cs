using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("budget_tokens");
        }
        init { this._rawData.Set("budget_tokens", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Controls how thinking content appears in the response. When set to `summarized`,
    /// thinking is returned normally. When set to `omitted`, thinking content is
    /// redacted but a signature is returned for multi-turn continuity. Defaults to `summarized`.
    /// </summary>
    public ApiEnum<string, BetaThinkingConfigEnabledDisplay>? Display
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaThinkingConfigEnabledDisplay>
            >("display");
        }
        init { this._rawData.Set("display", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BudgetTokens;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Display?.Validate();
    }

    public BetaThinkingConfigEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingConfigEnabled(BetaThinkingConfigEnabled betaThinkingConfigEnabled)
        : base(betaThinkingConfigEnabled) { }
#pragma warning restore CS8618

    public BetaThinkingConfigEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

/// <summary>
/// Controls how thinking content appears in the response. When set to `summarized`,
/// thinking is returned normally. When set to `omitted`, thinking content is redacted
/// but a signature is returned for multi-turn continuity. Defaults to `summarized`.
/// </summary>
[JsonConverter(typeof(BetaThinkingConfigEnabledDisplayConverter))]
public enum BetaThinkingConfigEnabledDisplay
{
    Summarized,
    Omitted,
}

sealed class BetaThinkingConfigEnabledDisplayConverter
    : JsonConverter<BetaThinkingConfigEnabledDisplay>
{
    public override BetaThinkingConfigEnabledDisplay Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summarized" => BetaThinkingConfigEnabledDisplay.Summarized,
            "omitted" => BetaThinkingConfigEnabledDisplay.Omitted,
            _ => (BetaThinkingConfigEnabledDisplay)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingConfigEnabledDisplay value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaThinkingConfigEnabledDisplay.Summarized => "summarized",
                BetaThinkingConfigEnabledDisplay.Omitted => "omitted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
