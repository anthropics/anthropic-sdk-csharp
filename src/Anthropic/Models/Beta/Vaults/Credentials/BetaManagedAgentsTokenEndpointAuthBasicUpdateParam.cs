using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Updated HTTP Basic authentication parameters for the token endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam,
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTokenEndpointAuthBasicUpdateParam : JsonModel
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
                JsonSerializer.SerializeToElement("client_secret_basic")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ClientSecret;
    }

    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
    {
        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam betaManagedAgentsTokenEndpointAuthBasicUpdateParam
    )
        : base(betaManagedAgentsTokenEndpointAuthBasicUpdateParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_secret_basic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTokenEndpointAuthBasicUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsTokenEndpointAuthBasicUpdateParamFromRaw
    : IFromRawJson<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTokenEndpointAuthBasicUpdateParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTokenEndpointAuthBasicUpdateParam.FromRawUnchecked(rawData);
}
