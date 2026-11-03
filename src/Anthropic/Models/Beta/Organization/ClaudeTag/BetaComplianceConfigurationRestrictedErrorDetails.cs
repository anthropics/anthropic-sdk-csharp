using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The organization's compliance configuration does not let Claude Tag store anything new.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaComplianceConfigurationRestrictedErrorDetails,
        BetaComplianceConfigurationRestrictedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaComplianceConfigurationRestrictedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compliance_configuration_restricted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceConfigurationRestrictedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compliance_configuration_restricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceConfigurationRestrictedErrorDetails(
        BetaComplianceConfigurationRestrictedErrorDetails betaComplianceConfigurationRestrictedErrorDetails
    )
        : base(betaComplianceConfigurationRestrictedErrorDetails) { }
#pragma warning restore CS8618

    public BetaComplianceConfigurationRestrictedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compliance_configuration_restricted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceConfigurationRestrictedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceConfigurationRestrictedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaComplianceConfigurationRestrictedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComplianceConfigurationRestrictedErrorDetailsFromRaw
    : IFromRawJson<BetaComplianceConfigurationRestrictedErrorDetails>
{
    /// <inheritdoc/>
    public BetaComplianceConfigurationRestrictedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceConfigurationRestrictedErrorDetails.FromRawUnchecked(rawData);
}
