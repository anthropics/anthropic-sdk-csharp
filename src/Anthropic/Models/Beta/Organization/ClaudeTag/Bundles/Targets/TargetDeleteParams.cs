using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// Detach a Bundle from a Slack channel or a Slack workspace. A repeated detach
/// returns 404.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TargetDeleteParams : ParamsBase
{
    public required string BundleID { get; init; }

    public string? TargetID { get; init; }

    /// <summary>
    /// This endpoint is in beta: requests must send `experimental-claude-tag-2026-10-21`
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

    public TargetDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetDeleteParams(TargetDeleteParams targetDeleteParams)
        : base(targetDeleteParams)
    {
        this.BundleID = targetDeleteParams.BundleID;
        this.TargetID = targetDeleteParams.TargetID;
    }
#pragma warning restore CS8618

    public TargetDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string bundleID,
        string targetID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BundleID = bundleID;
        this.TargetID = targetID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TargetDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string bundleID,
        string targetID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            bundleID,
            targetID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BundleID"] = JsonSerializer.SerializeToElement(this.BundleID),
                    ["TargetID"] = JsonSerializer.SerializeToElement(this.TargetID),
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

    public virtual bool Equals(TargetDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.BundleID.Equals(other.BundleID)
            && (this.TargetID?.Equals(other.TargetID) ?? other.TargetID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/claude_tag/bundles/{0}/targets/{1}",
                    ParamsBase.EncodePathSegment(this.BundleID, nameof(this.BundleID)),
                    ParamsBase.EncodePathSegment(this.TargetID, nameof(this.TargetID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/claude_tag/bundles/{bundle_id}/targets/{target_id}";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        TargetService.AddDefaultHeaders(request);
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
