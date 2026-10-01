using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.Memories;
using Anthropic.Services.Beta.MemoryStores;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// List memory versions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryVersionListParams : ParamsBase
{
    public string? MemoryStoreID { get; init; }

    /// <summary>
    /// Return only versions written with the API key that has this ID.
    /// </summary>
    public string? ApiKeyID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("api_key_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("api_key_id", value);
        }
    }

    /// <summary>
    /// Return versions created at or after this time (inclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gte]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[gte]", value);
        }
    }

    /// <summary>
    /// Return versions created at or before this time (inclusive).
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lte]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[lte]", value);
        }
    }

    /// <summary>
    /// The maximum number of versions to return per page. Defaults to 20.
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
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Return only versions of the memory with this ID (`mem_...`).
    ///
    /// <para>The filter still works after the memory is deleted. The results then
    /// include the version whose `operation` is `deleted`.</para>
    /// </summary>
    public string? MemoryID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("memory_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("memory_id", value);
        }
    }

    /// <summary>
    /// Return only versions that record this kind of change.
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>? Operation
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
            >("operation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("operation", value);
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
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Return only versions written by the service account with this ID (`svac_...`).
    /// </summary>
    public string? ServiceAccountID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("service_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("service_account_id", value);
        }
    }

    /// <summary>
    /// Return only versions written by the session with this ID.
    /// </summary>
    public string? SessionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("session_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("session_id", value);
        }
    }

    /// <summary>
    /// Selects which projection of a `memory` or `memory_version` the server returns.
    /// `basic` returns the object with `content` set to `null`; `full` populates
    /// `content`. When omitted, the default is endpoint-specific: retrieve operations
    /// default to `full`; list, create, and update operations default to `basic`.
    /// Listing with `view=full` caps `limit` at 20.
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
                return;
            }

            this._rawQueryData.Set("view", value);
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

    public MemoryVersionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryVersionListParams(MemoryVersionListParams memoryVersionListParams)
        : base(memoryVersionListParams)
    {
        this.MemoryStoreID = memoryVersionListParams.MemoryStoreID;
    }
#pragma warning restore CS8618

    public MemoryVersionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryVersionListParams(
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
    public static MemoryVersionListParams FromRawUnchecked(
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

    public virtual bool Equals(MemoryVersionListParams? other)
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
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/memory_stores/{0}/memory_versions",
                    ParamsBase.EncodePathSegment(this.MemoryStoreID, nameof(this.MemoryStoreID))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        MemoryVersionService.AddDefaultHeaders(request);
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
