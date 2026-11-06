using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// Sign a member out of Claude everywhere, without removing them from the organization.
/// This ends their sign-in sessions and removes their trusted devices wherever they
/// use Claude, including other organizations and individual plans. It also ends
/// the OAuth tokens issued to them for this organization, so apps such as Claude
/// Code must sign in again.
///
/// <para>A token can take up to an hour to stop working, though it almost always
/// stops at once. The member keeps their role and can sign in again right away.
/// To keep them out, remove them from the organization or, if your organization uses
/// single sign-on, block them in your identity provider. Signing out does not end
/// API keys, OAuth tokens that were not issued for this organization, or the member's
/// Claude Code cloud sessions and routines.</para>
///
/// <para>You cannot sign out the organization's primary owner or the person your
/// API key or token acts for, and a request to sign out another owner, a member
/// with owner permissions, or a membership admin may be refused. A refused request
/// returns a `400` or `403` error that says why. If the request returns `503`, send
/// it again to finish; anything already ended stays ended.</para>
///
/// <para>Every request must include the beta header `anthropic-beta: admin-user-sign-out-2026-10-08`.
/// A request without it returns `400`. Sign-out is in beta for Claude Enterprise
/// organizations. In an organization where it is not enabled, a request returns
/// `400` with `error_code` `organization_not_enrolled_in_beta`. In a Claude Enterprise
/// organization, an API key needs the `write:members` scope; a key without it gets `403`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserSignOutParams : ParamsBase
{
    public string? UserID { get; init; }

    /// <summary>
    /// This endpoint is in beta: requests must send `admin-user-sign-out-2026-10-08`
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

    public UserSignOutParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserSignOutParams(UserSignOutParams userSignOutParams)
        : base(userSignOutParams)
    {
        this.UserID = userSignOutParams.UserID;
    }
#pragma warning restore CS8618

    public UserSignOutParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserSignOutParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string userID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.UserID = userID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserSignOutParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string userID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            userID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(UserSignOutParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.UserID?.Equals(other.UserID) ?? other.UserID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/users/{0}/sign_out",
                    ParamsBase.EncodePathSegment(this.UserID, nameof(this.UserID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/users/{user_id}/sign_out";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("anthropic-beta", "admin-user-sign-out-2026-10-08");
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
