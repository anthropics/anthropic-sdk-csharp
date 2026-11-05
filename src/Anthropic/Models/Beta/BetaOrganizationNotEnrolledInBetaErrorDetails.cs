using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The beta that the endpoint requires is not enabled for the organization. The message
/// names the beta value.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationNotEnrolledInBetaErrorDetails,
        BetaOrganizationNotEnrolledInBetaErrorDetailsFromRaw
    >)
)]
public sealed record class BetaOrganizationNotEnrolledInBetaErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("organization_not_enrolled_in_beta")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationNotEnrolledInBetaErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("organization_not_enrolled_in_beta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationNotEnrolledInBetaErrorDetails(
        BetaOrganizationNotEnrolledInBetaErrorDetails betaOrganizationNotEnrolledInBetaErrorDetails
    )
        : base(betaOrganizationNotEnrolledInBetaErrorDetails) { }
#pragma warning restore CS8618

    public BetaOrganizationNotEnrolledInBetaErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("organization_not_enrolled_in_beta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationNotEnrolledInBetaErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationNotEnrolledInBetaErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationNotEnrolledInBetaErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationNotEnrolledInBetaErrorDetailsFromRaw
    : IFromRawJson<BetaOrganizationNotEnrolledInBetaErrorDetails>
{
    /// <inheritdoc/>
    public BetaOrganizationNotEnrolledInBetaErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationNotEnrolledInBetaErrorDetails.FromRawUnchecked(rawData);
}
