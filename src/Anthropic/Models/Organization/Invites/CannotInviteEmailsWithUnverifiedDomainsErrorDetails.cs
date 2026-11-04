using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// The email address's domain is not one of the verified domains of the organization's
/// parent organization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CannotInviteEmailsWithUnverifiedDomainsErrorDetails,
        CannotInviteEmailsWithUnverifiedDomainsErrorDetailsFromRaw
    >)
)]
public sealed record class CannotInviteEmailsWithUnverifiedDomainsErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_invite_emails_with_unverified_domains")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CannotInviteEmailsWithUnverifiedDomainsErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "cannot_invite_emails_with_unverified_domains"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CannotInviteEmailsWithUnverifiedDomainsErrorDetails(
        CannotInviteEmailsWithUnverifiedDomainsErrorDetails cannotInviteEmailsWithUnverifiedDomainsErrorDetails
    )
        : base(cannotInviteEmailsWithUnverifiedDomainsErrorDetails) { }
#pragma warning restore CS8618

    public CannotInviteEmailsWithUnverifiedDomainsErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "cannot_invite_emails_with_unverified_domains"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CannotInviteEmailsWithUnverifiedDomainsErrorDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CannotInviteEmailsWithUnverifiedDomainsErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CannotInviteEmailsWithUnverifiedDomainsErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CannotInviteEmailsWithUnverifiedDomainsErrorDetailsFromRaw
    : IFromRawJson<CannotInviteEmailsWithUnverifiedDomainsErrorDetails>
{
    /// <inheritdoc/>
    public CannotInviteEmailsWithUnverifiedDomainsErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CannotInviteEmailsWithUnverifiedDomainsErrorDetails.FromRawUnchecked(rawData);
}
