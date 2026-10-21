using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;

/// <summary>
/// Response for GET /v1/organizations/analytics/apps/chat/projects.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProjectListPageResponse, ProjectListPageResponseFromRaw>))]
public sealed record class ProjectListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsProjectActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsProjectActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsProjectActivity>>(
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

    public ProjectListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProjectListPageResponse(ProjectListPageResponse projectListPageResponse)
        : base(projectListPageResponse) { }
#pragma warning restore CS8618

    public ProjectListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProjectListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProjectListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectListPageResponseFromRaw : IFromRawJson<ProjectListPageResponse>
{
    /// <inheritdoc/>
    public ProjectListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProjectListPageResponse.FromRawUnchecked(rawData);
}
