using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

[JsonConverter(typeof(JsonModelConverter<ModelListPageResponse, ModelListPageResponseFromRaw>))]
public sealed record class ModelListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaModelInfo> Data
    {
        get { return JsonModel.GetNotNullClass<List<BetaModelInfo>>(this.RawData, "data"); }
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

    public ModelListPageResponse() { }

    public ModelListPageResponse(ModelListPageResponse modelListPageResponse)
        : base(modelListPageResponse) { }

    public ModelListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ModelListPageResponseFromRaw.FromRawUnchecked"/>
    public static ModelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ModelListPageResponseFromRaw : IFromRawJson<ModelListPageResponse>
{
    /// <inheritdoc/>
    public ModelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ModelListPageResponse.FromRawUnchecked(rawData);
}
