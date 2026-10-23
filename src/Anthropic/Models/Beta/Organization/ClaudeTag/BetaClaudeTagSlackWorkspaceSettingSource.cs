using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The value comes from a Slack workspace of the organization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackWorkspaceSettingSource,
        BetaClaudeTagSlackWorkspaceSettingSourceFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackWorkspaceSettingSource : JsonModel
{
    /// <summary>
    /// The workspace's identifier, starting with `slws_`.
    /// </summary>
    public required string SlackWorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slack_workspace_id");
        }
        init { this._rawData.Set("slack_workspace_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SlackWorkspaceID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_workspace"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackWorkspaceSettingSource()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceSettingSource(
        BetaClaudeTagSlackWorkspaceSettingSource betaClaudeTagSlackWorkspaceSettingSource
    )
        : base(betaClaudeTagSlackWorkspaceSettingSource) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackWorkspaceSettingSource(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackWorkspaceSettingSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackWorkspaceSettingSourceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackWorkspaceSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceSettingSource(string slackWorkspaceID)
        : this()
    {
        this.SlackWorkspaceID = slackWorkspaceID;
    }
}

class BetaClaudeTagSlackWorkspaceSettingSourceFromRaw
    : IFromRawJson<BetaClaudeTagSlackWorkspaceSettingSource>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackWorkspaceSettingSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackWorkspaceSettingSource.FromRawUnchecked(rawData);
}
