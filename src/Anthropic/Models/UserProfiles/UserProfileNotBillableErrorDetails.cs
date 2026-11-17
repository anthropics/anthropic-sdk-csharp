using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The caller is not allowed to bill the user profile that the request names. The
/// response gives no more specific error code and does not say what the reason is.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileNotBillableErrorDetails,
        UserProfileNotBillableErrorDetailsFromRaw
    >)
)]
public sealed record class UserProfileNotBillableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("user_profile_not_billable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public UserProfileNotBillableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_not_billable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileNotBillableErrorDetails(
        UserProfileNotBillableErrorDetails userProfileNotBillableErrorDetails
    )
        : base(userProfileNotBillableErrorDetails) { }
#pragma warning restore CS8618

    public UserProfileNotBillableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("user_profile_not_billable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileNotBillableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileNotBillableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static UserProfileNotBillableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileNotBillableErrorDetailsFromRaw : IFromRawJson<UserProfileNotBillableErrorDetails>
{
    /// <inheritdoc/>
    public UserProfileNotBillableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileNotBillableErrorDetails.FromRawUnchecked(rawData);
}
