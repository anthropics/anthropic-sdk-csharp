using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Federation.Rules;

[JsonConverter(typeof(JsonModelConverter<FederationRuleWorkspace, FederationRuleWorkspaceFromRaw>))]
public sealed record class FederationRuleWorkspace : JsonModel
{
    /// <summary>
    /// When this workspace was enabled for the rule.
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
    /// Tagged ID (`user_...` or `svac_...`) of the actor that enabled this workspace
    /// for the rule, if known.
    /// </summary>
    public required string? CreatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by_actor_id");
        }
        init { this._rawData.Set("created_by_actor_id", value); }
    }

    /// <summary>
    /// Tagged ID of the federation rule.
    /// </summary>
    public required string FederationRuleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("federation_rule_id");
        }
        init { this._rawData.Set("federation_rule_id", value); }
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
    /// Tagged ID of the workspace this rule is enabled for.
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

    /// <summary>
    /// Workspace display name. Populated when listing; null in the enable response.
    /// </summary>
    public required string? WorkspaceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_name");
        }
        init { this._rawData.Set("workspace_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.CreatedByActorID;
        _ = this.FederationRuleID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("federation_rule_workspace")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
        _ = this.WorkspaceName;
    }

    public FederationRuleWorkspace()
    {
        this.Type = JsonSerializer.SerializeToElement("federation_rule_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FederationRuleWorkspace(FederationRuleWorkspace federationRuleWorkspace)
        : base(federationRuleWorkspace) { }
#pragma warning restore CS8618

    public FederationRuleWorkspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("federation_rule_workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FederationRuleWorkspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FederationRuleWorkspaceFromRaw.FromRawUnchecked"/>
    public static FederationRuleWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FederationRuleWorkspaceFromRaw : IFromRawJson<FederationRuleWorkspace>
{
    /// <inheritdoc/>
    public FederationRuleWorkspace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FederationRuleWorkspace.FromRawUnchecked(rawData);
}
