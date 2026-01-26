using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<MessageBatchRequestCounts, MessageBatchRequestCountsFromRaw>)
)]
public sealed record class MessageBatchRequestCounts : JsonModel
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("canceled");
        }
        init { this._rawData.Set("canceled", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("errored");
        }
        init { this._rawData.Set("errored", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expired");
        }
        init { this._rawData.Set("expired", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("processing");
        }
        init { this._rawData.Set("processing", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("succeeded");
        }
        init { this._rawData.Set("succeeded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Canceled;
        _ = this.Errored;
        _ = this.Expired;
        _ = this.Processing;
        _ = this.Succeeded;
    }

    public MessageBatchRequestCounts() { }

    public MessageBatchRequestCounts(MessageBatchRequestCounts messageBatchRequestCounts)
        : base(messageBatchRequestCounts) { }

    public MessageBatchRequestCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchRequestCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchRequestCountsFromRaw.FromRawUnchecked"/>
    public static MessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchRequestCountsFromRaw : IFromRawJson<MessageBatchRequestCounts>
{
    /// <inheritdoc/>
    public MessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchRequestCounts.FromRawUnchecked(rawData);
}
