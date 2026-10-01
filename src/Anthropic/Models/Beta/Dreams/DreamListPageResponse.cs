using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// A page of dreams, newest first.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DreamListPageResponse, DreamListPageResponseFromRaw>))]
public sealed record class DreamListPageResponse : JsonModel
{
    /// <summary>
    /// The dreams on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaDream> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaDream>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaDream>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The cursor for the next page, or `null` if this is the last page.
    ///
    /// <para>Pass it as `page` to get the next page.</para>
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

    public DreamListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DreamListPageResponse(DreamListPageResponse dreamListPageResponse)
        : base(dreamListPageResponse) { }
#pragma warning restore CS8618

    public DreamListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DreamListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DreamListPageResponseFromRaw.FromRawUnchecked"/>
    public static DreamListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DreamListPageResponseFromRaw : IFromRawJson<DreamListPageResponse>
{
    /// <inheritdoc/>
    public DreamListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DreamListPageResponse.FromRawUnchecked(rawData);
}
