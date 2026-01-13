using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionListPageResponse, VersionListPageResponseFromRaw>))]
public sealed record class VersionListPageResponse : JsonModel
{
    /// <summary>
    /// List of skill versions.
    /// </summary>
    public required IReadOnlyList<VersionListResponse> Data
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<VersionListResponse>>("data"); }
        init
        {
            this._rawData.Set<ImmutableArray<VersionListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates if there are more results in the requested page direction.
    /// </summary>
    public required bool HasMore
    {
        get { return this._rawData.GetNotNullStruct<bool>("has_more"); }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data.
    /// </summary>
    public required string? NextPage
    {
        get { return this._rawData.GetNullableClass<string>("next_page"); }
        init { this._rawData.Set("next_page", value); }
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

    public VersionListPageResponse() { }

    public VersionListPageResponse(VersionListPageResponse versionListPageResponse)
        : base(versionListPageResponse) { }

    public VersionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionListPageResponseFromRaw.FromRawUnchecked"/>
    public static VersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionListPageResponseFromRaw : IFromRawJson<VersionListPageResponse>
{
    /// <inheritdoc/>
    public VersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionListPageResponse.FromRawUnchecked(rawData);
}
