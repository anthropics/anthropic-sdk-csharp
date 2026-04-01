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
/// Structured information about a refusal.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaRefusalStopDetails, BetaRefusalStopDetailsFromRaw>))]
public sealed record class BetaRefusalStopDetails : JsonModel
{
    /// <summary>
    /// The policy category that triggered the refusal.
    ///
    /// <para>`null` when the refusal doesn't map to a named category.</para>
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

    public BetaRefusalStopDetails()
    {
        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRefusalStopDetails(BetaRefusalStopDetails betaRefusalStopDetails)
        : base(betaRefusalStopDetails) { }
#pragma warning restore CS8618

    public BetaRefusalStopDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refusal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRefusalStopDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRefusalStopDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRefusalStopDetailsFromRaw : IFromRawJson<BetaRefusalStopDetails>
{
    /// <inheritdoc/>
    public BetaRefusalStopDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRefusalStopDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The policy category that triggered the refusal.
///
/// <para>`null` when the refusal doesn't map to a named category.</para>
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Cyber,
    Bio,
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
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
