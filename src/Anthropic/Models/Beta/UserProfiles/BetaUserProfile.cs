using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles;

/// <summary>
/// A record of an entity that the platform serves through the API, such as an end-user
/// of the platform's product or a company that the platform resells Claude access to.
///
/// <para>A Messages, Message Batches or token counting request can send a profile's
/// `id` in the `anthropic-user-profile-id` header to attribute the request to that entity.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaUserProfile, BetaUserProfileFromRaw>))]
public sealed record class BetaUserProfile : JsonModel
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
    /// Trust grants for this profile, keyed by grant name. Key omitted when no grant
    /// is active or in flight.
    /// </summary>
    public required IReadOnlyDictionary<string, BetaUserProfileTrustGrant> TrustGrants
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                FrozenDictionary<string, BetaUserProfileTrustGrant>
            >("trust_grants");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, BetaUserProfileTrustGrant>>(
                "trust_grants",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    /// <summary>
    /// How the platform uses the API for this entity: `application` (default) or
    /// `passthrough`. Absent under the legacy `user-profiles-2026-03-24` beta header.
    /// </summary>
    public ApiEnum<string, BetaUserProfileAccessType>? AccessType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaUserProfileAccessType>>(
                "access_type"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("access_type");
                return;
            }

            this._rawData.Set("access_type", value);
        }
    }

    /// <summary>
    /// Platform's own identifier for this user. Not enforced unique. Legacy field,
    /// present only under the `user-profiles-2026-03-24` and `user-profiles-2026-08-18`
    /// beta headers; without one of them, the value is `external_user_details.reference_id`.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// Details about the entity this profile represents, as the platform states them;
    /// not verified by Anthropic. Every field is present, `null` until the platform
    /// supplies a value. Absent under the legacy `user-profiles-2026-03-24` and `user-profiles-2026-08-18`
    /// beta headers, which serve `reference_id` as the top-level `external_id` and,
    /// under `user-profiles-2026-08-18`, `onboarded_at` as `external_user_onboarded_at`.
    /// </summary>
    public BetaUserProfileExternalUserDetails? ExternalUserDetails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaUserProfileExternalUserDetails>(
                "external_user_details"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("external_user_details");
                return;
            }

            this._rawData.Set("external_user_details", value);
        }
    }

    /// <summary>
    /// When the entity this profile represents opened its account with the platform,
    /// as stated by the platform, in RFC 3339 format (UTC). `null` until the platform
    /// supplies one. Legacy field, present only under the `user-profiles-2026-08-18`
    /// beta header; without a legacy header, the value is `external_user_details.onboarded_at`.
    /// </summary>
    public DateTimeOffset? ExternalUserOnboardedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("external_user_onboarded_at");
        }
        init { this._rawData.Set("external_user_onboarded_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Name;
        foreach (var item in this.TrustGrants.Values)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user_profile")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        this.AccessType?.Validate();
        _ = this.ExternalID;
        this.ExternalUserDetails?.Validate();
        _ = this.ExternalUserOnboardedAt;
    }

    public BetaUserProfile()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfile(BetaUserProfile betaUserProfile)
        : base(betaUserProfile) { }
#pragma warning restore CS8618

    public BetaUserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileFromRaw.FromRawUnchecked"/>
    public static BetaUserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileFromRaw : IFromRawJson<BetaUserProfile>
{
    /// <inheritdoc/>
    public BetaUserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaUserProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// How the platform uses the API for this entity: `application` (default) or `passthrough`.
/// Absent under the legacy `user-profiles-2026-03-24` beta header.
/// </summary>
[JsonConverter(typeof(BetaUserProfileAccessTypeConverter))]
public enum BetaUserProfileAccessType
{
    /// <summary>
    /// The user profile represents an individual end-user of a product that the
    /// platform builds on the API. New profiles get this value by default.
    /// </summary>
    Application,

    /// <summary>
    /// The user profile represents a company that the platform resells Claude access to.
    /// </summary>
    Passthrough,
}

sealed class BetaUserProfileAccessTypeConverter : JsonConverter<BetaUserProfileAccessType>
{
    public override BetaUserProfileAccessType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "application" => BetaUserProfileAccessType.Application,
            "passthrough" => BetaUserProfileAccessType.Passthrough,
            _ => (BetaUserProfileAccessType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUserProfileAccessType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUserProfileAccessType.Application => "application",
                BetaUserProfileAccessType.Passthrough => "passthrough",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
