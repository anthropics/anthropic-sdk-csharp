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
/// Parameters for updating a static bearer token credential. The `mcp_server_url`
/// is immutable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerUpdateParams,
        BetaManagedAgentsStaticBearerUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerUpdateParams : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsStaticBearerUpdateParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsStaticBearerUpdateParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Updated static bearer token value.
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Token;
    }

    public BetaManagedAgentsStaticBearerUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerUpdateParams(
        BetaManagedAgentsStaticBearerUpdateParams betaManagedAgentsStaticBearerUpdateParams
    )
        : base(betaManagedAgentsStaticBearerUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerUpdateParams(
        ApiEnum<string, BetaManagedAgentsStaticBearerUpdateParamsType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsStaticBearerUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerUpdateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsStaticBearerUpdateParamsTypeConverter))]
public enum BetaManagedAgentsStaticBearerUpdateParamsType
{
    StaticBearer,
}

sealed class BetaManagedAgentsStaticBearerUpdateParamsTypeConverter
    : JsonConverter<BetaManagedAgentsStaticBearerUpdateParamsType>
{
    public override BetaManagedAgentsStaticBearerUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "static_bearer" => BetaManagedAgentsStaticBearerUpdateParamsType.StaticBearer,
            _ => (BetaManagedAgentsStaticBearerUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsStaticBearerUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsStaticBearerUpdateParamsType.StaticBearer => "static_bearer",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
