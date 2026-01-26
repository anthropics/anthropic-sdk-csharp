using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(typeof(JsonModelConverter<BatchListPageResponse, BatchListPageResponseFromRaw>))]
public sealed record class BatchListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaMessageBatch> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaMessageBatch>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaMessageBatch>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// First ID in the `data` list. Can be used as the `before_id` for the previous page.
    /// </summary>
    public required string? FirstID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_id");
        }
        init { this._rawData.Set("first_id", value); }
    }

    /// <summary>
    /// Indicates if there are more results in the requested page direction.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Last ID in the `data` list. Can be used as the `after_id` for the next page.
    /// </summary>
    public required string? LastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_id");
        }
        init { this._rawData.Set("last_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.FirstID;
        _ = this.HasMore;
        _ = this.LastID;
    }

    public BatchListPageResponse() { }

    public BatchListPageResponse(BatchListPageResponse batchListPageResponse)
        : base(batchListPageResponse) { }

    public BatchListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListPageResponseFromRaw.FromRawUnchecked"/>
    public static BatchListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListPageResponseFromRaw : IFromRawJson<BatchListPageResponse>
{
    /// <inheritdoc/>
    public BatchListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchListPageResponse.FromRawUnchecked(rawData);
}
