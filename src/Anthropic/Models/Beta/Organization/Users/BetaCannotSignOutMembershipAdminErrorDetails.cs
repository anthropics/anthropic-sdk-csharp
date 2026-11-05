using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is a membership admin, and the person the API key or token belongs
/// to is not allowed to sign out membership admins.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutMembershipAdminErrorDetails,
        BetaCannotSignOutMembershipAdminErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutMembershipAdminErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_membership_admin")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutMembershipAdminErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_membership_admin");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutMembershipAdminErrorDetails(
        BetaCannotSignOutMembershipAdminErrorDetails betaCannotSignOutMembershipAdminErrorDetails
    )
        : base(betaCannotSignOutMembershipAdminErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutMembershipAdminErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_membership_admin");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutMembershipAdminErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutMembershipAdminErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutMembershipAdminErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutMembershipAdminErrorDetailsFromRaw
    : IFromRawJson<BetaCannotSignOutMembershipAdminErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutMembershipAdminErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutMembershipAdminErrorDetails.FromRawUnchecked(rawData);
}
