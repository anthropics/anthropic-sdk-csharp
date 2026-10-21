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
        BetaManagedAgentsTokenEndpointAuthPostParam,
        BetaManagedAgentsTokenEndpointAuthPostParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostParam : JsonModel
{
    /// <summary>
    /// The OAuth client secret, sent to `token_endpoint` in the POST body.
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
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
        _ = this.ClientSecret;
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

    public BetaManagedAgentsTokenEndpointAuthPostParam()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostParam(
        BetaManagedAgentsTokenEndpointAuthPostParam betaManagedAgentsTokenEndpointAuthPostParam
    )
        : base(betaManagedAgentsTokenEndpointAuthPostParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostParam(string clientSecret)
        : this()
    {
        this.ClientSecret = clientSecret;
    }
}

class BetaManagedAgentsTokenEndpointAuthPostParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostParam.FromRawUnchecked(rawData);
}
