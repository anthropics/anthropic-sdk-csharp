using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ThinkingConfigEnabled, ThinkingConfigEnabledFromRaw>))]
public sealed record class ThinkingConfigEnabled : JsonModel
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
    public ApiEnum<string, ThinkingConfigEnabledDisplay>? Display
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ThinkingConfigEnabledDisplay>>(
                "display"
            );
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

    public ThinkingConfigEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingConfigEnabled(ThinkingConfigEnabled thinkingConfigEnabled)
        : base(thinkingConfigEnabled) { }
#pragma warning restore CS8618

    public ThinkingConfigEnabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ThinkingConfigEnabledFromRaw : IFromRawJson<ThinkingConfigEnabled>
{
    /// <inheritdoc/>
    public ThinkingConfigEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThinkingConfigEnabled.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls how thinking content appears in the response. When set to `summarized`,
/// thinking is returned normally. When set to `omitted`, thinking content is redacted
/// but a signature is returned for multi-turn continuity. Defaults to `summarized`.
/// </summary>
[JsonConverter(typeof(ThinkingConfigEnabledDisplayConverter))]
public enum ThinkingConfigEnabledDisplay
{
    Summarized,
    Omitted,
}

sealed class ThinkingConfigEnabledDisplayConverter : JsonConverter<ThinkingConfigEnabledDisplay>
{
    public override ThinkingConfigEnabledDisplay Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summarized" => ThinkingConfigEnabledDisplay.Summarized,
            "omitted" => ThinkingConfigEnabledDisplay.Omitted,
            _ => (ThinkingConfigEnabledDisplay)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThinkingConfigEnabledDisplay value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThinkingConfigEnabledDisplay.Summarized => "summarized",
                ThinkingConfigEnabledDisplay.Omitted => "omitted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
