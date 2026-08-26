using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Remove a service account from a workspace.</para>
///
/// <para>Removal is idempotent (returns 200 even if the membership was already removed).
/// A DELETE against the implicit default-workspace membership returns 200 but is
/// a no-op and the membership persists; deleting an explicit default-workspace row
/// reverts to the implicit `workspace_user` membership. Archived workspaces return 400.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ServiceAccountRemoveParams : ParamsBase
{
    public required string WorkspaceID { get; init; }

    public string? ServiceAccountID { get; init; }

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

    public ServiceAccountRemoveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServiceAccountRemoveParams(ServiceAccountRemoveParams serviceAccountRemoveParams)
        : base(serviceAccountRemoveParams)
    {
        this.WorkspaceID = serviceAccountRemoveParams.WorkspaceID;
        this.ServiceAccountID = serviceAccountRemoveParams.ServiceAccountID;
    }
#pragma warning restore CS8618

    public ServiceAccountRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServiceAccountRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string workspaceID,
        string serviceAccountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.WorkspaceID = workspaceID;
        this.ServiceAccountID = serviceAccountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ServiceAccountRemoveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string workspaceID,
        string serviceAccountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            workspaceID,
            serviceAccountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WorkspaceID"] = JsonSerializer.SerializeToElement(this.WorkspaceID),
                    ["ServiceAccountID"] = JsonSerializer.SerializeToElement(this.ServiceAccountID),
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

    public virtual bool Equals(ServiceAccountRemoveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.WorkspaceID.Equals(other.WorkspaceID)
            && (
                this.ServiceAccountID?.Equals(other.ServiceAccountID)
                ?? other.ServiceAccountID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/workspaces/{0}/service_accounts/{1}",
                    this.WorkspaceID,
                    this.ServiceAccountID
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
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
