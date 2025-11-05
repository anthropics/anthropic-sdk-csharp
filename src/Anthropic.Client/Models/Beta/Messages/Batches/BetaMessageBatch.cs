using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

[JsonConverter(typeof(ModelConverter<BetaMessageBatch>))]
public sealed record class BetaMessageBatch : ModelBase, IFromRaw<BetaMessageBatch>
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
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was archived and its results became unavailable.
    /// </summary>
    public required System::DateTime? ArchivedAt
    {
        get
        {
            if (!this._properties.TryGetValue("archived_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["archived_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which cancellation was
    /// initiated for the Message Batch. Specified only if cancellation was initiated.
    /// </summary>
    public required System::DateTime? CancelInitiatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("cancel_initiated_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cancel_initiated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
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
    public required System::DateTime? EndedAt
    {
        get
        {
            if (!this._properties.TryGetValue("ended_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["ended_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// will expire and end processing, which is 24 hours after creation.
    /// </summary>
    public required System::DateTime ExpiresAt
    {
        get
        {
            if (!this._properties.TryGetValue("expires_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expires_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "expires_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expires_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("processing_status", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'processing_status' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "processing_status",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProcessingStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["processing_status"] = JsonSerializer.SerializeToElement(
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
    public required BetaMessageBatchRequestCounts RequestCounts
    {
        get
        {
            if (!this._properties.TryGetValue("request_counts", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'request_counts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "request_counts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<BetaMessageBatchRequestCounts>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'request_counts' cannot be null",
                    new System::ArgumentNullException("request_counts")
                );
        }
        init
        {
            this._properties["request_counts"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("results_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["results_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CancelInitiatedAt;
        _ = this.CreatedAt;
        _ = this.EndedAt;
        _ = this.ExpiresAt;
        this.ProcessingStatus.Validate();
        this.RequestCounts.Validate();
        _ = this.ResultsURL;
        _ = this.Type;
    }

    public BetaMessageBatch()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");
    }

    public BetaMessageBatch(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatch(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMessageBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Processing status of the Message Batch.
/// </summary>
[JsonConverter(typeof(ProcessingStatusConverter))]
public enum ProcessingStatus
{
    InProgress,
    Canceling,
    Ended,
}

sealed class ProcessingStatusConverter : JsonConverter<ProcessingStatus>
{
    public override ProcessingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => ProcessingStatus.InProgress,
            "canceling" => ProcessingStatus.Canceling,
            "ended" => ProcessingStatus.Ended,
            _ => (ProcessingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingStatus.InProgress => "in_progress",
                ProcessingStatus.Canceling => "canceling",
                ProcessingStatus.Ended => "ended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
