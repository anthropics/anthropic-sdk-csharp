using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsReportUserActor, BetaAnalyticsReportUserActorFromRaw>)
)]
public sealed record class BetaAnalyticsReportUserActor : JsonModel
{
    /// <summary>
    /// True when the account has been deleted, or when the user is no longer a member
    /// of the organization or its associated organizations (for example, their membership
    /// was removed or they were deprovisioned via your identity provider). `email_address`
    /// stays populated for removed users and is null when the account has been deleted.
    /// `name` follows the rules described on that field. The `user_id` is still
    /// populated for reconciliation.
    /// </summary>
    public required bool Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("deleted");
        }
        init { this._rawData.Set("deleted", value); }
    }

    /// <summary>
    /// The user's current email address, including for users who are no longer members
    /// of the organization. Null when the account has been deleted and for system-minted
    /// service accounts.
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

    /// <summary>
    /// The user's current full name. Null when the user has not set one. `"Deleted
    /// User"` when the account has been deleted, or when the user is no longer a
    /// member and the organization hides removed users' names.
    /// </summary>
    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Actor type. Always `"user_actor"`.
    /// </summary>
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
    /// Tagged user ID.
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
        _ = this.Deleted;
        _ = this.EmailAddress;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaAnalyticsReportUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsReportUserActor(BetaAnalyticsReportUserActor betaAnalyticsReportUserActor)
        : base(betaAnalyticsReportUserActor) { }
#pragma warning restore CS8618

    public BetaAnalyticsReportUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsReportUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsReportUserActorFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsReportUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsReportUserActorFromRaw : IFromRawJson<BetaAnalyticsReportUserActor>
{
    /// <inheritdoc/>
    public BetaAnalyticsReportUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsReportUserActor.FromRawUnchecked(rawData);
}
