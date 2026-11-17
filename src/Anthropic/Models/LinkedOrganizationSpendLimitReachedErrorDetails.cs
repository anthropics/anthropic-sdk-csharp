using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The organization linked to the request's user profile has reached a spend limit
/// that it set, or lacks credit for the request. The response does not say which applies.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        LinkedOrganizationSpendLimitReachedErrorDetails,
        LinkedOrganizationSpendLimitReachedErrorDetailsFromRaw
    >)
)]
public sealed record class LinkedOrganizationSpendLimitReachedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("linked_organization_spend_limit_reached")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public LinkedOrganizationSpendLimitReachedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "linked_organization_spend_limit_reached"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkedOrganizationSpendLimitReachedErrorDetails(
        LinkedOrganizationSpendLimitReachedErrorDetails linkedOrganizationSpendLimitReachedErrorDetails
    )
        : base(linkedOrganizationSpendLimitReachedErrorDetails) { }
#pragma warning restore CS8618

    public LinkedOrganizationSpendLimitReachedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "linked_organization_spend_limit_reached"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedOrganizationSpendLimitReachedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedOrganizationSpendLimitReachedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static LinkedOrganizationSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedOrganizationSpendLimitReachedErrorDetailsFromRaw
    : IFromRawJson<LinkedOrganizationSpendLimitReachedErrorDetails>
{
    /// <inheritdoc/>
    public LinkedOrganizationSpendLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkedOrganizationSpendLimitReachedErrorDetails.FromRawUnchecked(rawData);
}
