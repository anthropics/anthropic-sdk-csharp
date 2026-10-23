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
        BetaAnalyticsFederatedActorAwsProvider,
        BetaAnalyticsFederatedActorAwsProviderFromRaw
    >)
)]
public sealed record class BetaAnalyticsFederatedActorAwsProvider : JsonModel
{
    /// <summary>
    /// The AWS account the organization is bound to.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The AWS-signed ARN of the IAM principal that made the requests.
    /// </summary>
    public required string SignedPrincipal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signed_principal");
        }
        init { this._rawData.Set("signed_principal", value); }
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
        _ = this.AccountID;
        _ = this.SignedPrincipal;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("aws")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsFederatedActorAwsProvider()
    {
        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorAwsProvider(
        BetaAnalyticsFederatedActorAwsProvider betaAnalyticsFederatedActorAwsProvider
    )
        : base(betaAnalyticsFederatedActorAwsProvider) { }
#pragma warning restore CS8618

    public BetaAnalyticsFederatedActorAwsProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("aws");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsFederatedActorAwsProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsFederatedActorAwsProviderFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsFederatedActorAwsProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsFederatedActorAwsProviderFromRaw
    : IFromRawJson<BetaAnalyticsFederatedActorAwsProvider>
{
    /// <inheritdoc/>
    public BetaAnalyticsFederatedActorAwsProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsFederatedActorAwsProvider.FromRawUnchecked(rawData);
}
