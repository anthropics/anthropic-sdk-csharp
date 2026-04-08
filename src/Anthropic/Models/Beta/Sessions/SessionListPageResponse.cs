using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Paginated list of sessions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SessionListPageResponse, SessionListPageResponseFromRaw>))]
public sealed record class SessionListPageResponse : JsonModel
{
    /// <summary>
    /// List of sessions.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsSession>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsSession>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsSession>?>(
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

    public SessionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionListPageResponse(SessionListPageResponse sessionListPageResponse)
        : base(sessionListPageResponse) { }
#pragma warning restore CS8618

    public SessionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionListPageResponseFromRaw.FromRawUnchecked"/>
    public static SessionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionListPageResponseFromRaw : IFromRawJson<SessionListPageResponse>
{
    /// <inheritdoc/>
    public SessionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SessionListPageResponse.FromRawUnchecked(rawData);
}
