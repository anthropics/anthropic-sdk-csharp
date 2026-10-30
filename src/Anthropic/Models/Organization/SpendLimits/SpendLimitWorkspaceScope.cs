using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

/// <summary>
/// Scope selecting one workspace of a Claude Console organization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SpendLimitWorkspaceScope, SpendLimitWorkspaceScopeFromRaw>)
)]
public sealed record class SpendLimitWorkspaceScope : JsonModel
{
    /// <summary>
    /// Scope type. Always `workspace` for this scope.
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
    /// Tagged ID of the workspace the spend limit applies to.
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

    public SpendLimitWorkspaceScope()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitWorkspaceScope(SpendLimitWorkspaceScope spendLimitWorkspaceScope)
        : base(spendLimitWorkspaceScope) { }
#pragma warning restore CS8618

    public SpendLimitWorkspaceScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitWorkspaceScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitWorkspaceScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitWorkspaceScope(string workspaceID)
        : this()
    {
        this.WorkspaceID = workspaceID;
    }
}

class SpendLimitWorkspaceScopeFromRaw : IFromRawJson<SpendLimitWorkspaceScope>
{
    /// <inheritdoc/>
    public SpendLimitWorkspaceScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitWorkspaceScope.FromRawUnchecked(rawData);
}
