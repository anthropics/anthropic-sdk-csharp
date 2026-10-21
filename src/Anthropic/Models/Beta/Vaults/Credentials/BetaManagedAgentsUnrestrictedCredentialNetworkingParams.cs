using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Substitute the secret on any host the session's Environment network policy permits
/// egress to. The Environment's network policy is the only boundary on where the
/// secret can reach.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams,
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnrestrictedCredentialNetworkingParams : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unrestricted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams()
    {
        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams betaManagedAgentsUnrestrictedCredentialNetworkingParams
    )
        : base(betaManagedAgentsUnrestrictedCredentialNetworkingParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnrestrictedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUnrestrictedCredentialNetworkingParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnrestrictedCredentialNetworkingParams.FromRawUnchecked(rawData);
}
