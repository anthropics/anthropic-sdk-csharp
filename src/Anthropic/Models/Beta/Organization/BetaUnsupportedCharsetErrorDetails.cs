using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// The request's `Content-Type` header names a charset other than UTF-8, ISO-8859-1
/// or US-ASCII. Send the request with no charset, or with one of these.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaUnsupportedCharsetErrorDetails,
        BetaUnsupportedCharsetErrorDetailsFromRaw
    >)
)]
public sealed record class BetaUnsupportedCharsetErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("unsupported_charset")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaUnsupportedCharsetErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("unsupported_charset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUnsupportedCharsetErrorDetails(
        BetaUnsupportedCharsetErrorDetails betaUnsupportedCharsetErrorDetails
    )
        : base(betaUnsupportedCharsetErrorDetails) { }
#pragma warning restore CS8618

    public BetaUnsupportedCharsetErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("unsupported_charset");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUnsupportedCharsetErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUnsupportedCharsetErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaUnsupportedCharsetErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUnsupportedCharsetErrorDetailsFromRaw : IFromRawJson<BetaUnsupportedCharsetErrorDetails>
{
    /// <inheritdoc/>
    public BetaUnsupportedCharsetErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUnsupportedCharsetErrorDetails.FromRawUnchecked(rawData);
}
