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
/// Substitute the secret only on requests to the listed hosts.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsLimitedCredentialNetworkingParams,
        BetaManagedAgentsLimitedCredentialNetworkingParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsLimitedCredentialNetworkingParams : JsonModel
{
    /// <summary>
    /// Hostnames on which the secret will be substituted. Each entry is a bare hostname
    /// (`api.example.com`), an IPv4 address (`192.0.2.1`), or a `*.`-prefixed wildcard
    /// (`*.example.com`). URLs, ports, paths, and IPv6 addresses are not accepted.
    /// At most 16 entries.
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

    public required ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsLimitedCredentialNetworkingParamsType>
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

    public BetaManagedAgentsLimitedCredentialNetworkingParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsLimitedCredentialNetworkingParams(
        BetaManagedAgentsLimitedCredentialNetworkingParams betaManagedAgentsLimitedCredentialNetworkingParams
    )
        : base(betaManagedAgentsLimitedCredentialNetworkingParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsLimitedCredentialNetworkingParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsLimitedCredentialNetworkingParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsLimitedCredentialNetworkingParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsLimitedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsLimitedCredentialNetworkingParamsFromRaw
    : IFromRawJson<BetaManagedAgentsLimitedCredentialNetworkingParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsLimitedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsLimitedCredentialNetworkingParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsLimitedCredentialNetworkingParamsTypeConverter))]
public enum BetaManagedAgentsLimitedCredentialNetworkingParamsType
{
    Limited,
}

sealed class BetaManagedAgentsLimitedCredentialNetworkingParamsTypeConverter
    : JsonConverter<BetaManagedAgentsLimitedCredentialNetworkingParamsType>
{
    public override BetaManagedAgentsLimitedCredentialNetworkingParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "limited" => BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
            _ => (BetaManagedAgentsLimitedCredentialNetworkingParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsLimitedCredentialNetworkingParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited => "limited",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
