using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<BetaMessageBatch>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// First ID in the `data` list. Can be used as the `before_id` for the previous page.
    /// </summary>
    public required string? FirstID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "first_id"); }
        init { JsonModel.Set(this._rawData, "first_id", value); }
    }

    /// <summary>
    /// Indicates if there are more results in the requested page direction.
    /// </summary>
    public required bool HasMore
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { JsonModel.Set(this._rawData, "has_more", value); }
    }

    /// <summary>
    /// Last ID in the `data` list. Can be used as the `after_id` for the next page.
    /// </summary>
    public required string? LastID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "last_id"); }
        init { JsonModel.Set(this._rawData, "last_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
