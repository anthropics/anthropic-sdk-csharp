using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// Attach a Bundle to a Slack channel or a Slack workspace. A Bundle attached to
/// a workspace can be used in the workspace and in every channel in it. Attaching
/// a Bundle to a channel or workspace it is already attached to returns the existing
/// Bundle Target. The channel or workspace must be set up: attaching never sets
/// a channel up. A group direct message takes no Bundle and returns 400.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TargetCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? BundleID { get; init; }

    public required BetaClaudeTagBundleTargetCreate Target
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClass<BetaClaudeTagBundleTargetCreate>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

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

    public TargetCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetCreateParams(TargetCreateParams targetCreateParams)
        : base(targetCreateParams)
    {
        this.BundleID = targetCreateParams.BundleID;

        this.RawBodyData = targetCreateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public TargetCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string bundleID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.BundleID = bundleID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TargetCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string bundleID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            bundleID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BundleID"] = JsonSerializer.SerializeToElement(this.BundleID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TargetCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BundleID?.Equals(other.BundleID) ?? other.BundleID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/claude_tag/bundles/{0}/targets",
                    ParamsBase.EncodePathSegment(this.BundleID, nameof(this.BundleID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/claude_tag/bundles/{bundle_id}/targets";

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
