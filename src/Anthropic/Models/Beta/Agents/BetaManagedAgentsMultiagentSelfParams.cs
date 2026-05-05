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
/// Sentinel roster entry meaning "the agent that owns this configuration". Resolved
/// server-side to a concrete agent reference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentSelfParams,
        BetaManagedAgentsMultiagentSelfParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSelfParams : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsMultiagentSelfParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMultiagentSelfParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsMultiagentSelfParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSelfParams(
        BetaManagedAgentsMultiagentSelfParams betaManagedAgentsMultiagentSelfParams
    )
        : base(betaManagedAgentsMultiagentSelfParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSelfParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSelfParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSelfParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSelfParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSelfParams(
        ApiEnum<string, BetaManagedAgentsMultiagentSelfParamsType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsMultiagentSelfParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSelfParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSelfParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSelfParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentSelfParamsTypeConverter))]
public enum BetaManagedAgentsMultiagentSelfParamsType
{
    Self,
}

sealed class BetaManagedAgentsMultiagentSelfParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentSelfParamsType>
{
    public override BetaManagedAgentsMultiagentSelfParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "self" => BetaManagedAgentsMultiagentSelfParamsType.Self,
            _ => (BetaManagedAgentsMultiagentSelfParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentSelfParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentSelfParamsType.Self => "self",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
