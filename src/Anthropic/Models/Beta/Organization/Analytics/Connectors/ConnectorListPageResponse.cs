using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Connectors;

/// <summary>
/// Response for GET /v1/organizations/analytics/connectors.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConnectorListPageResponse, ConnectorListPageResponseFromRaw>)
)]
public sealed record class ConnectorListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsConnectorActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsConnectorActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsConnectorActivity>>(
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

    public ConnectorListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectorListPageResponse(ConnectorListPageResponse connectorListPageResponse)
        : base(connectorListPageResponse) { }
#pragma warning restore CS8618

    public ConnectorListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectorListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectorListPageResponseFromRaw.FromRawUnchecked"/>
    public static ConnectorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectorListPageResponseFromRaw : IFromRawJson<ConnectorListPageResponse>
{
    /// <inheritdoc/>
    public ConnectorListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConnectorListPageResponse.FromRawUnchecked(rawData);
}
