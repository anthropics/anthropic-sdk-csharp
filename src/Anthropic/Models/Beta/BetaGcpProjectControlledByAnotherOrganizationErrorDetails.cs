using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// Another organization has data controls turned on for this Google Cloud project,
/// or turned them off recently. The message says how long to wait.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGcpProjectControlledByAnotherOrganizationErrorDetails,
        BetaGcpProjectControlledByAnotherOrganizationErrorDetailsFromRaw
    >)
)]
public sealed record class BetaGcpProjectControlledByAnotherOrganizationErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("gcp_project_controlled_by_another_organization")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGcpProjectControlledByAnotherOrganizationErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "gcp_project_controlled_by_another_organization"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGcpProjectControlledByAnotherOrganizationErrorDetails(
        BetaGcpProjectControlledByAnotherOrganizationErrorDetails betaGcpProjectControlledByAnotherOrganizationErrorDetails
    )
        : base(betaGcpProjectControlledByAnotherOrganizationErrorDetails) { }
#pragma warning restore CS8618

    public BetaGcpProjectControlledByAnotherOrganizationErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "gcp_project_controlled_by_another_organization"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGcpProjectControlledByAnotherOrganizationErrorDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGcpProjectControlledByAnotherOrganizationErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaGcpProjectControlledByAnotherOrganizationErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGcpProjectControlledByAnotherOrganizationErrorDetailsFromRaw
    : IFromRawJson<BetaGcpProjectControlledByAnotherOrganizationErrorDetails>
{
    /// <inheritdoc/>
    public BetaGcpProjectControlledByAnotherOrganizationErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGcpProjectControlledByAnotherOrganizationErrorDetails.FromRawUnchecked(rawData);
}
