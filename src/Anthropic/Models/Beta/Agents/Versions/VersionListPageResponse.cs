using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents.Versions;

/// <summary>
/// Paginated list of agent versions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionListPageResponse, VersionListPageResponseFromRaw>))]
public sealed record class VersionListPageResponse : JsonModel
{
    /// <summary>
    /// Agent versions.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsAgent>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsAgent>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgent>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public VersionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionListPageResponse(VersionListPageResponse versionListPageResponse)
        : base(versionListPageResponse) { }
#pragma warning restore CS8618

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
