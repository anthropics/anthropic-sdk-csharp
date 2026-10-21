using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// Anthropic has limited how it serves the end user until the action is resolved.
/// The end user may still be served in part.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileEnforcementActionRestriction,
        UserProfileEnforcementActionRestrictionFromRaw
    >)
)]
public sealed record class UserProfileEnforcementActionRestriction : JsonModel
{
    /// <summary>
    /// The action's ID (`enac_...`), stable while the action is open.
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
    /// The next step on the action: `verify` or `null`. `verify`: the end user can
    /// clear it now by passing an identity check. `null`: there is nothing the end
    /// user can do now to clear it, including while Anthropic reviews an identity
    /// check the end user submitted.
    /// </summary>
    public required ApiEnum<string, UserProfileEnforcementActionNextStep>? Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UserProfileEnforcementActionNextStep>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// When the action ends on its own, in RFC 3339 format; it stops showing once
    /// this time has passed. `null` when it has no end date, and always `null` when
    /// `reason` is `account_compromise`.
    /// </summary>
    public required DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// When Anthropic opened the action, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset OpenedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("opened_at");
        }
        init { this._rawData.Set("opened_at", value); }
    }

    /// <summary>
    /// Why Anthropic placed the limit: `unsupported_region`, `fraud_or_abuse`, `high_harm`,
    /// `usage_policy_violation`, `account_compromise` or `unspecified`.
    /// </summary>
    public required ApiEnum<string, UserProfileEnforcementActionReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, UserProfileEnforcementActionReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
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
        this.Action?.Validate();
        _ = this.ExpiresAt;
        _ = this.OpenedAt;
        this.Reason.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("restriction")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileEnforcementActionRestriction()
    {
        this.Type = JsonSerializer.SerializeToElement("restriction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileEnforcementActionRestriction(
        UserProfileEnforcementActionRestriction userProfileEnforcementActionRestriction
    )
        : base(userProfileEnforcementActionRestriction) { }
#pragma warning restore CS8618

    public UserProfileEnforcementActionRestriction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("restriction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileEnforcementActionRestriction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileEnforcementActionRestrictionFromRaw.FromRawUnchecked"/>
    public static UserProfileEnforcementActionRestriction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileEnforcementActionRestrictionFromRaw
    : IFromRawJson<UserProfileEnforcementActionRestriction>
{
    /// <inheritdoc/>
    public UserProfileEnforcementActionRestriction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileEnforcementActionRestriction.FromRawUnchecked(rawData);
}
