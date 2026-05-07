using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Models.Beta.Sessions.Threads.Events;

/// <summary>
/// Paginated list of events for a single thread within a `session`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventListPageResponse, EventListPageResponseFromRaw>))]
public sealed record class EventListPageResponse : JsonModel
{
    /// <summary>
    /// Events for the thread, ordered by `created_at`.
    /// </summary>
    public IReadOnlyList<Events::BetaManagedAgentsSessionEvent>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<Events::BetaManagedAgentsSessionEvent>
            >("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Events::BetaManagedAgentsSessionEvent>?>(
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

    public EventListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventListPageResponse(EventListPageResponse eventListPageResponse)
        : base(eventListPageResponse) { }
#pragma warning restore CS8618

    public EventListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventListPageResponseFromRaw.FromRawUnchecked"/>
    public static EventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventListPageResponseFromRaw : IFromRawJson<EventListPageResponse>
{
    /// <inheritdoc/>
    public EventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventListPageResponse.FromRawUnchecked(rawData);
}
