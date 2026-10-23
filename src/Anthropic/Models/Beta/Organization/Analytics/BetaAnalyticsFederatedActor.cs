using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsFederatedActor, BetaAnalyticsFederatedActorFromRaw>)
)]
public sealed record class BetaAnalyticsFederatedActor : JsonModel
{
    /// <summary>
    /// The trusted provider that asserted the caller's identity.
    /// </summary>
    public required BetaAnalyticsFederatedActorProvider Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsFederatedActorProvider>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// The provider's identifier for the caller: on `aws`, the IAM principal ARN
    /// (one role is one actor across its sessions); on `gcp`, the caller's IAM principal
    /// identifier as Google Cloud reports it, such as `serviceAccount:&lt;email&gt;`,
    /// `user:&lt;email&gt;`, or a `principal://...` URI.
    /// </summary>
    public required string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
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
        this.Provider.Validate();
        _ = this.Subject;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("federated_actor"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsFederatedActor()
    {
        this.Type = JsonSerializer.SerializeToElement("federated_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActor(BetaAnalyticsFederatedActor betaAnalyticsFederatedActor)
        : base(betaAnalyticsFederatedActor) { }
#pragma warning restore CS8618

    public BetaAnalyticsFederatedActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("federated_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsFederatedActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsFederatedActorFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsFederatedActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsFederatedActorFromRaw : IFromRawJson<BetaAnalyticsFederatedActor>
{
    /// <inheritdoc/>
    public BetaAnalyticsFederatedActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsFederatedActor.FromRawUnchecked(rawData);
}
