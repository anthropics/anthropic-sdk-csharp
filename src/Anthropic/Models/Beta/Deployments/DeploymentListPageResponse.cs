using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// Paginated list of deployments.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DeploymentListPageResponse, DeploymentListPageResponseFromRaw>)
)]
public sealed record class DeploymentListPageResponse : JsonModel
{
    /// <summary>
    /// List of deployments.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsDeployment> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsDeployment>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsDeployment>>(
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

    public DeploymentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeploymentListPageResponse(DeploymentListPageResponse deploymentListPageResponse)
        : base(deploymentListPageResponse) { }
#pragma warning restore CS8618

    public DeploymentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeploymentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeploymentListPageResponseFromRaw.FromRawUnchecked"/>
    public static DeploymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeploymentListPageResponse(IReadOnlyList<BetaManagedAgentsDeployment> data)
        : this()
    {
        this.Data = data;
    }
}

class DeploymentListPageResponseFromRaw : IFromRawJson<DeploymentListPageResponse>
{
    /// <inheritdoc/>
    public DeploymentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeploymentListPageResponse.FromRawUnchecked(rawData);
}
