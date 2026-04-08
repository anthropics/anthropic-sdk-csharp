using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Tool calls require user confirmation before execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAlwaysAskPolicy,
        BetaManagedAgentsAlwaysAskPolicyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAlwaysAskPolicy : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsAlwaysAskPolicy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAskPolicy(
        BetaManagedAgentsAlwaysAskPolicy betaManagedAgentsAlwaysAskPolicy
    )
        : base(betaManagedAgentsAlwaysAskPolicy) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAlwaysAskPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAlwaysAskPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAlwaysAskPolicyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAlwaysAskPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAskPolicy(
        ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsAlwaysAskPolicyFromRaw : IFromRawJson<BetaManagedAgentsAlwaysAskPolicy>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAlwaysAskPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAlwaysAskPolicy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAlwaysAskPolicyTypeConverter))]
public enum BetaManagedAgentsAlwaysAskPolicyType
{
    AlwaysAsk,
}

sealed class BetaManagedAgentsAlwaysAskPolicyTypeConverter
    : JsonConverter<BetaManagedAgentsAlwaysAskPolicyType>
{
    public override BetaManagedAgentsAlwaysAskPolicyType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always_ask" => BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
            _ => (BetaManagedAgentsAlwaysAskPolicyType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAlwaysAskPolicyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk => "always_ask",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
