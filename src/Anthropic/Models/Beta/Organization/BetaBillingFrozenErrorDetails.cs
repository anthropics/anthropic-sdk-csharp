using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Anthropic has temporarily disabled billing changes for the user account the credential
/// belongs to. Contact support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBillingFrozenErrorDetails, BetaBillingFrozenErrorDetailsFromRaw>)
)]
public sealed record class BetaBillingFrozenErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("billing_frozen")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBillingFrozenErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("billing_frozen");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBillingFrozenErrorDetails(
        BetaBillingFrozenErrorDetails betaBillingFrozenErrorDetails
    )
        : base(betaBillingFrozenErrorDetails) { }
#pragma warning restore CS8618

    public BetaBillingFrozenErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("billing_frozen");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBillingFrozenErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBillingFrozenErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaBillingFrozenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBillingFrozenErrorDetailsFromRaw : IFromRawJson<BetaBillingFrozenErrorDetails>
{
    /// <inheritdoc/>
    public BetaBillingFrozenErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBillingFrozenErrorDetails.FromRawUnchecked(rawData);
}
