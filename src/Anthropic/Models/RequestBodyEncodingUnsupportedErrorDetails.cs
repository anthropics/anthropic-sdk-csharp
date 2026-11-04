using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's `Content-Encoding` is not supported.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RequestBodyEncodingUnsupportedErrorDetails,
        RequestBodyEncodingUnsupportedErrorDetailsFromRaw
    >)
)]
public sealed record class RequestBodyEncodingUnsupportedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("request_body_encoding_unsupported")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RequestBodyEncodingUnsupportedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_encoding_unsupported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestBodyEncodingUnsupportedErrorDetails(
        RequestBodyEncodingUnsupportedErrorDetails requestBodyEncodingUnsupportedErrorDetails
    )
        : base(requestBodyEncodingUnsupportedErrorDetails) { }
#pragma warning restore CS8618

    public RequestBodyEncodingUnsupportedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_encoding_unsupported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestBodyEncodingUnsupportedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestBodyEncodingUnsupportedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RequestBodyEncodingUnsupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestBodyEncodingUnsupportedErrorDetailsFromRaw
    : IFromRawJson<RequestBodyEncodingUnsupportedErrorDetails>
{
    /// <inheritdoc/>
    public RequestBodyEncodingUnsupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestBodyEncodingUnsupportedErrorDetails.FromRawUnchecked(rawData);
}
