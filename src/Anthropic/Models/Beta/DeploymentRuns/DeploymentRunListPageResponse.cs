using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// Paginated list of deployment runs. Sorted by created_at descending (most recent first).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DeploymentRunListPageResponse, DeploymentRunListPageResponseFromRaw>)
)]
public sealed record class DeploymentRunListPageResponse : JsonModel
{
    /// <summary>
    /// List of deployment runs.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsDeploymentRun> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsDeploymentRun>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsDeploymentRun>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
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
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public DeploymentRunListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeploymentRunListPageResponse(
        DeploymentRunListPageResponse deploymentRunListPageResponse
    )
        : base(deploymentRunListPageResponse) { }
#pragma warning restore CS8618

    public DeploymentRunListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeploymentRunListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeploymentRunListPageResponseFromRaw.FromRawUnchecked"/>
    public static DeploymentRunListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeploymentRunListPageResponse(IReadOnlyList<BetaManagedAgentsDeploymentRun> data)
        : this()
    {
        this.Data = data;
    }
}

class DeploymentRunListPageResponseFromRaw : IFromRawJson<DeploymentRunListPageResponse>
{
    /// <inheritdoc/>
    public DeploymentRunListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeploymentRunListPageResponse.FromRawUnchecked(rawData);
}
