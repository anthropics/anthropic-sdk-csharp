using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills;

[JsonConverter(typeof(JsonModelConverter<SkillListPageResponse, SkillListPageResponseFromRaw>))]
public sealed record class SkillListPageResponse : JsonModel
{
    /// <summary>
    /// List of skills.
    /// </summary>
    public required IReadOnlyList<SkillListResponse> Data
    {
        get { return JsonModel.GetNotNullClass<List<SkillListResponse>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// Whether there are more results available.
    ///
    /// <para>If `true`, there are additional results that can be fetched using the
    /// `next_page` token.</para>
    /// </summary>
    public required bool HasMore
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { JsonModel.Set(this._rawData, "has_more", value); }
    }

    /// <summary>
    /// Token for fetching the next page of results.
    ///
    /// <para>If `null`, there are no more results available. Pass this value to
    /// the `page_token` parameter in the next request to get the next page.</para>
    /// </summary>
    public required string? NextPage
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next_page"); }
        init { JsonModel.Set(this._rawData, "next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextPage;
    }

    public SkillListPageResponse() { }

    public SkillListPageResponse(SkillListPageResponse skillListPageResponse)
        : base(skillListPageResponse) { }

    public SkillListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SkillListPageResponseFromRaw.FromRawUnchecked"/>
    public static SkillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SkillListPageResponseFromRaw : IFromRawJson<SkillListPageResponse>
{
    /// <inheritdoc/>
    public SkillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SkillListPageResponse.FromRawUnchecked(rawData);
}
