using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RbacGroups.Members;

/// <summary>
/// Remove a User from an RBAC Group. Membership of groups provisioned by an identity
/// provider (source type `"scim"`) cannot be modified via the API while an organization
/// in the tenant uses SCIM provisioning.
///
/// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemberRemoveParams : ParamsBase
{
    public required string RbacGroupID { get; init; }

    public string? UserID { get; init; }

    public MemberRemoveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemberRemoveParams(MemberRemoveParams memberRemoveParams)
        : base(memberRemoveParams)
    {
        this.RbacGroupID = memberRemoveParams.RbacGroupID;
        this.UserID = memberRemoveParams.UserID;
    }
#pragma warning restore CS8618

    public MemberRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemberRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string rbacGroupID,
        string userID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RbacGroupID = rbacGroupID;
        this.UserID = userID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MemberRemoveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string rbacGroupID,
        string userID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rbacGroupID,
            userID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RbacGroupID"] = JsonSerializer.SerializeToElement(this.RbacGroupID),
                    ["UserID"] = JsonSerializer.SerializeToElement(this.UserID),
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

    public virtual bool Equals(MemberRemoveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RbacGroupID.Equals(other.RbacGroupID)
            && (this.UserID?.Equals(other.UserID) ?? other.UserID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/rbac_groups/{0}/members/{1}",
                    ParamsBase.EncodePathSegment(this.RbacGroupID, nameof(this.RbacGroupID)),
                    ParamsBase.EncodePathSegment(this.UserID, nameof(this.UserID))
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
