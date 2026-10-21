using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A record of an entity that the platform serves through the API, such as an end-user
/// of the platform's product or a company that the platform resells Claude access to.
///
/// <para>A Messages, Message Batches or token counting request can send a profile's
/// `id` in the `anthropic-user-profile-id` header to attribute the request to that entity.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfile, UserProfileFromRaw>))]
public sealed record class UserProfile : JsonModel
{
    /// <summary>
    /// Unique identifier for this user profile, prefixed `uprof_`.
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
    /// How the platform uses the API for this entity: `application` (default) or
    /// `passthrough`. Absent under the legacy `user-profiles-2026-03-24` beta header.
    /// </summary>
    public required ApiEnum<string, UserProfileAccessType> AccessType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserProfileAccessType>>(
                "access_type"
            );
        }
        init { this._rawData.Set("access_type", value); }
    }

    /// <summary>
    /// When this user profile was created, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The enforcement actions open on this profile; empty when none is open. Absent
    /// under the `user-profiles-2026-09-04` and earlier beta headers.
    /// </summary>
    public required IReadOnlyList<UserProfileEnforcementAction> EnforcementActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserProfileEnforcementAction>>(
                "enforcement_actions"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserProfileEnforcementAction>>(
                "enforcement_actions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Anthropic's enforcement status of this profile, from its open enforcement
    /// actions and any identity check under review, by the first rule that applies:
    /// `banned` while any open action is a `ban`; `pending` while a restriction that
    /// an identity check can clear is open, the end user has submitted that check,
    /// Anthropic's review of it has not ended, and no open action's `reason` is `account_compromise`;
    /// `restricted` while any action is open; `unrestricted` while none is. Absent
    /// under the `user-profiles-2026-09-04` and earlier beta headers.
    /// </summary>
    public required ApiEnum<string, UserProfileEnforcementStatus> EnforcementStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserProfileEnforcementStatus>>(
                "enforcement_status"
            );
        }
        init { this._rawData.Set("enforcement_status", value); }
    }

    /// <summary>
    /// Details about the entity this profile represents, as the platform states them;
    /// not verified by Anthropic. Every field is present, `null` until the platform
    /// supplies a value. Absent under the legacy `user-profiles-2026-03-24` and `user-profiles-2026-08-18`
    /// beta headers, which serve `reference_id` as the top-level `external_id` and,
    /// under `user-profiles-2026-08-18`, `onboarded_at` as `external_user_onboarded_at`.
    /// </summary>
    public required UserProfileExternalUserDetails ExternalUserDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserProfileExternalUserDetails>(
                "external_user_details"
            );
        }
        init { this._rawData.Set("external_user_details", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata. Maximum 16 pairs, keys up to 64 chars, values
    /// up to 512 chars.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Real-world name of the entity this profile represents (company or individual).
    /// For a company the platform resells Claude access to (`access_type` `passthrough`)
    /// this is that company's name. `null` until the platform supplies one.
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
    /// The profile's standing in each Anthropic program, such as the Cyber Verification
    /// Program. Present when the request sends no user-profiles beta header; absent
    /// under the `user-profiles-2026-09-04` and earlier beta headers, which serve
    /// `trust_grants` instead.
    /// </summary>
    public required UserProfilePrograms Programs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserProfilePrograms>("programs");
        }
        init { this._rawData.Set("programs", value); }
    }

    /// <summary>
    /// Object type. Always `user_profile`.
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
    /// When this user profile was last modified, in RFC 3339 format. It normally
    /// also updates shortly after Anthropic gives the profile an approval or withdraws
    /// one. Other changes to the statuses that Anthropic reports do not always update
    /// it, so read the status itself rather than watching this timestamp.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AccessType.Validate();
        _ = this.CreatedAt;
        foreach (var item in this.EnforcementActions)
        {
            item.Validate();
        }
        this.EnforcementStatus.Validate();
        this.ExternalUserDetails.Validate();
        _ = this.Metadata;
        _ = this.Name;
        this.Programs.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_profile")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public UserProfile()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfile(UserProfile userProfile)
        : base(userProfile) { }
#pragma warning restore CS8618

    public UserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileFromRaw.FromRawUnchecked"/>
    public static UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileFromRaw : IFromRawJson<UserProfile>
{
    /// <inheritdoc/>
    public UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserProfile.FromRawUnchecked(rawData);
}
