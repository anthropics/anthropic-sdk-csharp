using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Plugins.Shares;

[JsonConverter(typeof(JsonModelConverter<ShareListPageResponse, ShareListPageResponseFromRaw>))]
public sealed record class ShareListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaPluginShare> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaPluginShare>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginShare>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data.
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

    public ShareListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShareListPageResponse(ShareListPageResponse shareListPageResponse)
        : base(shareListPageResponse) { }
#pragma warning restore CS8618

    public ShareListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShareListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShareListPageResponseFromRaw.FromRawUnchecked"/>
    public static ShareListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShareListPageResponseFromRaw : IFromRawJson<ShareListPageResponse>
{
    /// <inheritdoc/>
    public ShareListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShareListPageResponse.FromRawUnchecked(rawData);
}
