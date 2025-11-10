using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

[JsonConverter(typeof(ModelConverter<BetaMessageBatchErroredResult>))]
public sealed record class BetaMessageBatchErroredResult
    : ModelBase,
        IFromRaw<BetaMessageBatchErroredResult>
{
    public required BetaErrorResponse Error
    {
        get
        {
            if (!this._properties.TryGetValue("error", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error' cannot be null",
                    new ArgumentOutOfRangeException("error", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaErrorResponse>(
                    element,
                    ModelBase.SerializerOptions
                )
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"errored\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

    public BetaMessageBatchErroredResult(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchErroredResult(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaMessageBatchErroredResult(BetaErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}
