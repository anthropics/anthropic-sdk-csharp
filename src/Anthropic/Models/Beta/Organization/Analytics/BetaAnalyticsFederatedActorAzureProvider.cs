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
        BetaAnalyticsFederatedActorAzureProvider,
        BetaAnalyticsFederatedActorAzureProviderFromRaw
    >)
)]
public sealed record class BetaAnalyticsFederatedActorAzureProvider : JsonModel
{
    /// <summary>
    /// The Azure subscription the organization is bound to.
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
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
        _ = this.SubscriptionID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("azure")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsFederatedActorAzureProvider()
    {
        this.Type = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorAzureProvider(
        BetaAnalyticsFederatedActorAzureProvider betaAnalyticsFederatedActorAzureProvider
    )
        : base(betaAnalyticsFederatedActorAzureProvider) { }
#pragma warning restore CS8618

    public BetaAnalyticsFederatedActorAzureProvider(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("azure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsFederatedActorAzureProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsFederatedActorAzureProviderFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsFederatedActorAzureProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorAzureProvider(string subscriptionID)
        : this()
    {
        this.SubscriptionID = subscriptionID;
    }
}

class BetaAnalyticsFederatedActorAzureProviderFromRaw
    : IFromRawJson<BetaAnalyticsFederatedActorAzureProvider>
{
    /// <inheritdoc/>
    public BetaAnalyticsFederatedActorAzureProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsFederatedActorAzureProvider.FromRawUnchecked(rawData);
}
