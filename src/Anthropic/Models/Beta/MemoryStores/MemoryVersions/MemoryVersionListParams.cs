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
/// ListMemoryVersions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryVersionListParams : ParamsBase
{
    public string? MemoryStoreID { get; init; }

    /// <summary>
    /// Query parameter for api_key_id
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
    /// Query parameter for limit
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
    /// Query parameter for memory_id
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
    /// Query parameter for operation
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
    /// Query parameter for page
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
    /// Query parameter for session_id
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
    /// Query parameter for view
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
                + string.Format("/v1/memory_stores/{0}/memory_versions", this.MemoryStoreID)
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
