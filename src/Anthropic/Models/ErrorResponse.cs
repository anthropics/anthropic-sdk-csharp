using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<ErrorResponse, ErrorResponseFromRaw>))]
public sealed record class ErrorResponse : JsonModel
{
    public required ErrorObject Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ErrorObject>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public required string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("request_id");
        }
        init { this._rawData.Set("request_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        _ = this.RequestID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ErrorResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorResponse(ErrorResponse errorResponse)
        : base(errorResponse) { }
#pragma warning restore CS8618

    public ErrorResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorResponseFromRaw.FromRawUnchecked"/>
    public static ErrorResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorResponseFromRaw : IFromRawJson<ErrorResponse>
{
    /// <inheritdoc/>
    public ErrorResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ErrorResponse.FromRawUnchecked(rawData);
}
