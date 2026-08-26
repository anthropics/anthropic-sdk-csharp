using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Rules;

/// <summary>
/// Does the incoming JWT qualify?
///
/// <para>All populated fields must pass; omitted fields are skipped. At least one
/// of `subject_prefix` (other than a wildcard-only value like `*`), `claims`, or
/// `condition` is required; `audience` alone is not sufficient.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFederationRuleMatch, BetaFederationRuleMatchFromRaw>))]
public sealed record class BetaFederationRuleMatch : JsonModel
{
    /// <summary>
    /// Exact match against the `aud` claim (any element if array). When omitted,
    /// the JWT's `aud` must still equal Anthropic's expected audience for the issuer;
    /// setting this field overrides that default.
    /// </summary>
    public string? Audience
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("audience");
        }
        init { this._rawData.Set("audience", value); }
    }

    /// <summary>
    /// Exact-match `{claim: value}` pairs against top-level claims. Only string-valued
    /// claims can be matched; use `condition` for non-string claims.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Claims
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("claims");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "claims",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// CEL expression over claims for logic the structural fields can't express.
    /// Must evaluate to a boolean and may reference only the `claims` variable; a
    /// constant-true expression (such as `true`) is rejected with 400.
    /// </summary>
    public string? Condition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("condition");
        }
        init { this._rawData.Set("condition", value); }
    }

    /// <summary>
    /// Match the verified JWT `sub` claim. Exact match unless the value ends with
    /// `*`, in which case it is a prefix match. Example: `repo:my-org/my-repo:ref:refs/heads/main`.
    /// </summary>
    public string? SubjectPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject_prefix");
        }
        init { this._rawData.Set("subject_prefix", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Audience;
        _ = this.Claims;
        _ = this.Condition;
        _ = this.SubjectPrefix;
    }

    public BetaFederationRuleMatch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFederationRuleMatch(BetaFederationRuleMatch betaFederationRuleMatch)
        : base(betaFederationRuleMatch) { }
#pragma warning restore CS8618

    public BetaFederationRuleMatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFederationRuleMatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFederationRuleMatchFromRaw.FromRawUnchecked"/>
    public static BetaFederationRuleMatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFederationRuleMatchFromRaw : IFromRawJson<BetaFederationRuleMatch>
{
    /// <inheritdoc/>
    public BetaFederationRuleMatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFederationRuleMatch.FromRawUnchecked(rawData);
}
