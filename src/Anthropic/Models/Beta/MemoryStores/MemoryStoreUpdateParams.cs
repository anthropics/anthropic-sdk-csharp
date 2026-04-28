using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.MemoryStores;

/// <summary>
/// Update a memory store
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryStoreUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? MemoryStoreID { get; init; }

    /// <summary>
    /// New description for the store, up to 1024 characters. Pass an empty string
    /// to clear it.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Metadata patch. Set a key to a string to upsert it, or to null to delete
    /// it. Omit the field to preserve. The stored bag is limited to 16 keys (up to
    /// 64 chars each) with values up to 512 chars.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// New human-readable name for the store. 1–255 characters; no control characters.
    /// Renaming changes the slug used for the store's `mount_path` in sessions created
    /// after the update.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
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

    public MemoryStoreUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryStoreUpdateParams(MemoryStoreUpdateParams memoryStoreUpdateParams)
        : base(memoryStoreUpdateParams)
    {
        this.MemoryStoreID = memoryStoreUpdateParams.MemoryStoreID;

        this._rawBodyData = new(memoryStoreUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MemoryStoreUpdateParams(
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
    MemoryStoreUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string memoryStoreID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.MemoryStoreID = memoryStoreID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MemoryStoreUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string memoryStoreID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MemoryStoreUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MemoryStoreID?.Equals(other.MemoryStoreID) ?? other.MemoryStoreID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/memory_stores/{0}", this.MemoryStoreID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

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
        MemoryStoreService.AddDefaultHeaders(request);
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
