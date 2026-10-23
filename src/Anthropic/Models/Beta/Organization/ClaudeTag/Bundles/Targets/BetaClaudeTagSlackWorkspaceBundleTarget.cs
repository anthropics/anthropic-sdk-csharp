using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// One Bundle attached to one Slack workspace. The Bundle can be used in the workspace
/// and in every channel in it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackWorkspaceBundleTarget,
        BetaClaudeTagSlackWorkspaceBundleTargetFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackWorkspaceBundleTarget : JsonModel
{
    /// <summary>
    /// The Bundle Target's identifier. Starts with `btgt_`. No two Bundle Targets
    /// have the same one, and the same Bundle and target always give the same one,
    /// also after a detach and a new attach. It is opaque.
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
    /// Time the Bundle was attached.
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
    /// The identifier of the Slack workspace the Bundle is attached to, starting
    /// with `slws_`.
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.SlackWorkspaceID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("slack_workspace"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagSlackWorkspaceBundleTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceBundleTarget(
        BetaClaudeTagSlackWorkspaceBundleTarget betaClaudeTagSlackWorkspaceBundleTarget
    )
        : base(betaClaudeTagSlackWorkspaceBundleTarget) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackWorkspaceBundleTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("slack_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackWorkspaceBundleTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackWorkspaceBundleTargetFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackWorkspaceBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeTagSlackWorkspaceBundleTargetFromRaw
    : IFromRawJson<BetaClaudeTagSlackWorkspaceBundleTarget>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackWorkspaceBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackWorkspaceBundleTarget.FromRawUnchecked(rawData);
}
