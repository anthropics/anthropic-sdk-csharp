using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Rules;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Create a federation rule owned by your organization.</para>
///
/// <para>The referenced issuer and the target service account must already exist
/// in the same organization; invalid references are rejected with a 400 error. The
/// workspace reference is validated. Membership is not checked at rule creation:
/// token exchange resolves a single enabled workspace per call and is rejected unless
/// the target service account is a member of that workspace (it is implicitly a
/// member of the default workspace). Rules on well-known shared issuers (GitHub Actions,
/// GitLab, Buildkite, Terraform Cloud, Google) must constrain tenant identity via
/// an identity-bearing claim, a tenant-pinning subject prefix (such as `repo:YOUR_ORG/...`),
/// or a CEL condition referencing one of those identity claims (e.g. `claims.repository_owner`).
/// OAuth callers may only manage rules whose `oauth_scope` is `workspace:developer`
/// or `workspace:inference`; other scopes require a Console session.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RuleCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Tagged ID of the federation issuer.
    /// </summary>
    public required string IssuerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("issuer_id");
        }
        init { this._rawBodyData.Set("issuer_id", value); }
    }

    /// <summary>
    /// Conditions the verified JWT must satisfy for this rule to apply. At least
    /// one of `subject_prefix` (other than a wildcard-only value like `*`), `claims`,
    /// or `condition` is required; `audience` alone is not sufficient.
    /// </summary>
    public required BetaFederationRuleMatch Match
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BetaFederationRuleMatch>("match");
        }
        init { this._rawBodyData.Set("match", value); }
    }

    /// <summary>
    /// Slug identifier (lowercase, digits, hyphens). Unique within the organization;
    /// a duplicate name returns 409.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Space-separated OAuth scopes. OAuth callers may only set `workspace:developer`
    /// or `workspace:inference`; other scopes (such as `org:admin`) require a Console session.
    /// </summary>
    public required string OAuthScope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("oauth_scope");
        }
        init { this._rawBodyData.Set("oauth_scope", value); }
    }

    /// <summary>
    /// Identity that tokens minted via this rule act as. Currently always a `service_account` target.
    /// </summary>
    public required BetaServiceAccountTarget Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BetaServiceAccountTarget>("target");
        }
        init { this._rawBodyData.Set("target", value); }
    }

    /// <summary>
    /// When true, enable this rule for every workspace in the org (including workspaces
    /// created later).
    /// </summary>
    public bool? AppliesToAllWorkspaces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("applies_to_all_workspaces");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("applies_to_all_workspaces", value);
        }
    }

    /// <summary>
    /// CEL expressions `{name: expr}` extracting named values from claims. Not yet
    /// supported; any non-empty value is rejected with 400.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Attributes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "attributes"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional free-text description.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Lifetime in seconds for access tokens minted via this rule (60-86400). Defaults
    /// to 3600 (1h). Minted tokens are capped at `max(60, min(this value, 2 × remaining
    /// assertion validity))` seconds.
    /// </summary>
    public long? TokenLifetimeSeconds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("token_lifetime_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("token_lifetime_seconds", value);
        }
    }

    /// <summary>
    /// Tagged ID of the workspace to enable this rule for. Required unless `applies_to_all_workspaces`
    /// is true. Additional workspaces can be added via the `/federation_rules/{federation_rule_id}/workspaces` sub-resource.
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("workspace_id");
        }
        init { this._rawBodyData.Set("workspace_id", value); }
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

    public RuleCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleCreateParams(RuleCreateParams ruleCreateParams)
        : base(ruleCreateParams)
    {
        this._rawBodyData = new(ruleCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RuleCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RuleCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RuleCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/federation_rules"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
