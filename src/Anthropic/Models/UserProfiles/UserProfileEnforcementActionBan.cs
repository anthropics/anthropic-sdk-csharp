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
/// Anthropic has stopped serving the end user where the ban applies and does not
/// plan to serve them there again.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileEnforcementActionBan,
        UserProfileEnforcementActionBanFromRaw
    >)
)]
public sealed record class UserProfileEnforcementActionBan : JsonModel
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
    /// Always `null`: the end user cannot clear a ban.
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
    /// Always `null`: a ban has no end date.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("ban")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileEnforcementActionBan()
    {
        this.Type = JsonSerializer.SerializeToElement("ban");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileEnforcementActionBan(
        UserProfileEnforcementActionBan userProfileEnforcementActionBan
    )
        : base(userProfileEnforcementActionBan) { }
#pragma warning restore CS8618

    public UserProfileEnforcementActionBan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("ban");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileEnforcementActionBan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileEnforcementActionBanFromRaw.FromRawUnchecked"/>
    public static UserProfileEnforcementActionBan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileEnforcementActionBanFromRaw : IFromRawJson<UserProfileEnforcementActionBan>
{
    /// <inheritdoc/>
    public UserProfileEnforcementActionBan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileEnforcementActionBan.FromRawUnchecked(rawData);
}
