using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Plugins;

/// <summary>
/// Response for GET /v1/organizations/analytics/plugins.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PluginListPageResponse, PluginListPageResponseFromRaw>))]
public sealed record class PluginListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsPluginActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsPluginActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsPluginActivity>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results
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
