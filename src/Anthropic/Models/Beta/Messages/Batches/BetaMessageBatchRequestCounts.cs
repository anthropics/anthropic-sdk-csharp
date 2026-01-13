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
        get { return this._rawData.GetNotNullStruct<long>("canceled"); }
        init { this._rawData.Set("canceled", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that encountered an error.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Errored
    {
        get { return this._rawData.GetNotNullStruct<long>("errored"); }
        init { this._rawData.Set("errored", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have expired.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Expired
    {
        get { return this._rawData.GetNotNullStruct<long>("expired"); }
        init { this._rawData.Set("expired", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that are processing.
    /// </summary>
    public required long Processing
    {
        get { return this._rawData.GetNotNullStruct<long>("processing"); }
        init { this._rawData.Set("processing", value); }
    }

    /// <summary>
    /// Number of requests in the Message Batch that have completed successfully.
    ///
    /// <para>This is zero until processing of the entire Message Batch has ended.</para>
    /// </summary>
    public required long Succeeded
    {
        get { return this._rawData.GetNotNullStruct<long>("succeeded"); }
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

    public BetaMessageBatchRequestCounts() { }

    public BetaMessageBatchRequestCounts(
        BetaMessageBatchRequestCounts betaMessageBatchRequestCounts
    )
        : base(betaMessageBatchRequestCounts) { }

    public BetaMessageBatchRequestCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchRequestCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
