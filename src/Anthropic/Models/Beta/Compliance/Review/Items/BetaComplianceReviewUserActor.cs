using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// A signed-in user.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewUserActor, BetaComplianceReviewUserActorFromRaw>)
)]
public sealed record class BetaComplianceReviewUserActor : JsonModel
{
    /// <summary>
    /// The user's email address. Set only for a current member of an organization
    /// that the API key can read.
    /// </summary>
    public required string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_address");
        }
        init { this._rawData.Set("email_address", value); }
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

    /// <summary>
    /// The ID of the user (`user_...`).
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmailAddress;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaComplianceReviewUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewUserActor(
        BetaComplianceReviewUserActor betaComplianceReviewUserActor
    )
        : base(betaComplianceReviewUserActor) { }
#pragma warning restore CS8618

    public BetaComplianceReviewUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewUserActorFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceReviewUserActorFromRaw : IFromRawJson<BetaComplianceReviewUserActor>
{
    /// <inheritdoc/>
    public BetaComplianceReviewUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewUserActor.FromRawUnchecked(rawData);
}
