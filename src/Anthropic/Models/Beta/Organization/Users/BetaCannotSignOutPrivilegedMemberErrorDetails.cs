using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// This OAuth token cannot sign out a membership admin or a member whose roles grant
/// owner, user management, or identity and access management.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutPrivilegedMemberErrorDetails,
        BetaCannotSignOutPrivilegedMemberErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutPrivilegedMemberErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_privileged_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutPrivilegedMemberErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_privileged_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutPrivilegedMemberErrorDetails(
        BetaCannotSignOutPrivilegedMemberErrorDetails betaCannotSignOutPrivilegedMemberErrorDetails
    )
        : base(betaCannotSignOutPrivilegedMemberErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutPrivilegedMemberErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_privileged_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutPrivilegedMemberErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutPrivilegedMemberErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutPrivilegedMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutPrivilegedMemberErrorDetailsFromRaw
    : IFromRawJson<BetaCannotSignOutPrivilegedMemberErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutPrivilegedMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutPrivilegedMemberErrorDetails.FromRawUnchecked(rawData);
}
