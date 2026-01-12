using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<BetaMessageBatchRequestCounts, BetaMessageBatchRequestCountsFromRaw>)
)]
public sealed record class BetaMessageBatchRequestCounts : JsonModel
{
    /// <summary>
    /// Number of requests in the Message Batch that have been canceled.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Canceled
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "canceled"); }
        init { JsonModel.Set(this._rawData, "canceled", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Errored
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "errored"); }
        init { JsonModel.Set(this._rawData, "errored", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Expired
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "expired"); }
        init { JsonModel.Set(this._rawData, "expired", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "processing"); }
        init { JsonModel.Set(this._rawData, "processing", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Succeeded
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "succeeded"); }
        init { JsonModel.Set(this._rawData, "succeeded", value); }
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

    public BetaMessageBatchRequestCounts() { }

    public BetaMessageBatchRequestCounts(
        BetaMessageBatchRequestCounts betaMessageBatchRequestCounts
    )
        : base(betaMessageBatchRequestCounts) { }

    public BetaMessageBatchRequestCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchRequestCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchRequestCountsFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchRequestCountsFromRaw : IFromRawJson<BetaMessageBatchRequestCounts>
{
    /// <inheritdoc/>
    public BetaMessageBatchRequestCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchRequestCounts.FromRawUnchecked(rawData);
}
