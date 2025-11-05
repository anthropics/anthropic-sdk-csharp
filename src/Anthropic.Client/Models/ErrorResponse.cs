using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models;

[JsonConverter(typeof(ModelConverter<ErrorResponse>))]
public sealed record class ErrorResponse : ModelBase, IFromRaw<ErrorResponse>
{
    public required ErrorObject Error
    {
        get
        {
            if (!this._properties.TryGetValue("error", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error' cannot be null",
                    new ArgumentOutOfRangeException("error", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ErrorObject>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'error' cannot be null",
                    new ArgumentNullException("error")
                );
        }
        init
        {
            this._properties["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? RequestID
    {
        get
        {
            if (!this._properties.TryGetValue("request_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["request_id"] = JsonSerializer.SerializeToElement(
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
        this.Error.Validate();
        _ = this.RequestID;
        _ = this.Type;
    }

    public ErrorResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

    public ErrorResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ErrorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
