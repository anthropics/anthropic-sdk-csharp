using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// Send your conclusion on a review case. A response closes the case, and a closed
/// case can't be reopened.
///
/// <para>Only the first response counts. A request is safe to send again: if the
/// closed case has a response with the same field values, in any list order, the
/// API returns 200 and changes nothing. If the closed case has a different response,
/// or none, the API returns a 400 with `case_closed` in `error.details.error_code`.</para>
///
/// <para>If your end customer reviews this case instead of you, the API returns a
/// 403 with `case_reviewed_by_end_customer` in `error.details.error_code`.</para>
///
/// <para>An Admin API key with the `write:compliance_review_cases` scope can call
/// this endpoint.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CaseRespondParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CaseID { get; init; }

    /// <summary>
    /// Your conclusion on the case as a whole. Anthropic doesn't check it against `verdicts`.
    /// </summary>
    public required ApiEnum<string, BetaComplianceReviewDetermination> Determination
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, BetaComplianceReviewDetermination>
            >("determination");
        }
        init { this._rawBodyData.Set("determination", value); }
    }

    /// <summary>
    /// The policy categories that you found were violated. Send one to four with
    /// `violation`, and none with `no_violation`. They need not match the case's
    /// own. Each value is one of `cyber`, `bio`, `chem`, `radnuc` (radiological or
    /// nuclear weapons), `cgw` (conventional weapons), `mgw` (military-grade weapons
    /// systems), `io` (influence operations), `fraud`, `violent_extremism`, `surveillance`,
    /// `human_exploitation`, `self_harm`, `adult_content`, `reasoning_extraction`,
    /// `frontier_llm` (use of the model to accelerate frontier AI research and development
    /// in restricted ways), `compromised_key` or `other`, and can appear once.
    /// </summary>
    public IReadOnlyList<
        ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
    >? PolicyCategories
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>>
            >("policy_categories");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("policy_categories");
                return;
            }

            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, BetaComplianceReviewViolatedPolicyCategory>
            >?>("policy_categories", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Your conclusions on individual messages of the case. They need not cover
    /// every message, and each `item_id` can appear once.
    /// </summary>
    public IReadOnlyList<BetaComplianceReviewVerdictParam>? Verdicts
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<BetaComplianceReviewVerdictParam>
            >("verdicts");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("verdicts");
                return;
            }

            this._rawBodyData.Set<ImmutableArray<BetaComplianceReviewVerdictParam>?>(
                "verdicts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CaseRespondParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CaseRespondParams(CaseRespondParams caseRespondParams)
        : base(caseRespondParams)
    {
        this.CaseID = caseRespondParams.CaseID;

        this._rawBodyData = new(caseRespondParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CaseRespondParams(
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
    CaseRespondParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string caseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CaseID = caseID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CaseRespondParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string caseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            caseID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CaseID"] = JsonSerializer.SerializeToElement(this.CaseID),
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

    public virtual bool Equals(CaseRespondParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CaseID?.Equals(other.CaseID) ?? other.CaseID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/compliance/review/cases/{0}/respond",
                    ParamsBase.EncodePathSegment(this.CaseID, nameof(this.CaseID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/compliance/review/cases/{case_id}/respond";

    internal override HttpContent? BodyContent()
    {
        return ParamsBase.JsonBodyContent(this.RawBodyData);
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
