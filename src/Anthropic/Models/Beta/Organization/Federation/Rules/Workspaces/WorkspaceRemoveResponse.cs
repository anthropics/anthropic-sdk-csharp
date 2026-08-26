using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

[JsonConverter(typeof(JsonModelConverter<WorkspaceRemoveResponse, WorkspaceRemoveResponseFromRaw>))]
public sealed record class WorkspaceRemoveResponse : JsonModel
{
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
    /// Tagged ID of the workspace named in the delete request. Removal is idempotent.
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
        _ = this.FederationRuleID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("federation_rule_workspace_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public WorkspaceRemoveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("federation_rule_workspace_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRemoveResponse(WorkspaceRemoveResponse workspaceRemoveResponse)
        : base(workspaceRemoveResponse) { }
#pragma warning restore CS8618

    public WorkspaceRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("federation_rule_workspace_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceRemoveResponseFromRaw.FromRawUnchecked"/>
    public static WorkspaceRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceRemoveResponseFromRaw : IFromRawJson<WorkspaceRemoveResponse>
{
    /// <inheritdoc/>
    public WorkspaceRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspaceRemoveResponse.FromRawUnchecked(rawData);
}
