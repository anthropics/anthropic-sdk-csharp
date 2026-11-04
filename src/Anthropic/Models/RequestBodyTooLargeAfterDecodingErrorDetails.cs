using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The compressed request body exceeds the request size limit once decoded.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RequestBodyTooLargeAfterDecodingErrorDetails,
        RequestBodyTooLargeAfterDecodingErrorDetailsFromRaw
    >)
)]
public sealed record class RequestBodyTooLargeAfterDecodingErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("request_body_too_large_after_decoding")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RequestBodyTooLargeAfterDecodingErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_too_large_after_decoding");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestBodyTooLargeAfterDecodingErrorDetails(
        RequestBodyTooLargeAfterDecodingErrorDetails requestBodyTooLargeAfterDecodingErrorDetails
    )
        : base(requestBodyTooLargeAfterDecodingErrorDetails) { }
#pragma warning restore CS8618

    public RequestBodyTooLargeAfterDecodingErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_too_large_after_decoding");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestBodyTooLargeAfterDecodingErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestBodyTooLargeAfterDecodingErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RequestBodyTooLargeAfterDecodingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestBodyTooLargeAfterDecodingErrorDetailsFromRaw
    : IFromRawJson<RequestBodyTooLargeAfterDecodingErrorDetails>
{
    /// <inheritdoc/>
    public RequestBodyTooLargeAfterDecodingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestBodyTooLargeAfterDecodingErrorDetails.FromRawUnchecked(rawData);
}
