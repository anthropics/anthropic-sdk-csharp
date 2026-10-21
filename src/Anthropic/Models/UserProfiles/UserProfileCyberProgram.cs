using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A user profile's standing in the Cyber Verification Program, which relaxes cyber
/// safeguards for requests that name the profile.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfileCyberProgram, UserProfileCyberProgramFromRaw>))]
public sealed record class UserProfileCyberProgram : JsonModel
{
    /// <summary>
    /// What a request that names the profile must allow to get the relaxed safeguards
    /// of every `active` tier. `null` when no tier is `active`, and wherever `tiers`
    /// is `{}`.
    /// </summary>
    public required UserProfileCyberRequirements? Requirements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileCyberRequirements>("requirements");
        }
        init { this._rawData.Set("requirements", value); }
    }

    /// <summary>
    /// `active` when at least one tier is `active`, or when the profile has the
    /// program's access to earlier models. That access is not a tier: a profile that
    /// has it alone reads `active` with every tier `inactive`, or with `tiers` `{}`
    /// on a response that does not report tiers. When nothing is `active`, `pending`
    /// means that an application or enrollment is under review, or that what Anthropic
    /// approved does not yet apply to this profile, and `rejected` means that the
    /// application or enrollment was declined.
    /// </summary>
    public required ApiEnum<string, UserProfileProgramStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserProfileProgramStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The program's tiers, keyed by tier: `a` (Specialized Access), `b` (Red Team
    /// Access) and `c` (Defense Access). A response reports either every tier or
    /// none. When it reports them, as retrieving the profile normally does, every
    /// tier has a key, whether or not it applies to the profile. When it does not,
    /// as in the list of user profiles, `tiers` is `{}`, which does not mean that
    /// the tiers are inactive. No tier implies another, so read the tier you need.
    /// Anthropic may add tiers; ignore a key you do not recognize.
    /// </summary>
    public required IReadOnlyDictionary<string, UserProfileCyberTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, UserProfileCyberTier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, UserProfileCyberTier>>(
                "tiers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Requirements?.Validate();
        this.Status.Validate();
        foreach (var item in this.Tiers.Values)
        {
            item.Validate();
        }
    }

    public UserProfileCyberProgram() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileCyberProgram(UserProfileCyberProgram userProfileCyberProgram)
        : base(userProfileCyberProgram) { }
#pragma warning restore CS8618

    public UserProfileCyberProgram(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileCyberProgram(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileCyberProgramFromRaw.FromRawUnchecked"/>
    public static UserProfileCyberProgram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileCyberProgramFromRaw : IFromRawJson<UserProfileCyberProgram>
{
    /// <inheritdoc/>
    public UserProfileCyberProgram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileCyberProgram.FromRawUnchecked(rawData);
}
