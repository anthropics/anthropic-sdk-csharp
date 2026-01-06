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
        get { return JsonModel.GetNotNullClass<ErrorObject>(this.RawData, "error"); }
        init { JsonModel.Set(this._rawData, "error", value); }
    }

    public required string? RequestID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "request_id"); }
        init { JsonModel.Set(this._rawData, "request_id", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        _ = this.RequestID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"error\""))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ErrorResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

    public ErrorResponse(ErrorResponse errorResponse)
        : base(errorResponse) { }

    public ErrorResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
