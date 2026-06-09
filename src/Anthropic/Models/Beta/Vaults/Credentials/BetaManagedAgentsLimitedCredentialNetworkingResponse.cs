using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// The secret is substituted only on requests to the listed hosts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsLimitedCredentialNetworkingResponse,
        BetaManagedAgentsLimitedCredentialNetworkingResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsLimitedCredentialNetworkingResponse : JsonModel
{
    /// <summary>
    /// Hostnames on which the secret will be substituted. An entry matches the request
    /// host exactly; a `*.`-prefixed entry matches any subdomain of the named domain
    /// but not the domain itself.
    /// </summary>
    public required IReadOnlyList<string> AllowedHosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("allowed_hosts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "allowed_hosts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedHosts;
        this.Type.Validate();
    }

    public BetaManagedAgentsLimitedCredentialNetworkingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsLimitedCredentialNetworkingResponse(
        BetaManagedAgentsLimitedCredentialNetworkingResponse betaManagedAgentsLimitedCredentialNetworkingResponse
    )
        : base(betaManagedAgentsLimitedCredentialNetworkingResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsLimitedCredentialNetworkingResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsLimitedCredentialNetworkingResponse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsLimitedCredentialNetworkingResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsLimitedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsLimitedCredentialNetworkingResponseFromRaw
    : IFromRawJson<BetaManagedAgentsLimitedCredentialNetworkingResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsLimitedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsLimitedCredentialNetworkingResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsLimitedCredentialNetworkingResponseTypeConverter))]
public enum BetaManagedAgentsLimitedCredentialNetworkingResponseType
{
    Limited,
}

sealed class BetaManagedAgentsLimitedCredentialNetworkingResponseTypeConverter
    : JsonConverter<BetaManagedAgentsLimitedCredentialNetworkingResponseType>
{
    public override BetaManagedAgentsLimitedCredentialNetworkingResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "limited" => BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
            _ => (BetaManagedAgentsLimitedCredentialNetworkingResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsLimitedCredentialNetworkingResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited => "limited",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
