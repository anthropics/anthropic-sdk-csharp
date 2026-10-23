using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

/// <summary>
/// List the set-up Slack workspaces the organization owns, newest first by `created_at`.
/// Pass `slack_workspace_id` to look one workspace up by its Slack identifier: `data`
/// then holds that workspace, or is empty when it is not set up. A workspace of
/// a Slack Enterprise Grid the organization has connected returns 404 until it is
/// set up. With `include_inherited=true` each workspace's `settings` holds what
/// applies in it, and the request fails with 503 rather than resolve against a settings
/// level that could not be read. A `page` cursor resumes only a request with the
/// same `include_inherited`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SlackWorkspaceListParams : ParamsBase
{
    /// <summary>
    /// When `true`, `settings` holds what applies in each workspace once the organization's
    /// Slack defaults are taken into account, and every member of `sources` names
    /// the level a value comes from. When `false` or left out, `settings` holds what
    /// each workspace itself stores.
    /// </summary>
    public bool? IncludeInherited
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_inherited");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("include_inherited");
                return;
            }

            this._rawQueryData.Set("include_inherited", value);
        }
    }

    /// <summary>
    /// Number of items to return per page, between 1 and 100. Defaults to 20.
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
                this._rawQueryData.Remove("limit");
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
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
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("page");
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Slack's identifier for one workspace, as in the workspace object's `slack.workspace_id`,
    /// not its `id`. With it `data` holds that workspace alone, or nothing when
    /// it is not set up.
    /// </summary>
    public string? SlackWorkspaceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("slack_workspace_id");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("slack_workspace_id");
                return;
            }

            this._rawQueryData.Set("slack_workspace_id", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `experimental-claude-tag-2026-10-21`
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

    public SlackWorkspaceListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SlackWorkspaceListParams(SlackWorkspaceListParams slackWorkspaceListParams)
        : base(slackWorkspaceListParams) { }
#pragma warning restore CS8618

    public SlackWorkspaceListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackWorkspaceListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SlackWorkspaceListParams FromRawUnchecked(
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

    public virtual bool Equals(SlackWorkspaceListParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + "/v1/organizations/claude_tag/slack_workspaces"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/claude_tag/slack_workspaces";

    internal override IReadOnlyList<string> QueryParams =>
        ["include_inherited", "limit", "page", "slack_workspace_id"];

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        SlackWorkspaceService.AddDefaultHeaders(request);
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
