using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<OutputConfig, OutputConfigFromRaw>))]
public sealed record class OutputConfig : JsonModel
{
    /// <summary>
    /// All possible effort levels.
    /// </summary>
    public ApiEnum<string, Effort>? Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Effort>>("effort");
        }
        init { this._rawData.Set("effort", value); }
    }

    /// <summary>
    /// A schema to specify Claude's output format in responses. See [structured outputs](https://platform.claude.com/docs/en/build-with-claude/structured-outputs)
    /// </summary>
    public JsonOutputFormat? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JsonOutputFormat>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Effort?.Validate();
        this.Format?.Validate();
    }

    public OutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputConfig(OutputConfig outputConfig)
        : base(outputConfig) { }
#pragma warning restore CS8618

    public OutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputConfigFromRaw.FromRawUnchecked"/>
    public static OutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputConfigFromRaw : IFromRawJson<OutputConfig>
{
    /// <inheritdoc/>
    public OutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// All possible effort levels.
/// </summary>
[JsonConverter(typeof(EffortConverter))]
public enum Effort
{
    Low,
    Medium,
    High,
    Max,
}

sealed class EffortConverter : JsonConverter<Effort>
{
    public override Effort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => Effort.Low,
            "medium" => Effort.Medium,
            "high" => Effort.High,
            "max" => Effort.Max,
            _ => (Effort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Effort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Effort.Low => "low",
                Effort.Medium => "medium",
                Effort.High => "high",
                Effort.Max => "max",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
