using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.MemoryStores;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// List Memories
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryListParams : ParamsBase
{
    public string? MemoryStoreID { get; init; }

    /// <summary>
    /// How far below `path_prefix` to list. Defaults to `0`, which lists every memory
    /// below the prefix.
    ///
    /// <para>Pass `1` to list only the direct children. Deeper memories are then
    /// grouped into `memory_prefix` items.</para>
    /// </summary>
    public int? Depth
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("depth");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("depth");
                return;
            }

            this._rawQueryData.Set("depth", value);
        }
    }

    /// <summary>
    /// The maximum number of items to return per page, from 1 to 100. Defaults to 20.
    ///
    /// <para>With `view=full`, a page holds at most 20 items. `memory` and `memory_prefix`
    /// items both count toward the limit.</para>
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
    /// The `next_page` value from a previous response, to get the next page. Omit
    /// it to get the first page.
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
    /// Return only memories whose path starts with this prefix, such as `/notes/`.
    /// This value appears in request URLs. Do not include secrets or personally
    /// identifiable information.
    ///
    /// <para>Omit it to list the whole store. The prefix must end with `/` and matches
    /// whole segments, so `/notes/` matches `/notes/todo.md` but not `/notes-archive/todo.md`.</para>
    /// </summary>
    public string? PathPrefix
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("path_prefix");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("path_prefix");
                return;
            }

            this._rawQueryData.Set("path_prefix", value);
        }
    }

    /// <summary>
    /// Whether each memory in the response includes `content`. Defaults to `basic`,
    /// which sets it to `null`.
    ///
    /// <para>With `full`, a page holds at most 20 items.</para>
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsMemoryView>? View
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsMemoryView>
            >("view");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("view");
                return;
            }

            this._rawQueryData.Set("view", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `agent-memory-2026-07-22` or
    /// `managed-agents-2026-04-01` in this header.
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

    public MemoryListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListParams(MemoryListParams memoryListParams)
        : base(memoryListParams)
    {
        this.MemoryStoreID = memoryListParams.MemoryStoreID;
    }
#pragma warning restore CS8618

    public MemoryListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string memoryStoreID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MemoryStoreID = memoryStoreID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MemoryListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string memoryStoreID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            memoryStoreID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MemoryStoreID"] = JsonSerializer.SerializeToElement(this.MemoryStoreID),
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

    public virtual bool Equals(MemoryListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MemoryStoreID?.Equals(other.MemoryStoreID) ?? other.MemoryStoreID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/memory_stores/{0}/memories",
                    ParamsBase.EncodePathSegment(this.MemoryStoreID, nameof(this.MemoryStoreID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/memory_stores/{memory_store_id}/memories";

    internal override IReadOnlyList<string> QueryParams =>
        ["depth", "limit", "page", "path_prefix", "view"];

    internal override IReadOnlyList<string> ContentQueryParams => ["page"];

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        MemoryService.AddDefaultHeaders(request);
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
