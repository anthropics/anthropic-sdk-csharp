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
    /// The destination hosts of the outbound requests that the credential's secret
    /// is substituted into.
    ///
    /// <para>An entry matches the request host exactly. An entry such as `*.example.com`
    /// matches any subdomain of `example.com` but not `example.com` itself.</para>
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

    public BetaManagedAgentsLimitedCredentialNetworkingResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("limited");
    }

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

        this.Type = JsonSerializer.SerializeToElement("limited");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsLimitedCredentialNetworkingResponse(IReadOnlyList<string> allowedHosts)
        : this()
    {
        this.AllowedHosts = allowedHosts;
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
