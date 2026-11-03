using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// The organization cannot retrieve, set or delete spend limits with an Admin API credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails,
        BetaSpendLimitsAdminApiWritesNotEnabledErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("spend_limits_admin_api_writes_not_enabled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "spend_limits_admin_api_writes_not_enabled"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails(
        BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails betaSpendLimitsAdminApiWritesNotEnabledErrorDetails
    )
        : base(betaSpendLimitsAdminApiWritesNotEnabledErrorDetails) { }
#pragma warning restore CS8618

    public BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "spend_limits_admin_api_writes_not_enabled"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitsAdminApiWritesNotEnabledErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitsAdminApiWritesNotEnabledErrorDetailsFromRaw
    : IFromRawJson<BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails>
{
    /// <inheritdoc/>
    public BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails.FromRawUnchecked(rawData);
}
