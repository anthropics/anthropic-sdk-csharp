using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Skills;

/// <summary>
/// Response for GET /v1/organizations/analytics/skills.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SkillListPageResponse, SkillListPageResponseFromRaw>))]
public sealed record class SkillListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsSkillActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsSkillActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsSkillActivity>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public SkillListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkillListPageResponse(SkillListPageResponse skillListPageResponse)
        : base(skillListPageResponse) { }
#pragma warning restore CS8618

    public SkillListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
