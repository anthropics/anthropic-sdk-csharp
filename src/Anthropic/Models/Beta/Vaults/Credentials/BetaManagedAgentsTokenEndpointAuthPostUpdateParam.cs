using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Updated POST body authentication parameters for the token endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam,
        BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthPostUpdateParam : JsonModel
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

    /// <summary>
    /// A new OAuth client secret to replace the stored one.
    ///
    /// <para>The credential must already use `client_secret_basic` or `client_secret_post`.
    /// It keeps its current `token_endpoint_auth` type, even if the `type` sent with
    /// this secret is the other one.</para>
    /// </summary>
    public string? ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("client_secret");
        }
        init { this._rawData.Set("client_secret", value); }
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
        _ = this.ClientSecret;
    }

    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam betaManagedAgentsTokenEndpointAuthPostUpdateParam
    )
        : base(betaManagedAgentsTokenEndpointAuthPostUpdateParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_post");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthPostUpdateParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthPostUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthPostUpdateParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthPostUpdateParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthPostUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthPostUpdateParam.FromRawUnchecked(rawData);
}
