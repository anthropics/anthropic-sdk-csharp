using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<InvalidRequestError, InvalidRequestErrorFromRaw>))]
public sealed record class InvalidRequestError : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("invalid_request_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InvalidRequestError()
    {
        this.Type = JsonSerializer.SerializeToElement("invalid_request_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvalidRequestError(InvalidRequestError invalidRequestError)
        : base(invalidRequestError) { }
#pragma warning restore CS8618

    public InvalidRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invalid_request_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class InvalidRequestErrorFromRaw : IFromRawJson<InvalidRequestError>
{
    /// <inheritdoc/>
    public InvalidRequestError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvalidRequestError.FromRawUnchecked(rawData);
}
