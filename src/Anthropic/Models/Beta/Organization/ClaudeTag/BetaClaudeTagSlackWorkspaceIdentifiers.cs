using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The identifier Slack shows for a workspace. It is Slack's own, not an identifier
/// of this API.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagSlackWorkspaceIdentifiers,
        BetaClaudeTagSlackWorkspaceIdentifiersFromRaw
    >)
)]
public sealed record class BetaClaudeTagSlackWorkspaceIdentifiers : JsonModel
{
    /// <summary>
    /// Slack's identifier for the workspace, starting with `T`, such as `T0123ABCD`.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WorkspaceID;
    }

    public BetaClaudeTagSlackWorkspaceIdentifiers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceIdentifiers(
        BetaClaudeTagSlackWorkspaceIdentifiers betaClaudeTagSlackWorkspaceIdentifiers
    )
        : base(betaClaudeTagSlackWorkspaceIdentifiers) { }
#pragma warning restore CS8618

    public BetaClaudeTagSlackWorkspaceIdentifiers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagSlackWorkspaceIdentifiers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagSlackWorkspaceIdentifiersFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagSlackWorkspaceIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagSlackWorkspaceIdentifiers(string workspaceID)
        : this()
    {
        this.WorkspaceID = workspaceID;
    }
}

class BetaClaudeTagSlackWorkspaceIdentifiersFromRaw
    : IFromRawJson<BetaClaudeTagSlackWorkspaceIdentifiers>
{
    /// <inheritdoc/>
    public BetaClaudeTagSlackWorkspaceIdentifiers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagSlackWorkspaceIdentifiers.FromRawUnchecked(rawData);
}
