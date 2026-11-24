using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The External Key is held by a key management service that this endpoint does
/// not take. The message names the field and the service it takes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalKeyProviderMismatchErrorDetails,
        BetaExternalKeyProviderMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class BetaExternalKeyProviderMismatchErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_key_provider_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalKeyProviderMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_provider_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalKeyProviderMismatchErrorDetails(
        BetaExternalKeyProviderMismatchErrorDetails betaExternalKeyProviderMismatchErrorDetails
    )
        : base(betaExternalKeyProviderMismatchErrorDetails) { }
#pragma warning restore CS8618

    public BetaExternalKeyProviderMismatchErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_key_provider_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalKeyProviderMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalKeyProviderMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaExternalKeyProviderMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalKeyProviderMismatchErrorDetailsFromRaw
    : IFromRawJson<BetaExternalKeyProviderMismatchErrorDetails>
{
    /// <inheritdoc/>
    public BetaExternalKeyProviderMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalKeyProviderMismatchErrorDetails.FromRawUnchecked(rawData);
}
