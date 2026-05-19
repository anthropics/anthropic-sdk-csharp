using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Environments;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Note: these endpoints are called automatically by the pre-built environment worker
/// provided in the SDKs and CLI, for orchestrating sessions with self-hosted sandbox
/// environments. They are included here as a reference; you do not need to invoke
/// them directly.
///
/// <para>Record a heartbeat for a work item to maintain the lease.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkHeartbeatParams : ParamsBase
{
    public required string EnvironmentID { get; init; }

    public string? WorkID { get; init; }

    /// <summary>
    /// Desired TTL in seconds
    /// </summary>
    public long? DesiredTtlSeconds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("desired_ttl_seconds");
        }
        init { this._rawQueryData.Set("desired_ttl_seconds", value); }
    }

    /// <summary>
    /// Expected last_heartbeat for conditional update (optimistic concurrency). Use
    /// literal 'NO_HEARTBEAT' to claim an unclaimed lease (first heartbeat). For
    /// subsequent heartbeats, echo the server's previous last_heartbeat value exactly.
    /// Returns 412 Precondition Failed if the actual value doesn't match.
    /// </summary>
    public string? ExpectedLastHeartbeat
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("expected_last_heartbeat");
        }
        init { this._rawQueryData.Set("expected_last_heartbeat", value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WorkHeartbeatParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkHeartbeatParams(WorkHeartbeatParams workHeartbeatParams)
        : base(workHeartbeatParams)
    {
        this.EnvironmentID = workHeartbeatParams.EnvironmentID;
        this.WorkID = workHeartbeatParams.WorkID;
    }
#pragma warning restore CS8618

    public WorkHeartbeatParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkHeartbeatParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string environmentID,
        string workID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EnvironmentID = environmentID;
        this.WorkID = workID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkHeartbeatParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string environmentID,
        string workID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            environmentID,
            workID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EnvironmentID"] = JsonSerializer.SerializeToElement(this.EnvironmentID),
                    ["WorkID"] = JsonSerializer.SerializeToElement(this.WorkID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WorkHeartbeatParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.EnvironmentID.Equals(other.EnvironmentID)
            && (this.WorkID?.Equals(other.WorkID) ?? other.WorkID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/environments/{0}/work/{1}/heartbeat",
                    this.EnvironmentID,
                    this.WorkID
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        WorkService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
