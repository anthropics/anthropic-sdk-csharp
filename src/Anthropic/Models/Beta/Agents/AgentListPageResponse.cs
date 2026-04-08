using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Paginated list of agents.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentListPageResponse, AgentListPageResponseFromRaw>))]
public sealed record class AgentListPageResponse : JsonModel
{
    /// <summary>
    /// List of agents.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsAgent>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsAgent>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgent>?>(
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

    public AgentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentListPageResponse(AgentListPageResponse agentListPageResponse)
        : base(agentListPageResponse) { }
#pragma warning restore CS8618

    public AgentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentListPageResponseFromRaw.FromRawUnchecked"/>
    public static AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentListPageResponseFromRaw : IFromRawJson<AgentListPageResponse>
{
    /// <inheritdoc/>
    public AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentListPageResponse.FromRawUnchecked(rawData);
}
