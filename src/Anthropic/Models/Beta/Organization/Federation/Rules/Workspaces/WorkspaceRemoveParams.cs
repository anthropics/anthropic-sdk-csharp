using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Disable a federation rule for a workspace.</para>
///
/// <para>Idempotent; succeeds even if the enablement was already removed. OAuth
/// callers may only manage rules whose `oauth_scope` is `workspace:developer` or
/// `workspace:inference`; other scopes require a Console session.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WorkspaceRemoveParams : ParamsBase
{
    public required string FederationRuleID { get; init; }

    public string? WorkspaceID { get; init; }

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

    public WorkspaceRemoveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRemoveParams(WorkspaceRemoveParams workspaceRemoveParams)
        : base(workspaceRemoveParams)
    {
        this.FederationRuleID = workspaceRemoveParams.FederationRuleID;
        this.WorkspaceID = workspaceRemoveParams.WorkspaceID;
    }
#pragma warning restore CS8618

    public WorkspaceRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string federationRuleID,
        string workspaceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.FederationRuleID = federationRuleID;
        this.WorkspaceID = workspaceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WorkspaceRemoveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string federationRuleID,
        string workspaceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            federationRuleID,
            workspaceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FederationRuleID"] = JsonSerializer.SerializeToElement(this.FederationRuleID),
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

    public virtual bool Equals(WorkspaceRemoveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.FederationRuleID.Equals(other.FederationRuleID)
            && (this.WorkspaceID?.Equals(other.WorkspaceID) ?? other.WorkspaceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/federation_rules/{0}/workspaces/{1}",
                    this.FederationRuleID,
                    this.WorkspaceID
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
