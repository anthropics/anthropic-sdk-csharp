using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The request sets `billing_policy.bill_to` to `"user_profile"` but names no user
/// profile. Name the profile to bill in the `anthropic-user-profile-id` header.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileRequiredErrorDetails,
        UserProfileRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class UserProfileRequiredErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("user_profile_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileRequiredErrorDetails(
        UserProfileRequiredErrorDetails userProfileRequiredErrorDetails
    )
        : base(userProfileRequiredErrorDetails) { }
#pragma warning restore CS8618

    public UserProfileRequiredErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static UserProfileRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileRequiredErrorDetailsFromRaw : IFromRawJson<UserProfileRequiredErrorDetails>
{
    /// <inheritdoc/>
    public UserProfileRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileRequiredErrorDetails.FromRawUnchecked(rawData);
}
