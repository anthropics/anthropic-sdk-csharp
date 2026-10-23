using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

/// <summary>
/// Set or clear rate-limit overrides for one rate-limit group in a workspace.
///
/// <para>Only the limiter types named in `limits` change: an integer `value` sets
/// that type's override and `null` clears it. Types not named keep their current
/// value. A value above the organization's own limit is stored, but the organization
/// limit still applies, so the lower of the two is enforced.</para>
///
/// <para>Returns the targeted group's entry with this request applied, in the shape
/// `GET /v1/organizations/workspaces/{workspace_id}/rate_limits` returns. Changes
/// take effect within about an hour.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RateLimitUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string WorkspaceID { get; init; }

    public string? RateLimitID { get; init; }

    /// <summary>
    /// Limits to set or clear. Unspecified limit types are unchanged.
    /// </summary>
    public required IReadOnlyList<BetaWorkspaceRateLimitUpdateValue> Limits
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<BetaWorkspaceRateLimitUpdateValue>
            >("limits");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BetaWorkspaceRateLimitUpdateValue>>(
                "limits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public RateLimitUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateLimitUpdateParams(RateLimitUpdateParams rateLimitUpdateParams)
        : base(rateLimitUpdateParams)
    {
        this.WorkspaceID = rateLimitUpdateParams.WorkspaceID;
        this.RateLimitID = rateLimitUpdateParams.RateLimitID;

        this._rawBodyData = new(rateLimitUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RateLimitUpdateParams(
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
    RateLimitUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string workspaceID,
        string rateLimitID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.WorkspaceID = workspaceID;
        this.RateLimitID = rateLimitID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RateLimitUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string workspaceID,
        string rateLimitID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            workspaceID,
            rateLimitID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WorkspaceID"] = JsonSerializer.SerializeToElement(this.WorkspaceID),
                    ["RateLimitID"] = JsonSerializer.SerializeToElement(this.RateLimitID),
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

    public virtual bool Equals(RateLimitUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.WorkspaceID.Equals(other.WorkspaceID)
            && (this.RateLimitID?.Equals(other.RateLimitID) ?? other.RateLimitID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/workspaces/{0}/rate_limits/{1}",
                    ParamsBase.EncodePathSegment(this.WorkspaceID, nameof(this.WorkspaceID)),
                    ParamsBase.EncodePathSegment(this.RateLimitID, nameof(this.RateLimitID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/workspaces/{workspace_id}/rate_limits/{rate_limit_id}";

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
