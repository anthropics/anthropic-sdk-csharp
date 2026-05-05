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
/// Rubric content provided inline as text.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsTextRubric, BetaManagedAgentsTextRubricFromRaw>)
)]
public sealed record class BetaManagedAgentsTextRubric : JsonModel
{
    /// <summary>
    /// Rubric content. Plain text or markdown — the grader treats it as freeform text.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsTextRubricType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsTextRubricType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type.Validate();
    }

    public BetaManagedAgentsTextRubric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubric(BetaManagedAgentsTextRubric betaManagedAgentsTextRubric)
        : base(betaManagedAgentsTextRubric) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextRubric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextRubric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextRubricFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTextRubricFromRaw : IFromRawJson<BetaManagedAgentsTextRubric>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextRubric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTextRubricTypeConverter))]
public enum BetaManagedAgentsTextRubricType
{
    Text,
}

sealed class BetaManagedAgentsTextRubricTypeConverter
    : JsonConverter<BetaManagedAgentsTextRubricType>
{
    public override BetaManagedAgentsTextRubricType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsTextRubricType.Text,
            _ => (BetaManagedAgentsTextRubricType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTextRubricType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTextRubricType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
