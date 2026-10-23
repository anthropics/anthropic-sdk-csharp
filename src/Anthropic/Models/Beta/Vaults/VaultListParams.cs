using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Vaults;

/// <summary>
/// List Vaults
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VaultListParams : ParamsBase
{
    /// <summary>
    /// Whether to include archived vaults in the results. Defaults to `false`.
    /// </summary>
    public bool? IncludeArchived
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_archived");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("include_archived");
                return;
            }

            this._rawQueryData.Set("include_archived", value);
        }
    }

    /// <summary>
    /// Maximum number of vaults to return per page. Defaults to 20, maximum 100.
    /// </summary>
    public int? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("limit");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("limit");
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// The `next_page` value from a previous [List Vaults](https://platform.claude.com/docs/en/api/beta/vaults/list)
    /// response, to get the next page. Leave it out to get the first page.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("page");
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `managed-agents-2026-04-01` in
    /// this header.
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
                this._rawHeaderData.Remove("anthropic-workspace-id");
                return;
            }

            this._rawHeaderData.Set("anthropic-workspace-id", value);
        }
    }

    public VaultListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultListParams(VaultListParams vaultListParams)
        : base(vaultListParams) { }
#pragma warning restore CS8618

    public VaultListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VaultListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(VaultListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/vaults")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/vaults";

    internal override IReadOnlyList<string> QueryParams => ["include_archived", "limit", "page"];

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        VaultService.AddDefaultHeaders(request);
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
