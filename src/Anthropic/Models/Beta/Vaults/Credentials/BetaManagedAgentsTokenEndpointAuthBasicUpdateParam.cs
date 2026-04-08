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
/// Updated HTTP Basic authentication parameters for the token endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam,
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicUpdateParam : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType>
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

    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam betaManagedAgentsTokenEndpointAuthBasicUpdateParam
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicUpdateParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicUpdateParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsTokenEndpointAuthBasicUpdateParamTypeConverter))]
public enum BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType
{
    ClientSecretBasic,
}

sealed class BetaManagedAgentsTokenEndpointAuthBasicUpdateParamTypeConverter
    : JsonConverter<BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType>
{
    public override BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_secret_basic" =>
                BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
            _ => (BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic =>
                    "client_secret_basic",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
