using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Structured information about a refusal.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRefusalStopDetails,
        BetaManagedAgentsSessionRefusalStopDetailsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRefusalStopDetails : JsonModel
{
    /// <summary>
    /// The policy category that triggered the refusal, or `null` when there is no
    /// named category. New values can be added over time.
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
    /// Human-readable explanation of the refusal, or `null` when none is available.
    /// The wording can change, so do not parse it.
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

    public BetaManagedAgentsSessionRefusalStopDetails()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRefusalStopDetails(
        BetaManagedAgentsSessionRefusalStopDetails betaManagedAgentsSessionRefusalStopDetails
    )
        : base(betaManagedAgentsSessionRefusalStopDetails) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRefusalStopDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRefusalStopDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRefusalStopDetailsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionRefusalStopDetailsFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRefusalStopDetails>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRefusalStopDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The policy category that triggered the refusal, or `null` when there is no named
/// category. New values can be added over time.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Cyber,
    Bio,
    FrontierLlm,
    ReasoningExtraction,
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
