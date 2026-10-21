using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileExternalUserDetailsParams,
        UserProfileExternalUserDetailsParamsFromRaw
    >)
)]
public sealed record class UserProfileExternalUserDetailsParams : JsonModel
{
    /// <summary>
    /// The status of the entity's account on the platform: `active`, `suspended`
    /// or `blocked`.
    /// </summary>
    public ApiEnum<string, UserProfileExternalUserAccountStatus>? AccountStatus
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
    /// The country of the entity (not of the platform), as the platform determines
    /// it: an ISO 3166-1 alpha-2 code in upper case, for example `US`. Only the form,
    /// two uppercase ASCII letters, is checked.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// A hash of the entity's email address, computed by the platform. Anthropic
    /// treats it as an opaque string and does not prescribe the hash function. 1
    /// to 255 characters.
    /// </summary>
    public string? EmailHash
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
    /// or `government`.
    /// </summary>
    public ApiEnum<string, UserProfileExternalUserEntityType>? EntityType
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
    /// A hash of the entity's name, computed by the platform. Anthropic treats it
    /// as an opaque string and does not prescribe the hash function. 1 to 255 characters.
    /// </summary>
    public string? NameHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name_hash");
        }
        init { this._rawData.Set("name_hash", value); }
    }

    /// <summary>
    /// When the entity opened its account with the platform, in RFC 3339 format:
    /// for an `application` profile, when the end-user signed up; for a `passthrough`
    /// profile, when the company became the platform's customer. Must be a complete
    /// timestamp no more than 1 minute in the future.
    /// </summary>
    public DateTimeOffset? OnboardedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("onboarded_at");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("onboarded_at");
                return;
            }

            this._rawData.Set("onboarded_at", value);
        }
    }

    /// <summary>
    /// The platform's own reference for the entity, for example the key of the end-user's
    /// row in the platform's database. Not interpreted by Anthropic and not enforced
    /// unique. 1 to 255 characters.
    /// </summary>
    public string? ReferenceID
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

    public UserProfileExternalUserDetailsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileExternalUserDetailsParams(
        UserProfileExternalUserDetailsParams userProfileExternalUserDetailsParams
    )
        : base(userProfileExternalUserDetailsParams) { }
#pragma warning restore CS8618

    public UserProfileExternalUserDetailsParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileExternalUserDetailsParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileExternalUserDetailsParamsFromRaw.FromRawUnchecked"/>
    public static UserProfileExternalUserDetailsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileExternalUserDetailsParamsFromRaw
    : IFromRawJson<UserProfileExternalUserDetailsParams>
{
    /// <inheritdoc/>
    public UserProfileExternalUserDetailsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileExternalUserDetailsParams.FromRawUnchecked(rawData);
}
