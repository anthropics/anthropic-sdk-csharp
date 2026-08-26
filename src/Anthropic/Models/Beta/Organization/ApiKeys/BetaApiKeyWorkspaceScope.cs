using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ApiKeys;

[JsonConverter(
    typeof(JsonModelConverter<BetaApiKeyWorkspaceScope, BetaApiKeyWorkspaceScopeFromRaw>)
)]
public sealed record class BetaApiKeyWorkspaceScope : JsonModel
{
    /// <summary>
    /// Scope type. Always `"workspace"`: the API key belongs to one Workspace.
    /// </summary>
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
    /// ID of the Workspace the API key belongs to. Unlike the deprecated top-level
    /// `workspace_id`, this is the Workspace's real ID even for the organization's
    /// default Workspace.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("workspace")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaApiKeyWorkspaceScope()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaApiKeyWorkspaceScope(BetaApiKeyWorkspaceScope betaApiKeyWorkspaceScope)
        : base(betaApiKeyWorkspaceScope) { }
#pragma warning restore CS8618

    public BetaApiKeyWorkspaceScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApiKeyWorkspaceScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiKeyWorkspaceScopeFromRaw.FromRawUnchecked"/>
    public static BetaApiKeyWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaApiKeyWorkspaceScope(string workspaceID)
        : this()
    {
        this.WorkspaceID = workspaceID;
    }
}

class BetaApiKeyWorkspaceScopeFromRaw : IFromRawJson<BetaApiKeyWorkspaceScope>
{
    /// <inheritdoc/>
    public BetaApiKeyWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaApiKeyWorkspaceScope.FromRawUnchecked(rawData);
}
