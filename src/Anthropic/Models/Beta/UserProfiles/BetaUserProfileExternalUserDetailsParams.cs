using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaUserProfileExternalUserDetailsParams,
        BetaUserProfileExternalUserDetailsParamsFromRaw
    >)
)]
public sealed record class BetaUserProfileExternalUserDetailsParams : JsonModel
{
    /// <summary>
    /// The status of the entity's account on the platform, as the platform states
    /// it: `active`; `suspended`, when the platform has restricted the account and
    /// may restore it; or `blocked`, when the platform has barred it. It records
    /// the platform's decision only; the statuses in `trust_grants` are Anthropic's
    /// and do not follow it.
    /// </summary>
    public ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>? AccountStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaUserProfileExternalUserDetailsParamsAccountStatus>
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
    /// What kind of entity the profile represents, as the platform states it: `individual`,
    /// `business`, `non_profit` or `government`.
    /// </summary>
    public ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>? EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaUserProfileExternalUserDetailsParamsEntityType>
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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? OnboardedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("onboarded_at");
        }
        init
        {
            if (value == null)
            {
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

    public BetaUserProfileExternalUserDetailsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileExternalUserDetailsParams(
        BetaUserProfileExternalUserDetailsParams betaUserProfileExternalUserDetailsParams
    )
        : base(betaUserProfileExternalUserDetailsParams) { }
#pragma warning restore CS8618

    public BetaUserProfileExternalUserDetailsParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileExternalUserDetailsParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileExternalUserDetailsParamsFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileExternalUserDetailsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileExternalUserDetailsParamsFromRaw
    : IFromRawJson<BetaUserProfileExternalUserDetailsParams>
{
    /// <inheritdoc/>
    public BetaUserProfileExternalUserDetailsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileExternalUserDetailsParams.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the entity's account on the platform, as the platform states it:
/// `active`; `suspended`, when the platform has restricted the account and may restore
/// it; or `blocked`, when the platform has barred it. It records the platform's decision
/// only; the statuses in `trust_grants` are Anthropic's and do not follow it.
/// </summary>
[JsonConverter(typeof(BetaUserProfileExternalUserDetailsParamsAccountStatusConverter))]
public enum BetaUserProfileExternalUserDetailsParamsAccountStatus
{
    Active,
    Suspended,
    Blocked,
}

sealed class BetaUserProfileExternalUserDetailsParamsAccountStatusConverter
    : JsonConverter<BetaUserProfileExternalUserDetailsParamsAccountStatus>
{
    public override BetaUserProfileExternalUserDetailsParamsAccountStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BetaUserProfileExternalUserDetailsParamsAccountStatus.Active,
            "suspended" => BetaUserProfileExternalUserDetailsParamsAccountStatus.Suspended,
            "blocked" => BetaUserProfileExternalUserDetailsParamsAccountStatus.Blocked,
            _ => (BetaUserProfileExternalUserDetailsParamsAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUserProfileExternalUserDetailsParamsAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUserProfileExternalUserDetailsParamsAccountStatus.Active => "active",
                BetaUserProfileExternalUserDetailsParamsAccountStatus.Suspended => "suspended",
                BetaUserProfileExternalUserDetailsParamsAccountStatus.Blocked => "blocked",
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
[JsonConverter(typeof(BetaUserProfileExternalUserDetailsParamsEntityTypeConverter))]
public enum BetaUserProfileExternalUserDetailsParamsEntityType
{
    Individual,
    Business,
    NonProfit,
    Government,
}

sealed class BetaUserProfileExternalUserDetailsParamsEntityTypeConverter
    : JsonConverter<BetaUserProfileExternalUserDetailsParamsEntityType>
{
    public override BetaUserProfileExternalUserDetailsParamsEntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "individual" => BetaUserProfileExternalUserDetailsParamsEntityType.Individual,
            "business" => BetaUserProfileExternalUserDetailsParamsEntityType.Business,
            "non_profit" => BetaUserProfileExternalUserDetailsParamsEntityType.NonProfit,
            "government" => BetaUserProfileExternalUserDetailsParamsEntityType.Government,
            _ => (BetaUserProfileExternalUserDetailsParamsEntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUserProfileExternalUserDetailsParamsEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUserProfileExternalUserDetailsParamsEntityType.Individual => "individual",
                BetaUserProfileExternalUserDetailsParamsEntityType.Business => "business",
                BetaUserProfileExternalUserDetailsParamsEntityType.NonProfit => "non_profit",
                BetaUserProfileExternalUserDetailsParamsEntityType.Government => "government",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
