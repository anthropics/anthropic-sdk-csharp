using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// The request depends on a user profile that does not exist in the organization
/// or is no longer active. The request either names this user profile by ID, or names
/// a resource, such as an External Key, that is bound to it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileNotFoundErrorDetails,
        UserProfileNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class UserProfileNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("user_profile_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileNotFoundErrorDetails(
        UserProfileNotFoundErrorDetails userProfileNotFoundErrorDetails
    )
        : base(userProfileNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public UserProfileNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static UserProfileNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileNotFoundErrorDetailsFromRaw : IFromRawJson<UserProfileNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public UserProfileNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileNotFoundErrorDetails.FromRawUnchecked(rawData);
}
