using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Artifacts;

/// <summary>
/// Response for GET /v1/organizations/analytics/artifacts.
///
/// <para>`next_page` is null on ungrouped queries — the artifact-type cube is finite
/// and returned in full. Grouped queries (`group_by[]` on `product` / `user_id` /
/// `rbac_group_id`) multiply the cube and paginate like the other analytics list endpoints.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ArtifactListPageResponse, ArtifactListPageResponseFromRaw>)
)]
public sealed record class ArtifactListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsArtifactActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsArtifactActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsArtifactActivity>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page of a grouped query; always null for the ungrouped
    /// artifact-type cube, which is returned in full.
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

    public ArtifactListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactListPageResponse(ArtifactListPageResponse artifactListPageResponse)
        : base(artifactListPageResponse) { }
#pragma warning restore CS8618

    public ArtifactListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactListPageResponseFromRaw.FromRawUnchecked"/>
    public static ArtifactListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtifactListPageResponseFromRaw : IFromRawJson<ArtifactListPageResponse>
{
    /// <inheritdoc/>
    public ArtifactListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtifactListPageResponse.FromRawUnchecked(rawData);
}
