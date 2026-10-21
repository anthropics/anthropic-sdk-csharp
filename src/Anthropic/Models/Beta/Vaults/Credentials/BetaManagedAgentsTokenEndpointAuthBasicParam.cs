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
        BetaManagedAgentsTokenEndpointAuthBasicParam,
        BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicParam : JsonModel
{
    /// <summary>
    /// The OAuth client secret, sent to `token_endpoint` with HTTP Basic authentication.
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
                JsonSerializer.SerializeToElement("client_secret_basic")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsTokenEndpointAuthBasicParam()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicParam(
        BetaManagedAgentsTokenEndpointAuthBasicParam betaManagedAgentsTokenEndpointAuthBasicParam
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicParam(string clientSecret)
        : this()
    {
        this.ClientSecret = clientSecret;
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicParam.FromRawUnchecked(rawData);
}
