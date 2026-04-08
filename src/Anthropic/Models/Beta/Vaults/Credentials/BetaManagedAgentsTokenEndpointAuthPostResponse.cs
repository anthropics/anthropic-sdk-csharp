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
/// Token endpoint uses POST body authentication with client credentials.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthPostResponse,
        BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostResponse : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsTokenEndpointAuthPostResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostResponse(
        BetaManagedAgentsTokenEndpointAuthPostResponse betaManagedAgentsTokenEndpointAuthPostResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthPostResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostResponse(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostResponseType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthPostResponseTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthPostResponseType
{
    ClientSecretPost,
}

sealed class BetaManagedAgentsTokenEndpointAuthPostResponseTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthPostResponseType>
{
    public override BetaManagedAgentsTokenEndpointAuthPostResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_post" =>
                BetaManagedAgentsTokenEndpointAuthPostResponseType.ClientSecretPost,
            _ => (BetaManagedAgentsTokenEndpointAuthPostResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthPostResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthPostResponseType.ClientSecretPost =>
                    "client_secret_post",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
