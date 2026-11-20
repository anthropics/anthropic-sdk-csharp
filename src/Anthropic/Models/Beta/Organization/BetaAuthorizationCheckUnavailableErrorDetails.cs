using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// One of the organization's approvals from Anthropic could not be read right now,
/// so nothing was done. Retry after the `Retry-After` delay.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAuthorizationCheckUnavailableErrorDetails,
        BetaAuthorizationCheckUnavailableErrorDetailsFromRaw
    >)
)]
public sealed record class BetaAuthorizationCheckUnavailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("authorization_check_unavailable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAuthorizationCheckUnavailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("authorization_check_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAuthorizationCheckUnavailableErrorDetails(
        BetaAuthorizationCheckUnavailableErrorDetails betaAuthorizationCheckUnavailableErrorDetails
    )
        : base(betaAuthorizationCheckUnavailableErrorDetails) { }
#pragma warning restore CS8618

    public BetaAuthorizationCheckUnavailableErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("authorization_check_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAuthorizationCheckUnavailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAuthorizationCheckUnavailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaAuthorizationCheckUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAuthorizationCheckUnavailableErrorDetailsFromRaw
    : IFromRawJson<BetaAuthorizationCheckUnavailableErrorDetails>
{
    /// <inheritdoc/>
    public BetaAuthorizationCheckUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAuthorizationCheckUnavailableErrorDetails.FromRawUnchecked(rawData);
}
