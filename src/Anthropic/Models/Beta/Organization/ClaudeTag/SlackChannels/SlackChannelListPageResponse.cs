using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

[JsonConverter(
    typeof(JsonModelConverter<SlackChannelListPageResponse, SlackChannelListPageResponseFromRaw>)
)]
public sealed record class SlackChannelListPageResponse : JsonModel
{
    /// <summary>
    /// Channels on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaClaudeTagSlackChannel> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaClaudeTagSlackChannel>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeTagSlackChannel>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page. Null on the last page.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public SlackChannelListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SlackChannelListPageResponse(SlackChannelListPageResponse slackChannelListPageResponse)
        : base(slackChannelListPageResponse) { }
#pragma warning restore CS8618

    public SlackChannelListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackChannelListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SlackChannelListPageResponseFromRaw.FromRawUnchecked"/>
    public static SlackChannelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SlackChannelListPageResponseFromRaw : IFromRawJson<SlackChannelListPageResponse>
{
    /// <inheritdoc/>
    public SlackChannelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SlackChannelListPageResponse.FromRawUnchecked(rawData);
}
