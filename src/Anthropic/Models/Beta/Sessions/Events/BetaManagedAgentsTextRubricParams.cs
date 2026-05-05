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
    typeof(JsonModelConverter<
        BetaManagedAgentsTextRubricParams,
        BetaManagedAgentsTextRubricParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTextRubricParams : JsonModel
{
    /// <summary>
    /// Rubric content. Plain text or markdown — the grader treats it as freeform
    /// text. Maximum 262144 characters.
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

    public required ApiEnum<string, BetaManagedAgentsTextRubricParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTextRubricParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type.Validate();
    }

    public BetaManagedAgentsTextRubricParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubricParams(
        BetaManagedAgentsTextRubricParams betaManagedAgentsTextRubricParams
    )
        : base(betaManagedAgentsTextRubricParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextRubricParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextRubricParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextRubricParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTextRubricParamsFromRaw : IFromRawJson<BetaManagedAgentsTextRubricParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextRubricParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTextRubricParamsTypeConverter))]
public enum BetaManagedAgentsTextRubricParamsType
{
    Text,
}

sealed class BetaManagedAgentsTextRubricParamsTypeConverter
    : JsonConverter<BetaManagedAgentsTextRubricParamsType>
{
    public override BetaManagedAgentsTextRubricParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BetaManagedAgentsTextRubricParamsType.Text,
            _ => (BetaManagedAgentsTextRubricParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTextRubricParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTextRubricParamsType.Text => "text",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
