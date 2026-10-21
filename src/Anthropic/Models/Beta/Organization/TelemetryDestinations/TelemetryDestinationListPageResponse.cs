using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// A page of the organization's telemetry destinations, newest first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TelemetryDestinationListPageResponse,
        TelemetryDestinationListPageResponseFromRaw
    >)
)]
public sealed record class TelemetryDestinationListPageResponse : JsonModel
{
    /// <summary>
    /// Destinations on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaTelemetryDestination> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaTelemetryDestination>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTelemetryDestination>>(
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

    public TelemetryDestinationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelemetryDestinationListPageResponse(
        TelemetryDestinationListPageResponse telemetryDestinationListPageResponse
    )
        : base(telemetryDestinationListPageResponse) { }
#pragma warning restore CS8618

    public TelemetryDestinationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TelemetryDestinationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TelemetryDestinationListPageResponseFromRaw.FromRawUnchecked"/>
    public static TelemetryDestinationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TelemetryDestinationListPageResponseFromRaw
    : IFromRawJson<TelemetryDestinationListPageResponse>
{
    /// <inheritdoc/>
    public TelemetryDestinationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TelemetryDestinationListPageResponse.FromRawUnchecked(rawData);
}
