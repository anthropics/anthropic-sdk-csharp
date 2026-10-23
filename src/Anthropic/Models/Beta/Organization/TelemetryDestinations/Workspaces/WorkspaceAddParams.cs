using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

/// <summary>
/// Add one workspace to a destination's workspace list.
///
/// <para>Under `include` the workspace's spans start going to the destination. Under
/// `exclude` they stop. A list holds at most 1,000 workspaces.</para>
///
/// <para>Adding a workspace that is already on the list changes nothing and returns
/// the existing entry. An archived workspace that isn't on the list yet can't be
/// added. A destination whose `workspaces.type` is `all` doesn't have a list, so
/// the API returns 400. To change which workspaces such a destination covers, update
/// its `workspaces`.</para>
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#choose-workspaces-for-a-destination)
/// to learn more about choosing the workspaces of a destination.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkspaceAddParams : ParamsBase
{
    public required string DestinationID { get; init; }

    public string? WorkspaceID { get; init; }

    /// <summary>
    /// This endpoint is in beta: requests must send `telemetry-destinations-2026-08-11`
    /// in this header.
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
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WorkspaceAddParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceAddParams(WorkspaceAddParams workspaceAddParams)
        : base(workspaceAddParams)
    {
        this.DestinationID = workspaceAddParams.DestinationID;
        this.WorkspaceID = workspaceAddParams.WorkspaceID;
    }
#pragma warning restore CS8618

    public WorkspaceAddParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceAddParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string destinationID,
        string workspaceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.DestinationID = destinationID;
        this.WorkspaceID = workspaceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkspaceAddParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string destinationID,
        string workspaceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            destinationID,
            workspaceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DestinationID"] = JsonSerializer.SerializeToElement(this.DestinationID),
                    ["WorkspaceID"] = JsonSerializer.SerializeToElement(this.WorkspaceID),
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

    public virtual bool Equals(WorkspaceAddParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.DestinationID.Equals(other.DestinationID)
            && (this.WorkspaceID?.Equals(other.WorkspaceID) ?? other.WorkspaceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/telemetry_destinations/{0}/workspaces/{1}",
                    ParamsBase.EncodePathSegment(this.DestinationID, nameof(this.DestinationID)),
                    ParamsBase.EncodePathSegment(this.WorkspaceID, nameof(this.WorkspaceID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/telemetry_destinations/{destination_id}/workspaces/{workspace_id}";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        WorkspaceService.AddDefaultHeaders(request);
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
