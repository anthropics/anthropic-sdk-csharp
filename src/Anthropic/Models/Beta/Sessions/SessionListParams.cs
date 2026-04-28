using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// List Sessions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionListParams : ParamsBase
{
    /// <summary>
    /// Filter sessions created with this agent ID.
    /// </summary>
    public string? AgentID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("agent_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("agent_id", value);
        }
    }

    /// <summary>
    /// Filter by agent version. Only applies when agent_id is also set.
    /// </summary>
    public int? AgentVersion
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("agent_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("agent_version", value);
        }
    }

    /// <summary>
    /// Return sessions created after this time (exclusive).
    /// </summary>
    public System::DateTimeOffset? CreatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gt]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[gt]", value);
        }
    }

    /// <summary>
    /// Return sessions created at or after this time (inclusive).
    /// </summary>
    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gte]");
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
    /// Return sessions created before this time (exclusive).
    /// </summary>
    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lt]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at[lt]", value);
        }
    }

    /// <summary>
    /// Return sessions created at or before this time (inclusive).
    /// </summary>
    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lte]");
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
    /// When true, includes archived sessions. Default: false (exclude archived).
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
                return;
            }

            this._rawQueryData.Set("include_archived", value);
        }
    }

    /// <summary>
    /// Maximum number of results to return.
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
    /// Filter sessions whose resources contain a memory_store with this memory store ID.
    /// </summary>
    public string? MemoryStoreID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("memory_store_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("memory_store_id", value);
        }
    }

    /// <summary>
    /// Sort direction for results, ordered by created_at. Defaults to desc (newest first).
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
    /// Opaque pagination cursor from a previous response's next_page.
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

    public SessionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionListParams(SessionListParams sessionListParams)
        : base(sessionListParams) { }
#pragma warning restore CS8618

    public SessionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionListParams FromRawUnchecked(
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

    public virtual bool Equals(SessionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/sessions")
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        SessionService.AddDefaultHeaders(request);
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
/// Sort direction for results, ordered by created_at. Defaults to desc (newest first).
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
