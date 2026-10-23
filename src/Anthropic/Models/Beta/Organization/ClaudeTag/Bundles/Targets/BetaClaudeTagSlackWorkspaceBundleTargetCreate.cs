using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// Attach the Bundle to a Slack workspace.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackWorkspaceBundleTargetCreate,
        BetaClaudeTagSlackWorkspaceBundleTargetCreateFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackWorkspaceBundleTargetCreate : JsonModel
{
    /// <summary>
    /// The identifier of the Slack workspace to attach the Bundle to, starting with `slws_`.
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

    public BetaClaudeTagSlackWorkspaceBundleTargetCreate()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceBundleTargetCreate(
        BetaClaudeTagSlackWorkspaceBundleTargetCreate betaClaudeTagSlackWorkspaceBundleTargetCreate
    )
        : base(betaClaudeTagSlackWorkspaceBundleTargetCreate) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackWorkspaceBundleTargetCreate(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackWorkspaceBundleTargetCreate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackWorkspaceBundleTargetCreateFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackWorkspaceBundleTargetCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceBundleTargetCreate(string slackWorkspaceID)
        : this()
    {
        this.SlackWorkspaceID = slackWorkspaceID;
    }
}

class BetaClaudeTagSlackWorkspaceBundleTargetCreateFromRaw
    : IFromRawJson<BetaClaudeTagSlackWorkspaceBundleTargetCreate>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackWorkspaceBundleTargetCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackWorkspaceBundleTargetCreate.FromRawUnchecked(rawData);
}
