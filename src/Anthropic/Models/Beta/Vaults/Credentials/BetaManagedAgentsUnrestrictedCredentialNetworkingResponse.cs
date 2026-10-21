using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// The secret is substituted on any host the session's Environment network policy
/// permits egress to.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse,
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnrestrictedCredentialNetworkingResponse : JsonModel
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

    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse betaManagedAgentsUnrestrictedCredentialNetworkingResponse
    )
        : base(betaManagedAgentsUnrestrictedCredentialNetworkingResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unrestricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnrestrictedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw
    : IFromRawJson<BetaManagedAgentsUnrestrictedCredentialNetworkingResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnrestrictedCredentialNetworkingResponse.FromRawUnchecked(rawData);
}
