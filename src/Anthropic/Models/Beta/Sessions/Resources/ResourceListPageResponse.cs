using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Resources;

/// <summary>
/// Paginated list of resources attached to a session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResourceListPageResponse, ResourceListPageResponseFromRaw>)
)]
public sealed record class ResourceListPageResponse : JsonModel
{
    /// <summary>
    /// Resources for the session, ordered by `created_at`.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSessionResource> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsSessionResource>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionResource>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page. Null when no more results.
    /// </summary>
    public string? NextPage
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

    public ResourceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResourceListPageResponse(ResourceListPageResponse resourceListPageResponse)
        : base(resourceListPageResponse) { }
#pragma warning restore CS8618

    public ResourceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResourceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResourceListPageResponseFromRaw.FromRawUnchecked"/>
    public static ResourceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResourceListPageResponse(IReadOnlyList<BetaManagedAgentsSessionResource> data)
        : this()
    {
        this.Data = data;
    }
}

class ResourceListPageResponseFromRaw : IFromRawJson<ResourceListPageResponse>
{
    /// <inheritdoc/>
    public ResourceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResourceListPageResponse.FromRawUnchecked(rawData);
}
