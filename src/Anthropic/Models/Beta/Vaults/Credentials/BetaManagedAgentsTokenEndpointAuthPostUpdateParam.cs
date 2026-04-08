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
/// Updated POST body authentication parameters for the token endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam,
        BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostUpdateParam : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updated OAuth client secret.
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ClientSecret;
    }

    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam betaManagedAgentsTokenEndpointAuthPostUpdateParam
    )
        : base(betaManagedAgentsTokenEndpointAuthPostUpdateParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostUpdateParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostUpdateParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostUpdateParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthPostUpdateParamTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthPostUpdateParamType
{
    ClientSecretPost,
}

sealed class BetaManagedAgentsTokenEndpointAuthPostUpdateParamTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
{
    public override BetaManagedAgentsTokenEndpointAuthPostUpdateParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_post" =>
                BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            _ => (BetaManagedAgentsTokenEndpointAuthPostUpdateParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthPostUpdateParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost =>
                    "client_secret_post",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
