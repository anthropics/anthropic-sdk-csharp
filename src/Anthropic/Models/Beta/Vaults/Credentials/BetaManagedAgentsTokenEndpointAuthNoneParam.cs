using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Token endpoint requires no client authentication.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthNoneParam,
        BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthNoneParam : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsTokenEndpointAuthNoneParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneParam(
        BetaManagedAgentsTokenEndpointAuthNoneParam betaManagedAgentsTokenEndpointAuthNoneParam
    )
        : base(betaManagedAgentsTokenEndpointAuthNoneParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthNoneParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthNoneParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthNoneParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneParam(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthNoneParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthNoneParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthNoneParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthNoneParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthNoneParamTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthNoneParamType
{
    None,
}

sealed class BetaManagedAgentsTokenEndpointAuthNoneParamTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthNoneParamType>
{
    public override BetaManagedAgentsTokenEndpointAuthNoneParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
            _ => (BetaManagedAgentsTokenEndpointAuthNoneParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthNoneParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None => "none",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
