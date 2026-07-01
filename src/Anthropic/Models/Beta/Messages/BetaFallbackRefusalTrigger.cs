using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The `from` model declined for policy reasons.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaFallbackRefusalTrigger, BetaFallbackRefusalTriggerFromRaw>)
)]
public sealed record class BetaFallbackRefusalTrigger : JsonModel
{
    /// <summary>
    /// The policy category that triggered a refusal.
    /// </summary>
    public required ApiEnum<string, BetaFallbackRefusalTriggerCategory>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaFallbackRefusalTriggerCategory>
            >("category");
        }
        init { this._rawData.Set("category", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category?.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("refusal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFallbackRefusalTrigger()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackRefusalTrigger(BetaFallbackRefusalTrigger betaFallbackRefusalTrigger)
        : base(betaFallbackRefusalTrigger) { }
#pragma warning restore CS8618

    public BetaFallbackRefusalTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackRefusalTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackRefusalTriggerFromRaw.FromRawUnchecked"/>
    public static BetaFallbackRefusalTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaFallbackRefusalTrigger(ApiEnum<string, BetaFallbackRefusalTriggerCategory>? category)
        : this()
    {
        this.Category = category;
    }
}

class BetaFallbackRefusalTriggerFromRaw : IFromRawJson<BetaFallbackRefusalTrigger>
{
    /// <inheritdoc/>
    public BetaFallbackRefusalTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackRefusalTrigger.FromRawUnchecked(rawData);
}

/// <summary>
/// The policy category that triggered a refusal.
/// </summary>
[JsonConverter(typeof(BetaFallbackRefusalTriggerCategoryConverter))]
public enum BetaFallbackRefusalTriggerCategory
{
    Cyber,
    Bio,
    FrontierLlm,
    ReasoningExtraction,
}

sealed class BetaFallbackRefusalTriggerCategoryConverter
    : JsonConverter<BetaFallbackRefusalTriggerCategory>
{
    public override BetaFallbackRefusalTriggerCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cyber" => BetaFallbackRefusalTriggerCategory.Cyber,
            "bio" => BetaFallbackRefusalTriggerCategory.Bio,
            "frontier_llm" => BetaFallbackRefusalTriggerCategory.FrontierLlm,
            "reasoning_extraction" => BetaFallbackRefusalTriggerCategory.ReasoningExtraction,
            _ => (BetaFallbackRefusalTriggerCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaFallbackRefusalTriggerCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaFallbackRefusalTriggerCategory.Cyber => "cyber",
                BetaFallbackRefusalTriggerCategory.Bio => "bio",
                BetaFallbackRefusalTriggerCategory.FrontierLlm => "frontier_llm",
                BetaFallbackRefusalTriggerCategory.ReasoningExtraction => "reasoning_extraction",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
