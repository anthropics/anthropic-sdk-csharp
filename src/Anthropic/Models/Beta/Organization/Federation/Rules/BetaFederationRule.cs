using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Federation.Rules;

/// <summary>
/// Authorization rule binding an external OIDC identity to Anthropic.
///
/// <para>Evaluates the match conditions and mints an OAuth access token for the
/// resolved target, scoped to a single workspace where the rule is enabled (chosen
/// by the caller at exchange time when the rule is enabled for more than one). For
/// rules enabled via `workspace_ids` or `applies_to_all_workspaces`, the target service
/// account must be a member of that workspace (it is implicitly a member of the default
/// workspace); rules carrying only the legacy `workspace_id` binding do not enforce this.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFederationRule, BetaFederationRuleFromRaw>))]
public sealed record class BetaFederationRule : JsonModel
{
    /// <summary>
    /// Tagged ID of the federation rule.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When true, this rule is enabled for every workspace in the org (including
    /// ones created after the rule). `workspace_ids` is ignored at exchange time.
    /// </summary>
    public required bool AppliesToAllWorkspaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("applies_to_all_workspaces");
        }
        init { this._rawData.Set("applies_to_all_workspaces", value); }
    }

    /// <summary>
    /// If set, this rule is archived and rejects token exchange.
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that archived this rule.
    /// </summary>
    public required string? ArchivedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_by_actor_id");
        }
        init { this._rawData.Set("archived_by_actor_id", value); }
    }

    /// <summary>
    /// CEL expressions extracting named values from claims. Not yet supported; always null.
    /// </summary>
    public required IReadOnlyDictionary<string, string>? Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("attributes");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "attributes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// When this rule was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that created this rule.
    /// </summary>
    public required string? CreatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by_actor_id");
        }
        init { this._rawData.Set("created_by_actor_id", value); }
    }

    /// <summary>
    /// Optional free-text description.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Tagged ID of the issuer whose tokens this rule accepts.
    /// </summary>
    public required string IssuerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("issuer_id");
        }
        init { this._rawData.Set("issuer_id", value); }
    }

    /// <summary>
    /// Issuer's display name at read time.
    /// </summary>
    public required string? IssuerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("issuer_name");
        }
        init { this._rawData.Set("issuer_name", value); }
    }

    /// <summary>
    /// Conditions the verified JWT must satisfy for this rule to apply. All populated
    /// matcher fields must pass.
    /// </summary>
    public required BetaFederationRuleMatch Match
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFederationRuleMatch>("match");
        }
        init { this._rawData.Set("match", value); }
    }

    /// <summary>
    /// Admin-chosen slug identifier.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Space-separated OAuth scopes granted on the minted token.
    /// </summary>
    public required string OAuthScope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("oauth_scope");
        }
        init { this._rawData.Set("oauth_scope", value); }
    }

    /// <summary>
    /// Identity that tokens minted via this rule act as. Currently always a `service_account` target.
    /// </summary>
    public required BetaServiceAccountTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaServiceAccountTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Lifetime in seconds of access tokens minted via this rule. Minted tokens
    /// are capped at `max(60, min(this value, 2 × remaining assertion validity))` seconds.
    /// </summary>
    public required long TokenLifetimeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("token_lifetime_seconds");
        }
        init { this._rawData.Set("token_lifetime_seconds", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// When this rule was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that last updated this rule.
    /// </summary>
    public required string? UpdatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_by_actor_id");
        }
        init { this._rawData.Set("updated_by_actor_id", value); }
    }

    /// <summary>
    /// Legacy single-workspace binding. Prefer `workspace_ids` and the `/federation_rules/{federation_rule_id}/workspaces`
    /// sub-resource for managing workspace enablement.
    /// </summary>
    public required string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <summary>
    /// Tagged IDs of the workspaces this rule is enabled for. May be empty for older
    /// rules that only carry the legacy `workspace_id` binding. Ignored at exchange
    /// time when `applies_to_all_workspaces` is true (the list may still be non-empty).
    /// </summary>
    public required IReadOnlyList<string> WorkspaceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("workspace_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "workspace_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AppliesToAllWorkspaces;
        _ = this.ArchivedAt;
        _ = this.ArchivedByActorID;
        _ = this.Attributes;
        _ = this.CreatedAt;
        _ = this.CreatedByActorID;
        _ = this.Description;
        _ = this.IssuerID;
        _ = this.IssuerName;
        this.Match.Validate();
        _ = this.Name;
        _ = this.OAuthScope;
        this.Target.Validate();
        _ = this.TokenLifetimeSeconds;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("federation_rule"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UpdatedByActorID;
        _ = this.WorkspaceID;
        _ = this.WorkspaceIds;
    }

    public BetaFederationRule()
    {
        this.Type = JsonSerializer.SerializeToElement("federation_rule");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFederationRule(BetaFederationRule betaFederationRule)
        : base(betaFederationRule) { }
#pragma warning restore CS8618

    public BetaFederationRule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("federation_rule");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFederationRule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFederationRuleFromRaw.FromRawUnchecked"/>
    public static BetaFederationRule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFederationRuleFromRaw : IFromRawJson<BetaFederationRule>
{
    /// <inheritdoc/>
    public BetaFederationRule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFederationRule.FromRawUnchecked(rawData);
}
