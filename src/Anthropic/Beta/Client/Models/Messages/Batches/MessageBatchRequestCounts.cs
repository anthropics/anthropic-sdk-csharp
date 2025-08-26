using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchRequestCounts>))]
public sealed record class MessageBatchRequestCounts
    : ModelBase,
        IFromRaw<MessageBatchRequestCounts>
{
    /// <summary>
    /// Number of requests in the Message Batch that have been canceled.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Canceled
    {
        get
        {
            if (!this.Properties.TryGetValue("canceled", out JsonElement element))
                throw new ArgumentOutOfRangeException("canceled", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["canceled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Errored
    {
        get
        {
            if (!this.Properties.TryGetValue("errored", out JsonElement element))
                throw new ArgumentOutOfRangeException("errored", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["errored"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Expired
    {
        get
        {
            if (!this.Properties.TryGetValue("expired", out JsonElement element))
                throw new ArgumentOutOfRangeException("expired", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expired"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("processing", out JsonElement element))
                throw new ArgumentOutOfRangeException("processing", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["processing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// This is zero until processing of the entire Message Batch has ended.
    /// </summary>
    public required long Succeeded
    {
        get
        {
            if (!this.Properties.TryGetValue("succeeded", out JsonElement element))
                throw new ArgumentOutOfRangeException("succeeded", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["succeeded"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchRequestCounts(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchRequestCounts FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
