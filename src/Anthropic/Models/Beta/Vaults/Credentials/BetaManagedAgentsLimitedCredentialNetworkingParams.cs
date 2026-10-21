using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// The destination hosts of the outbound requests that the credential's secret
    /// is substituted into.
    ///
    /// <para>Each entry is a bare hostname (`api.example.com`), an IPv4 address
    /// (`192.0.2.1`), or a `*.` wildcard (`*.example.com`). URLs, ports, paths, and
    /// IPv6 addresses aren't accepted. The list can have up to 16 entries.</para>
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedHosts;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("limited")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsLimitedCredentialNetworkingParams()
    {
        this.Type = JsonSerializer.SerializeToElement("limited");
    }

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

        this.Type = JsonSerializer.SerializeToElement("limited");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsLimitedCredentialNetworkingParams(IReadOnlyList<string> allowedHosts)
        : this()
    {
        this.AllowedHosts = allowedHosts;
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
