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
/// The server is retrying automatically. Client should wait; the same error type
/// may fire again as retrying, then once as exhausted when the retry budget runs out.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusRetrying,
        BetaManagedAgentsRetryStatusRetryingFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusRetrying : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsRetryStatusRetrying() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusRetrying(
        BetaManagedAgentsRetryStatusRetrying betaManagedAgentsRetryStatusRetrying
    )
        : base(betaManagedAgentsRetryStatusRetrying) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusRetrying(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusRetrying(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusRetryingFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusRetrying FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusRetrying(
        ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsRetryStatusRetryingFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusRetrying>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusRetrying FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusRetrying.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsRetryStatusRetryingTypeConverter))]
public enum BetaManagedAgentsRetryStatusRetryingType
{
    Retrying,
}

sealed class BetaManagedAgentsRetryStatusRetryingTypeConverter
    : JsonConverter<BetaManagedAgentsRetryStatusRetryingType>
{
    public override BetaManagedAgentsRetryStatusRetryingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retrying" => BetaManagedAgentsRetryStatusRetryingType.Retrying,
            _ => (BetaManagedAgentsRetryStatusRetryingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsRetryStatusRetryingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsRetryStatusRetryingType.Retrying => "retrying",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
