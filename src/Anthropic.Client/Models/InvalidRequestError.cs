using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models;

[JsonConverter(typeof(ModelConverter<InvalidRequestError>))]
public sealed record class InvalidRequestError : ModelBase, IFromRaw<InvalidRequestError>
{
    public required string Message
    {
        get
        {
            if (!this._properties.TryGetValue("message", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
                );
        }
        init
        {
            this._properties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public InvalidRequestError(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidRequestError(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InvalidRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InvalidRequestError(string message)
        : this()
    {
        this.Message = message;
    }
}
