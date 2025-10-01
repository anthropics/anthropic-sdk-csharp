using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.Batches;

/// <summary>
/// This is a single line in the response `.jsonl` file and does not represent the
/// response as a whole.
/// </summary>
[JsonConverter(typeof(ModelConverter<MessageBatchIndividualResponse>))]
public sealed record class MessageBatchIndividualResponse
    : ModelBase,
        IFromRaw<MessageBatchIndividualResponse>
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// Must be unique for each request within the Message Batch.
    /// </summary>
    public required string CustomID
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new ArgumentOutOfRangeException("custom_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new ArgumentNullException("custom_id")
                );
        }
        set
        {
            this.Properties["custom_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Processing result for this request.
    ///
    /// Contains a Message output if processing was successful, an error response
    /// if processing failed, or the reason why processing was not attempted, such
    /// as cancellation or expiration.
    /// </summary>
    public required MessageBatchResult Result
    {
        get
        {
            if (!this.Properties.TryGetValue("result", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'result' cannot be null",
                    new ArgumentOutOfRangeException("result", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageBatchResult>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'result' cannot be null",
                    new ArgumentNullException("result")
                );
        }
        set
        {
            this.Properties["result"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CustomID;
        this.Result.Validate();
    }

    public MessageBatchIndividualResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchIndividualResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchIndividualResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
