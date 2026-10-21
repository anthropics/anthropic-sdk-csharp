using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(typeof(JsonModelConverter<WorkspaceMember, WorkspaceMemberFromRaw>))]
public sealed record class WorkspaceMember : JsonModel
{
    /// <summary>
    /// Object type.
    ///
    /// <para>For Workspace Members, this is always `"workspace_member"`.</para>
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
    /// ID of the User.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// ID of the Workspace.
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
    /// Role of the Workspace Member.
    /// </summary>
    public required ApiEnum<string, WorkspaceRole> WorkspaceRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WorkspaceRole>>("workspace_role");
        }
        init { this._rawData.Set("workspace_role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workspace_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
        _ = this.WorkspaceID;
        this.WorkspaceRole.Validate();
    }

    public WorkspaceMember()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceMember(WorkspaceMember workspaceMember)
        : base(workspaceMember) { }
#pragma warning restore CS8618

    public WorkspaceMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceMemberFromRaw.FromRawUnchecked"/>
    public static WorkspaceMember FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceMemberFromRaw : IFromRawJson<WorkspaceMember>
{
    /// <inheritdoc/>
    public WorkspaceMember FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkspaceMember.FromRawUnchecked(rawData);
}
