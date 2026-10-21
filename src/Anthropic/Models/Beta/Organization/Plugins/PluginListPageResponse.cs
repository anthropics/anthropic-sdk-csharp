using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<PluginListPageResponse, PluginListPageResponseFromRaw>))]
public sealed record class PluginListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaPlugin> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaPlugin>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPlugin>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data. A page may hold fewer than `limit` Plugins, even none, while
    /// this is set; keep following it until it is null.
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

    public PluginListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginListPageResponse(PluginListPageResponse pluginListPageResponse)
        : base(pluginListPageResponse) { }
#pragma warning restore CS8618

    public PluginListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PluginListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PluginListPageResponseFromRaw.FromRawUnchecked"/>
    public static PluginListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PluginListPageResponseFromRaw : IFromRawJson<PluginListPageResponse>
{
    /// <inheritdoc/>
    public PluginListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PluginListPageResponse.FromRawUnchecked(rawData);
}
