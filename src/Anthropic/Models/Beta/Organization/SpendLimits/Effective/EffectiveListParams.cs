using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits.Effective;

/// <summary>
/// List each member's effective spend limit and period-to-date spend.
///
/// <para>Returns one row per (member, period) the member resolves a spend limit
/// for, with the `source` scope the spend limit was inherited from. Paginates by
/// member, so a member's periods never split across pages.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EffectiveListParams : ParamsBase
{
    /// <summary>
    /// Maximum number of members per page. A member's period rows never split across
    /// pages, so a page may carry more rows than this. Defaults to `20`.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
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
    /// Opaque cursor from a previous response's `next_page` field.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init { this._rawQueryData.Set("page", value); }
    }

    /// <summary>
    /// Restrict the report to these limit periods. Omit to return one row per period
    /// each member resolves a spend limit for.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Period>>? Period
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Period>>>(
                "period"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Period>>?>(
                "period",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Restrict the report to these members, by tagged user ID (`user_...`). At
    /// most 100 entries.
    /// </summary>
    public IReadOnlyList<string>? UserIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("user_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "user_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public EffectiveListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EffectiveListParams(EffectiveListParams effectiveListParams)
        : base(effectiveListParams) { }
#pragma warning restore CS8618

    public EffectiveListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EffectiveListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EffectiveListParams FromRawUnchecked(
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

    public virtual bool Equals(EffectiveListParams? other)
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
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/spend_limits/effective"
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

[JsonConverter(typeof(PeriodConverter))]
public enum Period
{
    Daily,
    Monthly,
    Weekly,
}

sealed class PeriodConverter : JsonConverter<Period>
{
    public override Period Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => Period.Daily,
            "monthly" => Period.Monthly,
            "weekly" => Period.Weekly,
            _ => (Period)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Period value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Period.Daily => "daily",
                Period.Monthly => "monthly",
                Period.Weekly => "weekly",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
