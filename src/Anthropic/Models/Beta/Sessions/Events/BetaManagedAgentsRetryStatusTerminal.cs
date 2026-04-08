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
/// The session encountered a terminal error and will transition to `terminated` state.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRetryStatusTerminal,
        BetaManagedAgentsRetryStatusTerminalFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRetryStatusTerminal : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsRetryStatusTerminal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusTerminal(
        BetaManagedAgentsRetryStatusTerminal betaManagedAgentsRetryStatusTerminal
    )
        : base(betaManagedAgentsRetryStatusTerminal) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRetryStatusTerminal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRetryStatusTerminal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRetryStatusTerminalFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRetryStatusTerminal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsRetryStatusTerminal(
        ApiEnum<string, BetaManagedAgentsRetryStatusTerminalType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsRetryStatusTerminalFromRaw
    : IFromRawJson<BetaManagedAgentsRetryStatusTerminal>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRetryStatusTerminal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRetryStatusTerminal.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsRetryStatusTerminalTypeConverter))]
public enum BetaManagedAgentsRetryStatusTerminalType
{
    Terminal,
}

sealed class BetaManagedAgentsRetryStatusTerminalTypeConverter
    : JsonConverter<BetaManagedAgentsRetryStatusTerminalType>
{
    public override BetaManagedAgentsRetryStatusTerminalType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "terminal" => BetaManagedAgentsRetryStatusTerminalType.Terminal,
            _ => (BetaManagedAgentsRetryStatusTerminalType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsRetryStatusTerminalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsRetryStatusTerminalType.Terminal => "terminal",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
