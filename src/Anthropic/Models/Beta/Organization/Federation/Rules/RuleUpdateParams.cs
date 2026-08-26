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
/// <para>Partially update a federation rule.</para>
///
/// <para>`issuer_id` is immutable. `match` and `target` are replaced as whole objects
/// when set. Referenced service accounts and workspaces must exist in your organization;
/// invalid references are rejected with a 400 error. Archived rules cannot be updated;
/// this returns 400. Create a new rule instead. Rules on well-known shared issuers
/// (GitHub Actions, GitLab, Buildkite, Terraform Cloud, Google) must constrain tenant
/// identity via an identity-bearing claim, a tenant-pinning subject prefix (such
/// as `repo:YOUR_ORG/...`), or a CEL condition referencing one of those identity
/// claims (e.g. `claims.repository_owner`). On these issuers the requirement is re-checked
/// on every update; if an existing rule's stored match does not yet constrain tenant
/// identity, any update (even a rename or description change) must also supply a
/// conforming `match` in the same request. OAuth callers may only manage rules whose
/// `oauth_scope` is `workspace:developer` or `workspace:inference`; other scopes
/// require a Console session.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RuleUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FederationRuleID { get; init; }

    /// <summary>
    /// When true, enables this rule for every workspace in the org (including workspaces
    /// created later). Setting `false` is rejected with 400 if no workspace would
    /// remain enabled; a rule with only a legacy `workspace_id` binding continues
    /// to mint.
    /// </summary>
    public bool? AppliesToAllWorkspaces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("applies_to_all_workspaces");
        }
        init { this._rawBodyData.Set("applies_to_all_workspaces", value); }
    }

    /// <summary>
    /// Replaces the CEL expressions `{name: expr}` extracting named values from
    /// claims. Send null to clear them. Not yet supported; any non-empty value is
    /// rejected with 400.
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
    /// Replaces the description. Omit to leave unchanged; send `null` to clear (the
    /// field is stored as an empty string).
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
    /// Does the incoming JWT qualify?
    ///
    /// <para>All populated fields must pass; omitted fields are skipped. At least
    /// one of `subject_prefix` (other than a wildcard-only value like `*`), `claims`,
    /// or `condition` is required; `audience` alone is not sufficient.</para>
    /// </summary>
    public BetaFederationRuleMatch? Match
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaFederationRuleMatch>("match");
        }
        init { this._rawBodyData.Set("match", value); }
    }

    /// <summary>
    /// Replaces the slug identifier (lowercase, digits, hyphens). Unique within the
    /// organization; a duplicate name returns 409.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Replaces the space-separated OAuth scopes granted on minted tokens. OAuth
    /// callers may only set `workspace:developer` or `workspace:inference`; other
    /// scopes (such as `org:admin`) require a Console session.
    /// </summary>
    public string? OAuthScope
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("oauth_scope");
        }
        init { this._rawBodyData.Set("oauth_scope", value); }
    }

    /// <summary>
    /// Bind to a fixed service account by ID.
    /// </summary>
    public BetaServiceAccountTarget? Target
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaServiceAccountTarget>("target");
        }
        init { this._rawBodyData.Set("target", value); }
    }

    /// <summary>
    /// Replaces the lifetime in seconds for access tokens minted via this rule (60-86400).
    /// Minted tokens are capped at `max(60, min(this value, 2 × remaining assertion
    /// validity))` seconds.
    /// </summary>
    public long? TokenLifetimeSeconds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("token_lifetime_seconds");
        }
        init { this._rawBodyData.Set("token_lifetime_seconds", value); }
    }

    /// <summary>
    /// Replaces the existing single workspace enablement (the previous one is removed).
    /// Rejected with 400 if the rule is enabled for more than one workspace; use
    /// the `/federation_rules/{federation_rule_id}/workspaces` sub-resource instead.
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

    public RuleUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleUpdateParams(RuleUpdateParams ruleUpdateParams)
        : base(ruleUpdateParams)
    {
        this.FederationRuleID = ruleUpdateParams.FederationRuleID;

        this._rawBodyData = new(ruleUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RuleUpdateParams(
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
    RuleUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string federationRuleID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FederationRuleID = federationRuleID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RuleUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string federationRuleID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            federationRuleID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FederationRuleID"] = JsonSerializer.SerializeToElement(this.FederationRuleID),
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

    public virtual bool Equals(RuleUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.FederationRuleID?.Equals(other.FederationRuleID)
                ?? other.FederationRuleID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/organizations/federation_rules/{0}", this.FederationRuleID)
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
