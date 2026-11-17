using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// Anthropic cannot currently bill the organization linked to the request's user
/// profile, for a reason that lies with that organization's own account. The response
/// does not say what the reason is.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        LinkedOrganizationBillingUnavailableErrorDetails,
        LinkedOrganizationBillingUnavailableErrorDetailsFromRaw
    >)
)]
public sealed record class LinkedOrganizationBillingUnavailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("linked_organization_billing_unavailable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public LinkedOrganizationBillingUnavailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "linked_organization_billing_unavailable"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedOrganizationBillingUnavailableErrorDetails(
        LinkedOrganizationBillingUnavailableErrorDetails linkedOrganizationBillingUnavailableErrorDetails
    )
        : base(linkedOrganizationBillingUnavailableErrorDetails) { }
#pragma warning restore CS8618

    public LinkedOrganizationBillingUnavailableErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "linked_organization_billing_unavailable"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedOrganizationBillingUnavailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedOrganizationBillingUnavailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static LinkedOrganizationBillingUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedOrganizationBillingUnavailableErrorDetailsFromRaw
    : IFromRawJson<LinkedOrganizationBillingUnavailableErrorDetails>
{
    /// <inheritdoc/>
    public LinkedOrganizationBillingUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedOrganizationBillingUnavailableErrorDetails.FromRawUnchecked(rawData);
}
