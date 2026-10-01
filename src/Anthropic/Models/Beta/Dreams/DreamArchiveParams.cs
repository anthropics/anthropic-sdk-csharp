using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Hide a `completed`, `failed`, or `canceled` dream from the default list of dreams.
///
/// <para>Archiving a `pending` or `running` dream returns a 400 error, so cancel
/// it first. Archiving an archived dream returns it unchanged. An archived dream
/// can still be fetched by ID. Archiving can't be undone.</para>
///
/// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#archive-a-dream)
/// to learn more about archiving dreams.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DreamArchiveParams : ParamsBase
{
    public string? DreamID { get; init; }

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

    /// <summary>
    /// Optional header to select the Workspace for this request. The value is a Workspace
    /// ID (for example, `wrkspc_011CZkZaBF1tNoB5wlCeusgy`).
    ///
    /// <para>Only needed for credentials that can act on more than one Workspace.
    /// A credential that belongs to a specific Workspace may omit it; if sent, it
    /// must match that Workspace.</para>
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("anthropic-workspace-id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("anthropic-workspace-id", value);
        }
    }

    public DreamArchiveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DreamArchiveParams(DreamArchiveParams dreamArchiveParams)
        : base(dreamArchiveParams)
    {
        this.DreamID = dreamArchiveParams.DreamID;
    }
#pragma warning restore CS8618

    public DreamArchiveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DreamArchiveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string dreamID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.DreamID = dreamID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DreamArchiveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string dreamID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            dreamID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DreamID"] = JsonSerializer.SerializeToElement(this.DreamID),
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

    public virtual bool Equals(DreamArchiveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.DreamID?.Equals(other.DreamID) ?? other.DreamID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/dreams/{0}/archive",
                    ParamsBase.EncodePathSegment(this.DreamID, nameof(this.DreamID))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        DreamService.AddDefaultHeaders(request);
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
