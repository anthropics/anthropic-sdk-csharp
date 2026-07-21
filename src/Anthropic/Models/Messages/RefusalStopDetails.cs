using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Structured information about a refusal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RefusalStopDetails, RefusalStopDetailsFromRaw>))]
public sealed record class RefusalStopDetails : JsonModel
{
    /// <summary>
    /// The policy category that triggered a refusal.
    /// </summary>
    public required ApiEnum<string, Category>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Human-readable explanation of the refusal.
    ///
    /// <para>This text is not guaranteed to be stable. `null` when no explanation
    /// is available for the category.</para>
    /// </summary>
    public required string? Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
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
        _ = this.Explanation;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("refusal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RefusalStopDetails()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RefusalStopDetails(RefusalStopDetails refusalStopDetails)
        : base(refusalStopDetails) { }
#pragma warning restore CS8618

    public RefusalStopDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RefusalStopDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RefusalStopDetailsFromRaw.FromRawUnchecked"/>
    public static RefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RefusalStopDetailsFromRaw : IFromRawJson<RefusalStopDetails>
{
    /// <inheritdoc/>
    public RefusalStopDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RefusalStopDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The policy category that triggered a refusal.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The request could enable cyber harm, such as malware or exploit development.
    /// Benign cybersecurity work can also trigger this category.
    /// </summary>
    Cyber,

    /// <summary>
    /// The request could enable biological harm, such as dangerous lab methods. Beneficial
    /// life sciences work can also trigger this category.
    /// </summary>
    Bio,

    /// <summary>
    /// The request could assist the development of competing AI models, which is
    /// restricted under [Anthropic's commercial terms](https://www.anthropic.com/legal/commercial-terms).
    /// Benign machine learning work can also trigger this category.
    /// </summary>
    FrontierLlm,

    /// <summary>
    /// The request asks the model to reproduce its internal reasoning in the response
    /// text. To get reasoning in a structured form instead, use [adaptive thinking](https://platform.claude.com/docs/en/build-with-claude/adaptive-thinking).
    /// </summary>
    ReasoningExtraction,

    /// <summary>
    /// The request could be related to an area that was determined as harmful. Benign
    /// work might sometimes trigger this category.
    /// </summary>
    GeneralHarms,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cyber" => Category.Cyber,
            "bio" => Category.Bio,
            "frontier_llm" => Category.FrontierLlm,
            "reasoning_extraction" => Category.ReasoningExtraction,
            "general_harms" => Category.GeneralHarms,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Cyber => "cyber",
                Category.Bio => "bio",
                Category.FrontierLlm => "frontier_llm",
                Category.ReasoningExtraction => "reasoning_extraction",
                Category.GeneralHarms => "general_harms",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
