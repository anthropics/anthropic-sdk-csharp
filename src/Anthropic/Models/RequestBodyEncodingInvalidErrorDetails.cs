using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request body is not valid for its `Content-Encoding`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RequestBodyEncodingInvalidErrorDetails,
        RequestBodyEncodingInvalidErrorDetailsFromRaw
    >)
)]
public sealed record class RequestBodyEncodingInvalidErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("request_body_encoding_invalid")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RequestBodyEncodingInvalidErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_encoding_invalid");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestBodyEncodingInvalidErrorDetails(
        RequestBodyEncodingInvalidErrorDetails requestBodyEncodingInvalidErrorDetails
    )
        : base(requestBodyEncodingInvalidErrorDetails) { }
#pragma warning restore CS8618

    public RequestBodyEncodingInvalidErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("request_body_encoding_invalid");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestBodyEncodingInvalidErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestBodyEncodingInvalidErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RequestBodyEncodingInvalidErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestBodyEncodingInvalidErrorDetailsFromRaw
    : IFromRawJson<RequestBodyEncodingInvalidErrorDetails>
{
    /// <inheritdoc/>
    public RequestBodyEncodingInvalidErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestBodyEncodingInvalidErrorDetails.FromRawUnchecked(rawData);
}
