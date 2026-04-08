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
/// Token endpoint uses HTTP Basic authentication with client credentials.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthBasicResponse,
        BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicResponse : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsTokenEndpointAuthBasicResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicResponse(
        BetaManagedAgentsTokenEndpointAuthBasicResponse betaManagedAgentsTokenEndpointAuthBasicResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicResponse(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicResponseType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthBasicResponseTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthBasicResponseType
{
    ClientSecretBasic,
}

sealed class BetaManagedAgentsTokenEndpointAuthBasicResponseTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthBasicResponseType>
{
    public override BetaManagedAgentsTokenEndpointAuthBasicResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_basic" =>
                BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic,
            _ => (BetaManagedAgentsTokenEndpointAuthBasicResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthBasicResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic =>
                    "client_secret_basic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
