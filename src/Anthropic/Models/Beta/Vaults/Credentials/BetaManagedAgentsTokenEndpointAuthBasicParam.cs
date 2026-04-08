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
        BetaManagedAgentsTokenEndpointAuthBasicParam,
        BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicParam : JsonModel
{
    /// <summary>
    /// OAuth client secret.
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicParamType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientSecret;
        this.Type.Validate();
    }

    public BetaManagedAgentsTokenEndpointAuthBasicParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicParam(
        BetaManagedAgentsTokenEndpointAuthBasicParam betaManagedAgentsTokenEndpointAuthBasicParam
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthBasicParamTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthBasicParamType
{
    ClientSecretBasic,
}

sealed class BetaManagedAgentsTokenEndpointAuthBasicParamTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthBasicParamType>
{
    public override BetaManagedAgentsTokenEndpointAuthBasicParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_basic" =>
                BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
            _ => (BetaManagedAgentsTokenEndpointAuthBasicParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthBasicParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic =>
                    "client_secret_basic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
