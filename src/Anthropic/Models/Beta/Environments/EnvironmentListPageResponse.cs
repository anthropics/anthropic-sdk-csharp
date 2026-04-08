using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Response when listing environments.
///
/// <para>This response model uses opaque cursor-based pagination. Use the `page`
/// query parameter with the value from `next_page` to fetch the next page.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EnvironmentListPageResponse, EnvironmentListPageResponseFromRaw>)
)]
public sealed record class EnvironmentListPageResponse : JsonModel
{
    /// <summary>
    /// List of environments.
    /// </summary>
    public required IReadOnlyList<BetaEnvironment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaEnvironment>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaEnvironment>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token for fetching the next page of results. If `null`, there are no more
    /// results available. Pass this value to the `page` parameter in the next request.
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

    public EnvironmentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnvironmentListPageResponse(EnvironmentListPageResponse environmentListPageResponse)
        : base(environmentListPageResponse) { }
#pragma warning restore CS8618

    public EnvironmentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EnvironmentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EnvironmentListPageResponseFromRaw.FromRawUnchecked"/>
    public static EnvironmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EnvironmentListPageResponseFromRaw : IFromRawJson<EnvironmentListPageResponse>
{
    /// <inheritdoc/>
    public EnvironmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EnvironmentListPageResponse.FromRawUnchecked(rawData);
}
