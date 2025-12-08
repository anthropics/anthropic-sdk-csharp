using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Skills;

/// <summary>
/// List Skills
/// </summary>
public sealed record class SkillListParams : ParamsBase
{
    /// <summary>
    /// Number of results to return per page.
    ///
    /// <para>Maximum value is 100. Defaults to 20.</para>
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// Pagination token for fetching a specific page of results.
    ///
    /// <para>Pass the value from a previous response's `next_page` field to get the
    /// next page of results.</para>
    /// </summary>
    public string? Page
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "page"); }
        init { ModelBase.Set(this._rawQueryData, "page", value); }
    }

    /// <summary>
    /// Filter skills by source.
    ///
    /// <para>If provided, only skills from the specified source will be returned:
    /// * `"custom"`: only return user-created skills * `"anthropic"`: only return
    /// Anthropic-created skills</para>
    /// </summary>
    public string? Source
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "source"); }
        init { ModelBase.Set(this._rawQueryData, "source", value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, AnthropicBeta>>>(
                this.RawHeaderData,
                "anthropic-beta"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawHeaderData, "anthropic-beta", value);
        }
    }

    public SkillListParams() { }

    public SkillListParams(SkillListParams skillListParams)
        : base(skillListParams) { }

    public SkillListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static SkillListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/skills?beta=true")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        SkillService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
