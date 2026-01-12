using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<ApiErrorObject, ApiErrorObjectFromRaw>))]
public sealed record class ApiErrorObject : JsonModel
{
    public required string Message
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "message"); }
        init { JsonModel.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"api_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ApiErrorObject()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

    public ApiErrorObject(ApiErrorObject apiErrorObject)
        : base(apiErrorObject) { }

    public ApiErrorObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiErrorObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiErrorObjectFromRaw.FromRawUnchecked"/>
    public static ApiErrorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiErrorObject(string message)
        : this()
    {
        this.Message = message;
    }
}

class ApiErrorObjectFromRaw : IFromRawJson<ApiErrorObject>
{
    /// <inheritdoc/>
    public ApiErrorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiErrorObject.FromRawUnchecked(rawData);
}
