using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.MemoryStores;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// List memories
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryListParams : ParamsBase
{
    public string? MemoryStoreID { get; init; }

    /// <summary>
    /// Query parameter for depth
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
                return;
            }

            this._rawQueryData.Set("depth", value);
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
    /// Query parameter for order
    /// </summary>
    public ApiEnum<string, Order>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Order>>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("order", value);
        }
    }

    /// <summary>
    /// Query parameter for order_by
    /// </summary>
    public string? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("order_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("order_by", value);
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
    /// Optional path prefix filter (raw string-prefix match; include a trailing
    /// slash for directory-scoped lists). This value appears in request URLs. Do
    /// not include secrets or personally identifiable information.
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
                return;
            }

            this._rawQueryData.Set("path_prefix", value);
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

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/memory_stores/{0}/memories", this.MemoryStoreID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

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

/// <summary>
/// Query parameter for order
/// </summary>
[JsonConverter(typeof(OrderConverter))]
public enum Order
{
    Asc,
    Desc,
}

sealed class OrderConverter : JsonConverter<Order>
{
    public override Order Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => Order.Asc,
            "desc" => Order.Desc,
            _ => (Order)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Order.Asc => "asc",
                Order.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
