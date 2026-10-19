using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A user profile's standing in each program. A program is a set of capabilities
/// or exemptions that Anthropic approves for the entity the profile represents. A
/// program reads `null` when the profile has no status in it, when the caller's
/// organization is not entitled to read programs, or when the response does not report
/// that program. Retrieving the profile reports every program. Anthropic may add
/// programs; ignore a key you do not recognize.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfilePrograms, UserProfileProgramsFromRaw>))]
public sealed record class UserProfilePrograms : JsonModel
{
    /// <summary>
    /// The profile's standing in the Cyber Verification Program. `null` when the
    /// profile has no status in it. Only retrieving the profile gives the full answer:
    /// a list or update response can show `null`, or a status other than `active`,
    /// for a profile that reads `active` when retrieved.
    /// </summary>
    public required UserProfileCyberProgram? Cyber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileCyberProgram>("cyber");
        }
        init { this._rawData.Set("cyber", value); }
    }

    /// <summary>
    /// The profile's standing in Enterprise Frontier Safeguards. `null` unless the
    /// platform's attestation for the program is in place on this profile, or the
    /// entity it represents has applied to the program. A list of user profiles
    /// does not report this program: there it reads `null` for every profile, so
    /// retrieve the profile to read it.
    /// </summary>
    public required UserProfileEfsProgram? Efs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileEfsProgram>("efs");
        }
        init { this._rawData.Set("efs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cyber?.Validate();
        this.Efs?.Validate();
    }

    public UserProfilePrograms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfilePrograms(UserProfilePrograms userProfilePrograms)
        : base(userProfilePrograms) { }
#pragma warning restore CS8618

    public UserProfilePrograms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfilePrograms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileProgramsFromRaw.FromRawUnchecked"/>
    public static UserProfilePrograms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileProgramsFromRaw : IFromRawJson<UserProfilePrograms>
{
    /// <inheritdoc/>
    public UserProfilePrograms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserProfilePrograms.FromRawUnchecked(rawData);
}
