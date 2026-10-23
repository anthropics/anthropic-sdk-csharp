using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsFederatedActorOidcProvider,
        BetaAnalyticsFederatedActorOidcProviderFromRaw
    >)
)]
public sealed record class BetaAnalyticsFederatedActorOidcProvider : JsonModel
{
    /// <summary>
    /// The federation issuer's URL.
    /// </summary>
    public required string? Issuer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("issuer");
        }
        init { this._rawData.Set("issuer", value); }
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
        _ = this.Issuer;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("oidc")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsFederatedActorOidcProvider()
    {
        this.Type = JsonSerializer.SerializeToElement("oidc");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorOidcProvider(
        BetaAnalyticsFederatedActorOidcProvider betaAnalyticsFederatedActorOidcProvider
    )
        : base(betaAnalyticsFederatedActorOidcProvider) { }
#pragma warning restore CS8618

    public BetaAnalyticsFederatedActorOidcProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("oidc");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsFederatedActorOidcProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsFederatedActorOidcProviderFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsFederatedActorOidcProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorOidcProvider(string? issuer)
        : this()
    {
        this.Issuer = issuer;
    }
}

class BetaAnalyticsFederatedActorOidcProviderFromRaw
    : IFromRawJson<BetaAnalyticsFederatedActorOidcProvider>
{
    /// <inheritdoc/>
    public BetaAnalyticsFederatedActorOidcProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsFederatedActorOidcProvider.FromRawUnchecked(rawData);
}
