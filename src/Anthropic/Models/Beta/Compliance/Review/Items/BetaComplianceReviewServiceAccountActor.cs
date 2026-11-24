using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// A service account.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceReviewServiceAccountActor,
        BetaComplianceReviewServiceAccountActorFromRaw
    >)
)]
public sealed record class BetaComplianceReviewServiceAccountActor : JsonModel
{
    /// <summary>
    /// The ID of the service account (`svac_...`).
    /// </summary>
    public required string ServiceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_account_id");
        }
        init { this._rawData.Set("service_account_id", value); }
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
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_actor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewServiceAccountActor()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewServiceAccountActor(
        BetaComplianceReviewServiceAccountActor betaComplianceReviewServiceAccountActor
    )
        : base(betaComplianceReviewServiceAccountActor) { }
#pragma warning restore CS8618

    public BetaComplianceReviewServiceAccountActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewServiceAccountActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewServiceAccountActorFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewServiceAccountActor(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class BetaComplianceReviewServiceAccountActorFromRaw
    : IFromRawJson<BetaComplianceReviewServiceAccountActor>
{
    /// <inheritdoc/>
    public BetaComplianceReviewServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewServiceAccountActor.FromRawUnchecked(rawData);
}
