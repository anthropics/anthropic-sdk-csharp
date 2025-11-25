using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchRequestCounts>))]
public sealed record class MessageBatchRequestCounts
    : ModelBase,
        IFromRaw<MessageBatchRequestCounts>
{
    /// <summary>
    /// Number of requests in the Message Batch that have been canceled.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Canceled
    {
        get
        {
            if (!this._rawData.TryGetValue("canceled", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'canceled' cannot be null",
                    new ArgumentOutOfRangeException("canceled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["canceled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Errored
    {
        get
        {
            if (!this._rawData.TryGetValue("errored", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'errored' cannot be null",
                    new ArgumentOutOfRangeException("errored", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["errored"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Expired
    {
        get
        {
            if (!this._rawData.TryGetValue("expired", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expired' cannot be null",
                    new ArgumentOutOfRangeException("expired", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expired"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get
        {
            if (!this._rawData.TryGetValue("processing", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'processing' cannot be null",
                    new ArgumentOutOfRangeException("processing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["processing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Succeeded
    {
        get
        {
            if (!this._rawData.TryGetValue("succeeded", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'succeeded' cannot be null",
                    new ArgumentOutOfRangeException("succeeded", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["succeeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Canceled;
        _ = this.Errored;
        _ = this.Expired;
        _ = this.Processing;
        _ = this.Succeeded;
    }

    public MessageBatchRequestCounts() { }

    public MessageBatchRequestCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchRequestCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
