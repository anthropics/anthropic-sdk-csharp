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
/// Tool calls are automatically approved without user confirmation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAlwaysAllowPolicy,
        BetaManagedAgentsAlwaysAllowPolicyFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAlwaysAllowPolicy : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsAlwaysAllowPolicy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAllowPolicy(
        BetaManagedAgentsAlwaysAllowPolicy betaManagedAgentsAlwaysAllowPolicy
    )
        : base(betaManagedAgentsAlwaysAllowPolicy) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAlwaysAllowPolicy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAlwaysAllowPolicy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAlwaysAllowPolicyFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAlwaysAllowPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAlwaysAllowPolicy(
        ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsAlwaysAllowPolicyFromRaw : IFromRawJson<BetaManagedAgentsAlwaysAllowPolicy>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAlwaysAllowPolicy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAlwaysAllowPolicy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAlwaysAllowPolicyTypeConverter))]
public enum BetaManagedAgentsAlwaysAllowPolicyType
{
    AlwaysAllow,
}

sealed class BetaManagedAgentsAlwaysAllowPolicyTypeConverter
    : JsonConverter<BetaManagedAgentsAlwaysAllowPolicyType>
{
    public override BetaManagedAgentsAlwaysAllowPolicyType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always_allow" => BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
            _ => (BetaManagedAgentsAlwaysAllowPolicyType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAlwaysAllowPolicyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow => "always_allow",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
