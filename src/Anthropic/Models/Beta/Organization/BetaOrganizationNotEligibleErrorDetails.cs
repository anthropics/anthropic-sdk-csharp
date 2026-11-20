using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// The feature isn't offered to this organization. The error's `message` names the
/// kind of organization or, when it names none, says to contact your Anthropic account team.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationNotEligibleErrorDetails,
        BetaOrganizationNotEligibleErrorDetailsFromRaw
    >)
)]
public sealed record class BetaOrganizationNotEligibleErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("organization_not_eligible")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationNotEligibleErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("organization_not_eligible");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationNotEligibleErrorDetails(
        BetaOrganizationNotEligibleErrorDetails betaOrganizationNotEligibleErrorDetails
    )
        : base(betaOrganizationNotEligibleErrorDetails) { }
#pragma warning restore CS8618

    public BetaOrganizationNotEligibleErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("organization_not_eligible");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationNotEligibleErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationNotEligibleErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationNotEligibleErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationNotEligibleErrorDetailsFromRaw
    : IFromRawJson<BetaOrganizationNotEligibleErrorDetails>
{
    /// <inheritdoc/>
    public BetaOrganizationNotEligibleErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationNotEligibleErrorDetails.FromRawUnchecked(rawData);
}
