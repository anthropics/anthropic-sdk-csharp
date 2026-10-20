using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// What a request that names the profile must allow to get the relaxed safeguards
/// of the profile's `active` tiers. A field reads `true` when at least one of those
/// tiers has the requirement and Anthropic has not waived it on that tier for the
/// profile. A request that does not meet a requirement is still served, without the
/// relaxed safeguards of the tiers that have it. The values differ between profiles
/// and can change, so read them rather than assuming them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserProfileCyberRequirements, UserProfileCyberRequirementsFromRaw>)
)]
public sealed record class UserProfileCyberRequirements : JsonModel
{
    /// <summary>
    /// Whether Anthropic must be able to retain the request's inference data.
    /// </summary>
    public required bool DataRetention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("data_retention");
        }
        init { this._rawData.Set("data_retention", value); }
    }

    /// <summary>
    /// Whether Anthropic personnel must be allowed to review the data retained from
    /// the request.
    /// </summary>
    public required bool HumanReview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("human_review");
        }
        init { this._rawData.Set("human_review", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DataRetention;
        _ = this.HumanReview;
    }

    public UserProfileCyberRequirements() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileCyberRequirements(UserProfileCyberRequirements userProfileCyberRequirements)
        : base(userProfileCyberRequirements) { }
#pragma warning restore CS8618

    public UserProfileCyberRequirements(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileCyberRequirements(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileCyberRequirementsFromRaw.FromRawUnchecked"/>
    public static UserProfileCyberRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileCyberRequirementsFromRaw : IFromRawJson<UserProfileCyberRequirements>
{
    /// <inheritdoc/>
    public UserProfileCyberRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileCyberRequirements.FromRawUnchecked(rawData);
}
