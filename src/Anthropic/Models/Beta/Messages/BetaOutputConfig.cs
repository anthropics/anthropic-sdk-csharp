using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaOutputConfig, BetaOutputConfigFromRaw>))]
public sealed record class BetaOutputConfig : ModelBase
{
    /// <summary>
    /// All possible effort levels.
    /// </summary>
    public ApiEnum<string, Effort>? Effort
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Effort>>(this.RawData, "effort"); }
        init { ModelBase.Set(this._rawData, "effort", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Effort?.Validate();
    }

    public BetaOutputConfig() { }

    public BetaOutputConfig(BetaOutputConfig betaOutputConfig)
        : base(betaOutputConfig) { }

    public BetaOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOutputConfigFromRaw.FromRawUnchecked"/>
    public static BetaOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOutputConfigFromRaw : IFromRaw<BetaOutputConfig>
{
    /// <inheritdoc/>
    public BetaOutputConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaOutputConfig.FromRawUnchecked(rawData);
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
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
