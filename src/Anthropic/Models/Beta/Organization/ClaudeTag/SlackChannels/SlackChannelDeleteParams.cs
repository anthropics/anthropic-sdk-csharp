using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

/// <summary>
/// Remove a Slack channel from Claude Tag. This deletes the channel's stored settings
/// and its Bundle Targets at once, and then, in the background, the channel's sessions
/// and their transcripts, its memory, its routines and the artifacts published from
/// it. None of it can be restored. The channel in Slack and its messages are unchanged.
/// The request is refused with 400 and `error.details.error_code` `slack_channel_enabled`
/// while `enabled` resolves to `true` for the channel, as a read with `include_inherited=true`
/// returns it: set `enabled` to `false` on the channel first. This guards against
/// removing a channel in use by mistake; it is not a way to keep Claude out, because
/// the removal deletes the channel's own `enabled: false` with its other settings,
/// after which the channel inherits again and Claude's next use of it can set it
/// up anew with a new identifier. The identifier returns 404 as soon as the request
/// returns, so a repeated removal returns 404. A group direct message returns 400,
/// and so does a channel that holds configuration this API does not manage.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SlackChannelDeleteParams : ParamsBase
{
    public string? ID { get; init; }

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

    public SlackChannelDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SlackChannelDeleteParams(SlackChannelDeleteParams slackChannelDeleteParams)
        : base(slackChannelDeleteParams)
    {
        this.ID = slackChannelDeleteParams.ID;
    }
#pragma warning restore CS8618

    public SlackChannelDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackChannelDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SlackChannelDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(SlackChannelDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/claude_tag/slack_channels/{0}",
                    ParamsBase.EncodePathSegment(this.ID, nameof(this.ID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/claude_tag/slack_channels/{id}";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        SlackChannelService.AddDefaultHeaders(request);
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
