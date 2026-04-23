using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
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
    public required ApiEnum<string, global::Anthropic.Models.Beta.UserProfiles.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.UserProfiles.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Platform's own identifier for this user. Not enforced unique.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Metadata;
        foreach (var item in this.TrustGrants.Values)
        {
            item.Validate();
        }
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.ExternalID;
    }

    public BetaUserProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfile(BetaUserProfile betaUserProfile)
        : base(betaUserProfile) { }
#pragma warning restore CS8618

    public BetaUserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
/// Object type. Always `user_profile`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    UserProfile,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.UserProfiles.Type>
{
    public override global::Anthropic.Models.Beta.UserProfiles.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_profile" => global::Anthropic.Models.Beta.UserProfiles.Type.UserProfile,
            _ => (global::Anthropic.Models.Beta.UserProfiles.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.UserProfiles.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.UserProfiles.Type.UserProfile => "user_profile",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
