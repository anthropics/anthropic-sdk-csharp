using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchErroredResult>))]
public sealed record class MessageBatchErroredResult
    : ModelBase,
        IFromRaw<MessageBatchErroredResult>
{
    public required ErrorResponse Error
    {
        get
        {
            if (!this._properties.TryGetValue("error", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error' cannot be null",
                    new ArgumentOutOfRangeException("error", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ErrorResponse>(element, ModelBase.SerializerOptions)
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
        _ = this.Type;
    }

    public MessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

    public MessageBatchErroredResult(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchErroredResult(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public MessageBatchErroredResult(ErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}
