using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// The organization restricts invites to an allowed list of email domains, and the
/// list is empty or does not include the email address's domain.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EmailDomainNotAllowedErrorDetails,
        EmailDomainNotAllowedErrorDetailsFromRaw
    >)
)]
public sealed record class EmailDomainNotAllowedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("email_domain_not_allowed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public EmailDomainNotAllowedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("email_domain_not_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainNotAllowedErrorDetails(
        EmailDomainNotAllowedErrorDetails emailDomainNotAllowedErrorDetails
    )
        : base(emailDomainNotAllowedErrorDetails) { }
#pragma warning restore CS8618

    public EmailDomainNotAllowedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("email_domain_not_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainNotAllowedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainNotAllowedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static EmailDomainNotAllowedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailDomainNotAllowedErrorDetailsFromRaw : IFromRawJson<EmailDomainNotAllowedErrorDetails>
{
    /// <inheritdoc/>
    public EmailDomainNotAllowedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainNotAllowedErrorDetails.FromRawUnchecked(rawData);
}
