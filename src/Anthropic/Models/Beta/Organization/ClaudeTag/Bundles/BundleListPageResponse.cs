using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles;

[JsonConverter(typeof(JsonModelConverter<BundleListPageResponse, BundleListPageResponseFromRaw>))]
public sealed record class BundleListPageResponse : JsonModel
{
    /// <summary>
    /// Bundles on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaClaudeTagBundle> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaClaudeTagBundle>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeTagBundle>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page. Null on the last page.
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

    public BundleListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BundleListPageResponse(BundleListPageResponse bundleListPageResponse)
        : base(bundleListPageResponse) { }
#pragma warning restore CS8618

    public BundleListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BundleListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BundleListPageResponseFromRaw.FromRawUnchecked"/>
    public static BundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BundleListPageResponseFromRaw : IFromRawJson<BundleListPageResponse>
{
    /// <inheritdoc/>
    public BundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BundleListPageResponse.FromRawUnchecked(rawData);
}
