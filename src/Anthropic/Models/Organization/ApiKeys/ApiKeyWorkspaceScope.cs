using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyWorkspaceScope, ApiKeyWorkspaceScopeFromRaw>))]
public sealed record class ApiKeyWorkspaceScope : JsonModel
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

    public ApiKeyWorkspaceScope()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyWorkspaceScope(ApiKeyWorkspaceScope apiKeyWorkspaceScope)
        : base(apiKeyWorkspaceScope) { }
#pragma warning restore CS8618

    public ApiKeyWorkspaceScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyWorkspaceScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyWorkspaceScopeFromRaw.FromRawUnchecked"/>
    public static ApiKeyWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyWorkspaceScope(string workspaceID)
        : this()
    {
        this.WorkspaceID = workspaceID;
    }
}

class ApiKeyWorkspaceScopeFromRaw : IFromRawJson<ApiKeyWorkspaceScope>
{
    /// <inheritdoc/>
    public ApiKeyWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyWorkspaceScope.FromRawUnchecked(rawData);
}
