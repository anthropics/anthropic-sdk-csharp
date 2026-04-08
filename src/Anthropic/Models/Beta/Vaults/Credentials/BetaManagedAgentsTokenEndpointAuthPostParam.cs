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
        BetaManagedAgentsTokenEndpointAuthPostParam,
        BetaManagedAgentsTokenEndpointAuthPostParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostParam : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType>
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

    public BetaManagedAgentsTokenEndpointAuthPostParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostParam(
        BetaManagedAgentsTokenEndpointAuthPostParam betaManagedAgentsTokenEndpointAuthPostParam
    )
        : base(betaManagedAgentsTokenEndpointAuthPostParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthPostParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthPostParamTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthPostParamType
{
    ClientSecretPost,
}

sealed class BetaManagedAgentsTokenEndpointAuthPostParamTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthPostParamType>
{
    public override BetaManagedAgentsTokenEndpointAuthPostParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_post" =>
                BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
            _ => (BetaManagedAgentsTokenEndpointAuthPostParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthPostParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost =>
                    "client_secret_post",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
