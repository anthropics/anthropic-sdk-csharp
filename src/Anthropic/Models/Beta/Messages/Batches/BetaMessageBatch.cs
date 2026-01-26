using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(typeof(JsonModelConverter<BetaMessageBatch, BetaMessageBatchFromRaw>))]
public sealed record class BetaMessageBatch : JsonModel
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was archived and its results became unavailable.
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which cancellation was initiated
    /// for the Message Batch. Specified only if cancellation was initiated.
    /// </summary>
    public required System::DateTimeOffset? CancelInitiatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("cancel_initiated_at");
        }
        init { this._rawData.Set("cancel_initiated_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("ended_at");
        }
        init { this._rawData.Set("ended_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing the time at which the Message Batch
    /// will expire and end processing, which is 24 hours after creation.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Processing status of the Message Batch.
    /// </summary>
    public required ApiEnum<string, ProcessingStatus> ProcessingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProcessingStatus>>(
                "processing_status"
            );
        }
        init { this._rawData.Set("processing_status", value); }
    }

    /// <summary>
    /// Tallies requests within the Message Batch, categorized by their status.
    ///
    /// <para>Requests start as `processing` and move to one of the other statuses
    /// only once processing of the entire batch ends. The sum of all values always
    /// matches the total number of requests in the batch.</para>
    /// </summary>
    public required BetaMessageBatchRequestCounts RequestCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaMessageBatchRequestCounts>("request_counts");
        }
        init { this._rawData.Set("request_counts", value); }
    }

    /// <summary>
    /// URL to a `.jsonl` file containing the results of the Message Batch requests.
    /// Specified only once processing ends.
    ///
    /// <para>Results in the file are not guaranteed to be in the same order as requests.
    /// Use the `custom_id` field to match results to requests.</para>
    /// </summary>
    public required string? ResultsUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("results_url");
        }
        init { this._rawData.Set("results_url", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Message Batches, this is always `"message_batch"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
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
        _ = this.ResultsUrl;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("message_batch")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatch()
    {
        this.Type = JsonSerializer.SerializeToElement("message_batch");
    }

    public BetaMessageBatch(BetaMessageBatch betaMessageBatch)
        : base(betaMessageBatch) { }

    public BetaMessageBatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_batch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchFromRaw : IFromRawJson<BetaMessageBatch>
{
    /// <inheritdoc/>
    public BetaMessageBatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMessageBatch.FromRawUnchecked(rawData);
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
