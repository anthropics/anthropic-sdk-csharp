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
        BetaManagedAgentsTokenEndpointAuthNoneResponse,
        BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthNoneResponse : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsTokenEndpointAuthNoneResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneResponse(
        BetaManagedAgentsTokenEndpointAuthNoneResponse betaManagedAgentsTokenEndpointAuthNoneResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthNoneResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthNoneResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthNoneResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthNoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthNoneResponse(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneResponseType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthNoneResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthNoneResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthNoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthNoneResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthNoneResponseTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthNoneResponseType
{
    None,
}

sealed class BetaManagedAgentsTokenEndpointAuthNoneResponseTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthNoneResponseType>
{
    public override BetaManagedAgentsTokenEndpointAuthNoneResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => BetaManagedAgentsTokenEndpointAuthNoneResponseType.None,
            _ => (BetaManagedAgentsTokenEndpointAuthNoneResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthNoneResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None => "none",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
