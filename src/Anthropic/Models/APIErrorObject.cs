using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<APIErrorObject, APIErrorObjectFromRaw>))]
public sealed record class APIErrorObject : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public APIErrorObject()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

    public APIErrorObject(APIErrorObject apiErrorObject)
        : base(apiErrorObject) { }

    public APIErrorObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    APIErrorObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="APIErrorObjectFromRaw.FromRawUnchecked"/>
    public static APIErrorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public APIErrorObject(string message)
        : this()
    {
        this.Message = message;
    }
}

class APIErrorObjectFromRaw : IFromRaw<APIErrorObject>
{
    /// <inheritdoc/>
    public APIErrorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        APIErrorObject.FromRawUnchecked(rawData);
}
