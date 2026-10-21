using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Token endpoint uses HTTP Basic authentication with client credentials.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthBasicResponse,
        BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicResponse : JsonModel
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("client_secret_basic")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsTokenEndpointAuthBasicResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicResponse(
        BetaManagedAgentsTokenEndpointAuthBasicResponse betaManagedAgentsTokenEndpointAuthBasicResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicResponse.FromRawUnchecked(rawData);
}
