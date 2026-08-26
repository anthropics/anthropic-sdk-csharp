using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(JsonModelConverter<BetaWorkspaceMember, BetaWorkspaceMemberFromRaw>))]
public sealed record class BetaWorkspaceMember : JsonModel
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
    public required ApiEnum<string, BetaWorkspaceRole> WorkspaceRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWorkspaceRole>>(
                "workspace_role"
            );
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

    public BetaWorkspaceMember()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceMember(BetaWorkspaceMember betaWorkspaceMember)
        : base(betaWorkspaceMember) { }
#pragma warning restore CS8618

    public BetaWorkspaceMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceMemberFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceMemberFromRaw : IFromRawJson<BetaWorkspaceMember>
{
    /// <inheritdoc/>
    public BetaWorkspaceMember FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWorkspaceMember.FromRawUnchecked(rawData);
}
