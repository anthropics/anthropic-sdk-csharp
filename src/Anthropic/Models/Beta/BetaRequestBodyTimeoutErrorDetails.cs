using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The request body did not finish arriving in time, so nothing was done. Send a
/// smaller body, or send it over a faster connection.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRequestBodyTimeoutErrorDetails,
        BetaRequestBodyTimeoutErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRequestBodyTimeoutErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("request_body_timeout")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRequestBodyTimeoutErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_timeout");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRequestBodyTimeoutErrorDetails(
        BetaRequestBodyTimeoutErrorDetails betaRequestBodyTimeoutErrorDetails
    )
        : base(betaRequestBodyTimeoutErrorDetails) { }
#pragma warning restore CS8618

    public BetaRequestBodyTimeoutErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_timeout");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestBodyTimeoutErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestBodyTimeoutErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRequestBodyTimeoutErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestBodyTimeoutErrorDetailsFromRaw : IFromRawJson<BetaRequestBodyTimeoutErrorDetails>
{
    /// <inheritdoc/>
    public BetaRequestBodyTimeoutErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestBodyTimeoutErrorDetails.FromRawUnchecked(rawData);
}
