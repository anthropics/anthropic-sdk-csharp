using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

/// <summary>
/// A Slack workspace the organization has connected, itself or through its Slack
/// Enterprise Grid, with the settings it stores or, with `include_inherited`, the
/// settings that apply in it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaClaudeTagSlackWorkspace, BetaClaudeTagSlackWorkspaceFromRaw>)
)]
public sealed record class BetaClaudeTagSlackWorkspace : JsonModel
{
    /// <summary>
    /// The workspace's identifier. Starts with `slws_`. It does not change for as
    /// long as the workspace is set up. A workspace that is removed and set up again
    /// has a new one, and the old one keeps returning 404; look the workspace up
    /// by its Slack identifier for the new one.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Time the workspace was set up, by whichever route. It does not change for
    /// as long as `id` does not.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// What the workspace itself stores or, with `include_inherited`, what applies
    /// in it. `sources` says which.
    /// </summary>
    public required BetaClaudeTagSettings Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSettings>("settings");
        }
        init { this._rawData.Set("settings", value); }
    }

    /// <summary>
    /// Slack's own identifier for the workspace.
    /// </summary>
    public required BetaClaudeTagSlackWorkspaceIdentifiers Slack
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSlackWorkspaceIdentifiers>("slack");
        }
        init { this._rawData.Set("slack", value); }
    }

    /// <summary>
    /// For each setting, the settings level its value in `settings` comes from.
    /// </summary>
    public required BetaClaudeTagSettingSources Sources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaClaudeTagSettingSources>("sources");
        }
        init { this._rawData.Set("sources", value); }
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

    /// <summary>
    /// Time Claude Tag's record of the workspace last changed. It moves on every
    /// change to a setting, and can also move when something no response holds changes,
    /// so a later value says to read the workspace again, not that a setting changed.
    /// Attaching or detaching a Bundle does not by itself move it.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Settings.Validate();
        this.Slack.Validate();
        this.Sources.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_workspace"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaClaudeTagSlackWorkspace()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspace(BetaClaudeTagSlackWorkspace betaClaudeTagSlackWorkspace)
        : base(betaClaudeTagSlackWorkspace) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackWorkspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackWorkspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackWorkspaceFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackWorkspaceFromRaw : IFromRawJson<BetaClaudeTagSlackWorkspace>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackWorkspace.FromRawUnchecked(rawData);
}
