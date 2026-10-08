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

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// List the organization's spend limits.
///
/// <para>A Claude Console organization's limits come in an order that is stable
/// across pages. A Claude Enterprise organization's are grouped by scope type, in
/// the order `organization`, `seat_tier`, `rbac_group`, `organization_service`,
/// `user`; within a type they come in a fixed order that is not creation order. Listing
/// Claude Console limits is in an early access preview. To request access, contact
/// your Anthropic account team.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpendLimitListParams : ParamsBase
{
    /// <summary>
    /// Maximum number of limits per page. Defaults to `20`.
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
                this._rawQueryData.Remove("limit");
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
    /// Return only limits with these scope types. A Claude Console organization has
    /// `organization` and `workspace` limits; a Claude Enterprise organization has
    /// `organization`, `seat_tier`, `rbac_group`, `organization_service` and `user`
    /// limits. Omit for all.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ScopeType>>? ScopeType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, ScopeType>>>(
                "scope_type"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, ScopeType>>?>(
                "scope_type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `spend-limit-reads-2026-09-26`
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

    public SpendLimitListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitListParams(SpendLimitListParams spendLimitListParams)
        : base(spendLimitListParams) { }
#pragma warning restore CS8618

    public SpendLimitListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpendLimitListParams FromRawUnchecked(
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

    public virtual bool Equals(SpendLimitListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/spend_limits"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("anthropic-beta", "spend-limit-reads-2026-09-26");
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

[JsonConverter(typeof(ScopeTypeConverter))]
public enum ScopeType
{
    Organization,
    OrganizationService,
    RbacGroup,
    SeatTier,
    User,
    Workspace,
}

sealed class ScopeTypeConverter : JsonConverter<ScopeType>
{
    public override ScopeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => ScopeType.Organization,
            "organization_service" => ScopeType.OrganizationService,
            "rbac_group" => ScopeType.RbacGroup,
            "seat_tier" => ScopeType.SeatTier,
            "user" => ScopeType.User,
            "workspace" => ScopeType.Workspace,
            _ => (ScopeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScopeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScopeType.Organization => "organization",
                ScopeType.OrganizationService => "organization_service",
                ScopeType.RbacGroup => "rbac_group",
                ScopeType.SeatTier => "seat_tier",
                ScopeType.User => "user",
                ScopeType.Workspace => "workspace",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
