using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchRequestCounts, MessageBatchRequestCountsFromRaw>))]
public sealed record class MessageBatchRequestCounts : ModelBase
{
    /// <summary>
    /// Number of requests in the Message Batch that have been canceled.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Canceled
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "canceled"); }
        init { ModelBase.Set(this._rawData, "canceled", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Errored
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "errored"); }
        init { ModelBase.Set(this._rawData, "errored", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Expired
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "expired"); }
        init { ModelBase.Set(this._rawData, "expired", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "processing"); }
        init { ModelBase.Set(this._rawData, "processing", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Succeeded
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "succeeded"); }
        init { ModelBase.Set(this._rawData, "succeeded", value); }
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

    /// <inheritdoc cref="MessageBatchRequestCountsFromRaw.FromRawUnchecked"/>
    public static MessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchRequestCountsFromRaw : IFromRaw<MessageBatchRequestCounts>
{
    /// <inheritdoc/>
    public MessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchRequestCounts.FromRawUnchecked(rawData);
}
