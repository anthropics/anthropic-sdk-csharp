using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

[JsonConverter(
    typeof(JsonModelConverter<
        SlackWorkspaceListPageResponse,
        SlackWorkspaceListPageResponseFromRaw
    >)
)]
public sealed record class SlackWorkspaceListPageResponse : JsonModel
{
    /// <summary>
    /// Workspaces on this page, newest first.
    /// </summary>
    public required IReadOnlyList<BetaClaudeTagSlackWorkspace> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaClaudeTagSlackWorkspace>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeTagSlackWorkspace>>(
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

    public SlackWorkspaceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SlackWorkspaceListPageResponse(
        SlackWorkspaceListPageResponse slackWorkspaceListPageResponse
    )
        : base(slackWorkspaceListPageResponse) { }
#pragma warning restore CS8618

    public SlackWorkspaceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackWorkspaceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SlackWorkspaceListPageResponseFromRaw.FromRawUnchecked"/>
    public static SlackWorkspaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SlackWorkspaceListPageResponseFromRaw : IFromRawJson<SlackWorkspaceListPageResponse>
{
    /// <inheritdoc/>
    public SlackWorkspaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SlackWorkspaceListPageResponse.FromRawUnchecked(rawData);
}
