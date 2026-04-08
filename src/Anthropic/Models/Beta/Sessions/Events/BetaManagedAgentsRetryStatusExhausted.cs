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
/// This turn is dead; queued inputs are flushed and the session returns to idle.
/// Client may send a new prompt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusExhausted,
        BetaManagedAgentsRetryStatusExhaustedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusExhausted : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsRetryStatusExhausted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusExhausted(
        BetaManagedAgentsRetryStatusExhausted betaManagedAgentsRetryStatusExhausted
    )
        : base(betaManagedAgentsRetryStatusExhausted) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusExhausted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusExhausted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusExhaustedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusExhausted(
        ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsRetryStatusExhaustedFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusExhausted>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusExhausted.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsRetryStatusExhaustedTypeConverter))]
public enum BetaManagedAgentsRetryStatusExhaustedType
{
    Exhausted,
}

sealed class BetaManagedAgentsRetryStatusExhaustedTypeConverter
    : JsonConverter<BetaManagedAgentsRetryStatusExhaustedType>
{
    public override BetaManagedAgentsRetryStatusExhaustedType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "exhausted" => BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
            _ => (BetaManagedAgentsRetryStatusExhaustedType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsRetryStatusExhaustedType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsRetryStatusExhaustedType.Exhausted => "exhausted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
