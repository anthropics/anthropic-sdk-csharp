using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(JsonModelConverter<MessageBatch, MessageBatchFromRaw>))]
public sealed record class MessageBatch : JsonModel
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was archived and its results became unavailable.
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "archived_at");
        }
        init { JsonModel.Set(this._rawData, "archived_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which cancellation was initiated
    /// for the Message Batch. Specified only if cancellation was initiated.
    /// </summary>
    public required System::DateTimeOffset? CancelInitiatedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "cancel_initiated_at"
            );
        }
        init { JsonModel.Set(this._rawData, "cancel_initiated_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which processing for the
    /// Message Batch ended. Specified only once processing ends.
    ///
    /// <para>Processing ends when every request in a Message Batch has either succeeded,
    /// errored, canceled, or expired.</para>
    /// </summary>
    public required System::DateTimeOffset? EndedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "ended_at");
        }
        init { JsonModel.Set(this._rawData, "ended_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// will expire and end processing, which is 24 hours after creation.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "expires_at");
        }
        init { JsonModel.Set(this._rawData, "expires_at", value); }
    }

    /// <summary>
    /// Processing status of the Message Batch.
    /// </summary>
    public required ApiEnum<string, ProcessingStatus> ProcessingStatus
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, ProcessingStatus>>(
                this.RawData,
                "processing_status"
            );
        }
        init { JsonModel.Set(this._rawData, "processing_status", value); }
    }

    /// <summary>
    /// Tallies requests within the Message Batch, categorized by their status.
    ///
    /// <para>Requests start as `processing` and move to one of the other statuses
    /// only once processing of the entire batch ends. The sum of all values always
    /// matches the total number of requests in the batch.</para>
    /// </summary>
    public required MessageBatchRequestCounts RequestCounts
    {
        get
        {
            return JsonModel.GetNotNullClass<MessageBatchRequestCounts>(
                this.RawData,
                "request_counts"
            );
        }
        init { JsonModel.Set(this._rawData, "request_counts", value); }
    }

    /// <summary>
    /// URL to a `.jsonl` file containing the results of the Message Batch requests.
    /// Specified only once processing ends.
    ///
    /// <para>Results in the file are not guaranteed to be in the same order as requests.
    /// Use the `custom_id` field to match results to requests.</para>
    /// </summary>
    public required string? ResultsURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "results_url"); }
        init { JsonModel.Set(this._rawData, "results_url", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Message Batches, this is always `"message_batch"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"message_batch\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatch()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");
    }

    public MessageBatch(MessageBatch messageBatch)
        : base(messageBatch) { }

    public MessageBatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchFromRaw.FromRawUnchecked"/>
    public static MessageBatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchFromRaw : IFromRawJson<MessageBatch>
{
    /// <inheritdoc/>
    public MessageBatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageBatch.FromRawUnchecked(rawData);
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
