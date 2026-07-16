using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Tunnels;

/// <summary>
/// A tunnel's connector token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaTunnelToken, BetaTunnelTokenFromRaw>))]
public sealed record class BetaTunnelToken : JsonModel
{
    /// <summary>
    /// Stable identifier for the current token value. Changes when the token is rotated.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The connector token used to run the tunnel. Treat as a credential.
    /// </summary>
    public required string TunnelToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tunnel_token");
        }
        init { this._rawData.Set("tunnel_token", value); }
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
        _ = this.ID;
        _ = this.TunnelToken;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tunnel_token")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTunnelToken()
    {
        this.Type = JsonSerializer.SerializeToElement("tunnel_token");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTunnelToken(BetaTunnelToken betaTunnelToken)
        : base(betaTunnelToken) { }
#pragma warning restore CS8618

    public BetaTunnelToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tunnel_token");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTunnelToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTunnelTokenFromRaw.FromRawUnchecked"/>
    public static BetaTunnelToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTunnelTokenFromRaw : IFromRawJson<BetaTunnelToken>
{
    /// <inheritdoc/>
    public BetaTunnelToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTunnelToken.FromRawUnchecked(rawData);
}
