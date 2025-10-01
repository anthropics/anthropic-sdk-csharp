using System;
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
            if (!this.Properties.TryGetValue("error", out JsonElement element))
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
        set
        {
            this.Properties["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Error.Validate();
    }

    public BetaMessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchErroredResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchErroredResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaMessageBatchErroredResult(BetaErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}
