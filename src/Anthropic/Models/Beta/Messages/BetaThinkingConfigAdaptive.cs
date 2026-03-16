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
    typeof(JsonModelConverter<BetaThinkingConfigAdaptive, BetaThinkingConfigAdaptiveFromRaw>)
)]
public sealed record class BetaThinkingConfigAdaptive : JsonModel
{
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
    public ApiEnum<string, Display>? Display
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Display>>("display");
        }
        init { this._rawData.Set("display", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("adaptive")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Display?.Validate();
    }

    public BetaThinkingConfigAdaptive()
    {
        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingConfigAdaptive(BetaThinkingConfigAdaptive betaThinkingConfigAdaptive)
        : base(betaThinkingConfigAdaptive) { }
#pragma warning restore CS8618

    public BetaThinkingConfigAdaptive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigAdaptive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingConfigAdaptiveFromRaw.FromRawUnchecked"/>
    public static BetaThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingConfigAdaptiveFromRaw : IFromRawJson<BetaThinkingConfigAdaptive>
{
    /// <inheritdoc/>
    public BetaThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThinkingConfigAdaptive.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls how thinking content appears in the response. When set to `summarized`,
/// thinking is returned normally. When set to `omitted`, thinking content is redacted
/// but a signature is returned for multi-turn continuity. Defaults to `summarized`.
/// </summary>
[JsonConverter(typeof(DisplayConverter))]
public enum Display
{
    Summarized,
    Omitted,
}

sealed class DisplayConverter : JsonConverter<Display>
{
    public override Display Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summarized" => Display.Summarized,
            "omitted" => Display.Omitted,
            _ => (Display)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Display value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Display.Summarized => "summarized",
                Display.Omitted => "omitted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
