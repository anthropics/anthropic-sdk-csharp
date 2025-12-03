using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<InvalidRequestError, InvalidRequestErrorFromRaw>))]
public sealed record class InvalidRequestError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InvalidRequestError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

    public InvalidRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvalidRequestErrorFromRaw.FromRawUnchecked"/>
    public static InvalidRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvalidRequestError(string message)
        : this()
    {
        this.Message = message;
    }
}

class InvalidRequestErrorFromRaw : IFromRaw<InvalidRequestError>
{
    /// <inheritdoc/>
    public InvalidRequestError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvalidRequestError.FromRawUnchecked(rawData);
}
