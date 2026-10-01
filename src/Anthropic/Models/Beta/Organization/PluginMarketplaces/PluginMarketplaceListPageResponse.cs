using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

[JsonConverter(
    typeof(JsonModelConverter<
        PluginMarketplaceListPageResponse,
        PluginMarketplaceListPageResponseFromRaw
    >)
)]
public sealed record class PluginMarketplaceListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaPluginMarketplace> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaPluginMarketplace>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginMarketplace>>(
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

    public PluginMarketplaceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginMarketplaceListPageResponse(
        PluginMarketplaceListPageResponse pluginMarketplaceListPageResponse
    )
        : base(pluginMarketplaceListPageResponse) { }
#pragma warning restore CS8618

    public PluginMarketplaceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PluginMarketplaceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PluginMarketplaceListPageResponseFromRaw.FromRawUnchecked"/>
    public static PluginMarketplaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PluginMarketplaceListPageResponseFromRaw : IFromRawJson<PluginMarketplaceListPageResponse>
{
    /// <inheritdoc/>
    public PluginMarketplaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PluginMarketplaceListPageResponse.FromRawUnchecked(rawData);
}
