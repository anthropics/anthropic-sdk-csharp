using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The customer that the request's user profile represents has not authorized the
/// caller to bill them, or the authorization that the request's credential uses
/// has ended. The response does not say which applies.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileBillingNotAuthorizedErrorDetails,
        UserProfileBillingNotAuthorizedErrorDetailsFromRaw
    >)
)]
public sealed record class UserProfileBillingNotAuthorizedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("user_profile_billing_not_authorized")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileBillingNotAuthorizedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_billing_not_authorized");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileBillingNotAuthorizedErrorDetails(
        UserProfileBillingNotAuthorizedErrorDetails userProfileBillingNotAuthorizedErrorDetails
    )
        : base(userProfileBillingNotAuthorizedErrorDetails) { }
#pragma warning restore CS8618

    public UserProfileBillingNotAuthorizedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_billing_not_authorized");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileBillingNotAuthorizedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileBillingNotAuthorizedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static UserProfileBillingNotAuthorizedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileBillingNotAuthorizedErrorDetailsFromRaw
    : IFromRawJson<UserProfileBillingNotAuthorizedErrorDetails>
{
    /// <inheritdoc/>
    public UserProfileBillingNotAuthorizedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileBillingNotAuthorizedErrorDetails.FromRawUnchecked(rawData);
}
