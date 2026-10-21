using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Token endpoint uses POST body authentication with client credentials.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthPostResponse,
        BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostResponse : JsonModel
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
                JsonSerializer.SerializeToElement("client_secret_post")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsTokenEndpointAuthPostResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostResponse(
        BetaManagedAgentsTokenEndpointAuthPostResponse betaManagedAgentsTokenEndpointAuthPostResponse
    )
        : base(betaManagedAgentsTokenEndpointAuthPostResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthPostResponseFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostResponse.FromRawUnchecked(rawData);
}
