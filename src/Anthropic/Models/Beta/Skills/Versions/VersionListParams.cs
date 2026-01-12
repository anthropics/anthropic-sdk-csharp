using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Skills;

namespace Anthropic.Models.Beta.Skills.Versions;

/// <summary>
/// List Skill Versions
/// </summary>
public sealed record class VersionListParams : ParamsBase
{
    public string? SkillID { get; init; }

    /// <summary>
    /// Number of items to return per page.
    ///
    /// <para>Defaults to `20`. Ranges from `1` to `1000`.</para>
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init { JsonModel.Set(this._rawQueryData, "limit", value); }
    }

    /// <summary>
    /// Optionally set to the `next_page` token from the previous response.
    /// </summary>
    public string? Page
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "page"); }
        init { JsonModel.Set(this._rawQueryData, "page", value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, AnthropicBeta>>>(
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

            JsonModel.Set(this._rawHeaderData, "anthropic-beta", value);
        }
    }

    public VersionListParams() { }

    public VersionListParams(VersionListParams versionListParams)
        : base(versionListParams) { }

    public VersionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static VersionListParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/skills/{0}/versions?beta=true", this.SkillID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        VersionService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
