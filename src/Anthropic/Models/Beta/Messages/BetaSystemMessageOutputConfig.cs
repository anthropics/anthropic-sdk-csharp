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
/// Per-message output configuration on a role:"system" input message.
///
/// <para>Fields here apply per-turn; ``format`` remains top-level only. An empty
/// ``{}`` is accepted on a message that carries content; a message with neither content
/// nor output_config fields is rejected.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaSystemMessageOutputConfig, BetaSystemMessageOutputConfigFromRaw>)
)]
public sealed record class BetaSystemMessageOutputConfig : JsonModel
{
    /// <summary>
    /// All possible effort levels.
    /// </summary>
    public ApiEnum<string, BetaSystemMessageOutputConfigEffort>? Effort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaSystemMessageOutputConfigEffort>
            >("effort");
        }
        init { this._rawData.Set("effort", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Effort?.Validate();
    }

    public BetaSystemMessageOutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSystemMessageOutputConfig(
        BetaSystemMessageOutputConfig betaSystemMessageOutputConfig
    )
        : base(betaSystemMessageOutputConfig) { }
#pragma warning restore CS8618

    public BetaSystemMessageOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSystemMessageOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSystemMessageOutputConfigFromRaw.FromRawUnchecked"/>
    public static BetaSystemMessageOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSystemMessageOutputConfigFromRaw : IFromRawJson<BetaSystemMessageOutputConfig>
{
    /// <inheritdoc/>
    public BetaSystemMessageOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSystemMessageOutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// All possible effort levels.
/// </summary>
[JsonConverter(typeof(BetaSystemMessageOutputConfigEffortConverter))]
public enum BetaSystemMessageOutputConfigEffort
{
    Low,
    Medium,
    High,
    Xhigh,
    Max,
}

sealed class BetaSystemMessageOutputConfigEffortConverter
    : JsonConverter<BetaSystemMessageOutputConfigEffort>
{
    public override BetaSystemMessageOutputConfigEffort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BetaSystemMessageOutputConfigEffort.Low,
            "medium" => BetaSystemMessageOutputConfigEffort.Medium,
            "high" => BetaSystemMessageOutputConfigEffort.High,
            "xhigh" => BetaSystemMessageOutputConfigEffort.Xhigh,
            "max" => BetaSystemMessageOutputConfigEffort.Max,
            _ => (BetaSystemMessageOutputConfigEffort)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSystemMessageOutputConfigEffort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSystemMessageOutputConfigEffort.Low => "low",
                BetaSystemMessageOutputConfigEffort.Medium => "medium",
                BetaSystemMessageOutputConfigEffort.High => "high",
                BetaSystemMessageOutputConfigEffort.Xhigh => "xhigh",
                BetaSystemMessageOutputConfigEffort.Max => "max",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
