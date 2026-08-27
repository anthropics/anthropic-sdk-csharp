using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

/// <summary>
/// List rate-limit overrides configured for a workspace.
///
/// <para>Returns only the groups and limiter types that have a workspace-level override.
/// Groups without overrides inherit the organization limits and are not listed; use
/// `GET /v1/organizations/rate_limits` to see those.</para>
///
/// <para>When `limit` is omitted, every matching entry is returned in a single page;
/// when `limit` truncates the result, follow `next_page` to fetch the remaining entries.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RateLimitListParams : ParamsBase
{
    public string? WorkspaceID { get; init; }

    /// <summary>
    /// Filter by group type.
    /// </summary>
    public ApiEnum<string, GroupType>? GroupType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, GroupType>>("group_type");
        }
        init { this._rawQueryData.Set("group_type", value); }
    }

    /// <summary>
    /// Maximum number of items to return per page. Ranges from `1` to `1000`.
    ///
    /// <para>When omitted, every remaining entry is returned in a single page and
    /// `next_page` is `null`.</para>
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init { this._rawQueryData.Set("limit", value); }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `next_page`.
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

    public RateLimitListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateLimitListParams(RateLimitListParams rateLimitListParams)
        : base(rateLimitListParams)
    {
        this.WorkspaceID = rateLimitListParams.WorkspaceID;
    }
#pragma warning restore CS8618

    public RateLimitListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimitListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string workspaceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.WorkspaceID = workspaceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RateLimitListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string workspaceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            workspaceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WorkspaceID"] = JsonSerializer.SerializeToElement(this.WorkspaceID),
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

    public virtual bool Equals(RateLimitListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.WorkspaceID?.Equals(other.WorkspaceID) ?? other.WorkspaceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/organizations/workspaces/{0}/rate_limits", this.WorkspaceID)
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

/// <summary>
/// Filter by group type.
/// </summary>
[JsonConverter(typeof(GroupTypeConverter))]
public enum GroupType
{
    Batch,
    Files,
    ModelGroup,
    Skills,
    TokenCount,
    WebSearch,
}

sealed class GroupTypeConverter : JsonConverter<GroupType>
{
    public override GroupType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => GroupType.Batch,
            "files" => GroupType.Files,
            "model_group" => GroupType.ModelGroup,
            "skills" => GroupType.Skills,
            "token_count" => GroupType.TokenCount,
            "web_search" => GroupType.WebSearch,
            _ => (GroupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupType.Batch => "batch",
                GroupType.Files => "files",
                GroupType.ModelGroup => "model_group",
                GroupType.Skills => "skills",
                GroupType.TokenCount => "token_count",
                GroupType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
