using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

[JsonConverter(
    typeof(JsonModelConverter<WorkspaceListPageResponse, WorkspaceListPageResponseFromRaw>)
)]
public sealed record class WorkspaceListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaFederationRuleWorkspace> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaFederationRuleWorkspace>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaFederationRuleWorkspace>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page; null when there are no more results.
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

    public WorkspaceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceListPageResponse(WorkspaceListPageResponse workspaceListPageResponse)
        : base(workspaceListPageResponse) { }
#pragma warning restore CS8618

    public WorkspaceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceListPageResponseFromRaw.FromRawUnchecked"/>
    public static WorkspaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceListPageResponseFromRaw : IFromRawJson<WorkspaceListPageResponse>
{
    /// <inheritdoc/>
    public WorkspaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceListPageResponse.FromRawUnchecked(rawData);
}
