using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

/// <summary>
/// Details about the entity this profile represents, as the platform states them.
/// Anthropic does not verify them. Every field is present, `null` until the platform
/// supplies a value.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaUserProfileExternalUserDetails,
        BetaUserProfileExternalUserDetailsFromRaw
    >)
)]
public sealed record class BetaUserProfileExternalUserDetails : JsonModel
{
    /// <summary>
    /// The status of the entity's account on the platform, as the platform states
    /// it: `active`; `suspended`, when the platform has restricted the account and
    /// may restore it; or `blocked`, when the platform has barred it. It records
    /// the platform's decision only; the statuses in `trust_grants` are Anthropic's
    /// and do not follow it.
    /// </summary>
    public required ApiEnum<string, AccountStatus>? AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccountStatus>>("account_status");
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
    /// What kind of entity the profile represents, as the platform states it: `individual`,
    /// `business`, `non_profit` or `government`.
    /// </summary>
    public required ApiEnum<string, EntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntityType>>("entity_type");
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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? OnboardedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("onboarded_at");
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

    public BetaUserProfileExternalUserDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileExternalUserDetails(
        BetaUserProfileExternalUserDetails betaUserProfileExternalUserDetails
    )
        : base(betaUserProfileExternalUserDetails) { }
#pragma warning restore CS8618

    public BetaUserProfileExternalUserDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileExternalUserDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileExternalUserDetailsFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileExternalUserDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileExternalUserDetailsFromRaw : IFromRawJson<BetaUserProfileExternalUserDetails>
{
    /// <inheritdoc/>
    public BetaUserProfileExternalUserDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileExternalUserDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the entity's account on the platform, as the platform states it:
/// `active`; `suspended`, when the platform has restricted the account and may restore
/// it; or `blocked`, when the platform has barred it. It records the platform's decision
/// only; the statuses in `trust_grants` are Anthropic's and do not follow it.
/// </summary>
[JsonConverter(typeof(AccountStatusConverter))]
public enum AccountStatus
{
    Active,
    Suspended,
    Blocked,
}

sealed class AccountStatusConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountStatus.Active,
            "suspended" => AccountStatus.Suspended,
            "blocked" => AccountStatus.Blocked,
            _ => (AccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountStatus.Active => "active",
                AccountStatus.Suspended => "suspended",
                AccountStatus.Blocked => "blocked",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// What kind of entity the profile represents, as the platform states it: `individual`,
/// `business`, `non_profit` or `government`.
/// </summary>
[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    Individual,
    Business,
    NonProfit,
    Government,
}

sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => EntityType.Individual,
            "business" => EntityType.Business,
            "non_profit" => EntityType.NonProfit,
            "government" => EntityType.Government,
            _ => (EntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityType.Individual => "individual",
                EntityType.Business => "business",
                EntityType.NonProfit => "non_profit",
                EntityType.Government => "government",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
