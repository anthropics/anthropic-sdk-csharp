using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsUserActor, BetaAnalyticsUserActorFromRaw>))]
public sealed record class BetaAnalyticsUserActor : JsonModel
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
    /// The user's email address, including for users who are no longer members of
    /// the organization or its associated organizations. Null when the account has
    /// been deleted (check `deleted`) and for system-minted service accounts, which
    /// have no person's mailbox behind them (check `name`).
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
    /// The user's full name. Null when the user has not set a name. Returns `"Deleted
    /// User"` when the account itself has been deleted, or when the user is no longer
    /// a member of the organization or its associated organizations and the organization
    /// has chosen to hide the names of removed users. Otherwise, the name stays populated
    /// for removed users. Rows for system-minted service accounts render the service
    /// name (for example, `"Claude Security"` for usage by Anthropic's security-patching
    /// service) or null.
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

    public BetaAnalyticsUserActor()
    {
        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUserActor(BetaAnalyticsUserActor betaAnalyticsUserActor)
        : base(betaAnalyticsUserActor) { }
#pragma warning restore CS8618

    public BetaAnalyticsUserActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUserActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserActorFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserActorFromRaw : IFromRawJson<BetaAnalyticsUserActor>
{
    /// <inheritdoc/>
    public BetaAnalyticsUserActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUserActor.FromRawUnchecked(rawData);
}
