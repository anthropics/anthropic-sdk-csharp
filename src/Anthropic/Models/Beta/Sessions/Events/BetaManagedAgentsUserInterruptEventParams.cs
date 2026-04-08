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
/// Parameters for sending an interrupt to pause the agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserInterruptEventParams,
        BetaManagedAgentsUserInterruptEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserInterruptEventParams : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsUserInterruptEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserInterruptEventParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsUserInterruptEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEventParams(
        BetaManagedAgentsUserInterruptEventParams betaManagedAgentsUserInterruptEventParams
    )
        : base(betaManagedAgentsUserInterruptEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserInterruptEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserInterruptEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserInterruptEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserInterruptEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEventParams(
        ApiEnum<string, BetaManagedAgentsUserInterruptEventParamsType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsUserInterruptEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserInterruptEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserInterruptEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserInterruptEventParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUserInterruptEventParamsTypeConverter))]
public enum BetaManagedAgentsUserInterruptEventParamsType
{
    UserInterrupt,
}

sealed class BetaManagedAgentsUserInterruptEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUserInterruptEventParamsType>
{
    public override BetaManagedAgentsUserInterruptEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.interrupt" => BetaManagedAgentsUserInterruptEventParamsType.UserInterrupt,
            _ => (BetaManagedAgentsUserInterruptEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserInterruptEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserInterruptEventParamsType.UserInterrupt => "user.interrupt",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
