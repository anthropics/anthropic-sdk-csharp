using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.Batches.MessageBatchProperties;

namespace Anthropic.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatch>))]
public sealed record class MessageBatch : ModelBase, IFromRaw<MessageBatch>
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// The format and length of IDs may change over time.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was archived and its results became unavailable.
    /// </summary>
    public required DateTime? ArchivedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["archived_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which cancellation was
    /// initiated for the Message Batch. Specified only if cancellation was initiated.
    /// </summary>
    public required DateTime? CancelInitiatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("cancel_initiated_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cancel_initiated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was created.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which processing for the
    /// Message Batch ended. Specified only once processing ends.
    ///
    /// Processing ends when every request in a Message Batch has either succeeded,
    /// errored, canceled, or expired.
    /// </summary>
    public required DateTime? EndedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("ended_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ended_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// will expire and end processing, which is 24 hours after creation.
    /// </summary>
    public required DateTime ExpiresAt
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expires_at' cannot be null",
                    new ArgumentOutOfRangeException("expires_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Processing status of the Message Batch.
    /// </summary>
    public required ApiEnum<string, ProcessingStatus> ProcessingStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("processing_status", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'processing_status' cannot be null",
                    new ArgumentOutOfRangeException(
                        "processing_status",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["processing_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tallies requests within the Message Batch, categorized by their status.
    ///
    /// Requests start as `processing` and move to one of the other statuses only
    /// once processing of the entire batch ends. The sum of all values always matches
    /// the total number of requests in the batch.
    /// </summary>
    public required MessageBatchRequestCounts RequestCounts
    {
        get
        {
            if (!this.Properties.TryGetValue("request_counts", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'request_counts' cannot be null",
                    new ArgumentOutOfRangeException("request_counts", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageBatchRequestCounts>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'request_counts' cannot be null",
                    new ArgumentNullException("request_counts")
                );
        }
        set
        {
            this.Properties["request_counts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to a `.jsonl` file containing the results of the Message Batch requests.
    /// Specified only once processing ends.
    ///
    /// Results in the file are not guaranteed to be in the same order as requests.
    /// Use the `custom_id` field to match results to requests.
    /// </summary>
    public required string? ResultsURL
    {
        get
        {
            if (!this.Properties.TryGetValue("results_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["results_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Message Batches, this is always `"message_batch"`.
    /// </summary>
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
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CancelInitiatedAt;
        _ = this.CreatedAt;
        _ = this.EndedAt;
        _ = this.ExpiresAt;
        this.ProcessingStatus.Validate();
        this.RequestCounts.Validate();
        _ = this.ResultsURL;
    }

    public MessageBatch()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatch(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatch FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
