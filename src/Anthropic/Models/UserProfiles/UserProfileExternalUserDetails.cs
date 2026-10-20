using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// Details about the entity this profile represents, as the platform states them.
/// Anthropic does not verify them. Every field is present, `null` until the platform
/// supplies a value.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileExternalUserDetails,
        UserProfileExternalUserDetailsFromRaw
    >)
)]
public sealed record class UserProfileExternalUserDetails : JsonModel
{
    /// <summary>
    /// The status of the entity's account on the platform: `active`, `suspended`
    /// or `blocked`. `null` until the platform supplies one.
    /// </summary>
    public required ApiEnum<string, UserProfileExternalUserAccountStatus>? AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UserProfileExternalUserAccountStatus>
            >("account_status");
        }
        init { this._rawData.Set("account_status", value); }
    }

    /// <summary>
    /// The country the platform associates with the entity, as an ISO 3166-1 alpha-2
    /// code. `null` until the platform supplies one.
    /// </summary>
    public required string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// The platform-computed hash of the entity's email address. `null` until the
    /// platform supplies one.
    /// </summary>
    public required string? EmailHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_hash");
        }
        init { this._rawData.Set("email_hash", value); }
    }

    /// <summary>
    /// What kind of entity the profile represents: `individual`, `business`, `non_profit`
    /// or `government`. `null` until the platform supplies one.
    /// </summary>
    public required ApiEnum<string, UserProfileExternalUserEntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, UserProfileExternalUserEntityType>
            >("entity_type");
        }
        init { this._rawData.Set("entity_type", value); }
    }

    /// <summary>
    /// The platform-computed hash of the entity's name. `null` until the platform
    /// supplies one.
    /// </summary>
    public required string? NameHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name_hash");
        }
        init { this._rawData.Set("name_hash", value); }
    }

    /// <summary>
    /// When the entity opened its account with the platform, as stated by the platform,
    /// in RFC 3339 format (UTC). `null` until the platform supplies one.
    /// </summary>
    public required DateTimeOffset? OnboardedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("onboarded_at");
        }
        init { this._rawData.Set("onboarded_at", value); }
    }

    /// <summary>
    /// The platform's own reference for the entity. `null` until the platform supplies one.
    /// </summary>
    public required string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccountStatus?.Validate();
        _ = this.Country;
        _ = this.EmailHash;
        this.EntityType?.Validate();
        _ = this.NameHash;
        _ = this.OnboardedAt;
        _ = this.ReferenceID;
    }

    public UserProfileExternalUserDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileExternalUserDetails(
        UserProfileExternalUserDetails userProfileExternalUserDetails
    )
        : base(userProfileExternalUserDetails) { }
#pragma warning restore CS8618

    public UserProfileExternalUserDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileExternalUserDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileExternalUserDetailsFromRaw.FromRawUnchecked"/>
    public static UserProfileExternalUserDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileExternalUserDetailsFromRaw : IFromRawJson<UserProfileExternalUserDetails>
{
    /// <inheritdoc/>
    public UserProfileExternalUserDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileExternalUserDetails.FromRawUnchecked(rawData);
}
