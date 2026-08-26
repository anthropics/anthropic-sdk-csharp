using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Models.Beta.Organization.ServiceAccounts;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaServiceAccountWorkspaceMember,
        BetaServiceAccountWorkspaceMemberFromRaw
    >)
)]
public sealed record class BetaServiceAccountWorkspaceMember : JsonModel
{
    /// <summary>
    /// Tagged ID (`user_...`/`svac_...`) of the actor who created this membership.
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
    /// True when this is the implicit default-workspace membership every service
    /// account has when no explicit membership exists. Implicit memberships have
    /// role `workspace_user` and cannot be removed.
    /// </summary>
    public required bool? Implicit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("implicit");
        }
        init { this._rawData.Set("implicit", value); }
    }

    /// <summary>
    /// Tagged service account ID (`svac_...`).
    /// </summary>
    public required string ServiceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_account_id");
        }
        init { this._rawData.Set("service_account_id", value); }
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
    /// Tagged workspace ID (`wrkspc_...`).
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
    /// Role of the service account in this workspace. Service accounts cannot hold
    /// the `workspace_billing` role.
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
        _ = this.CreatedByActorID;
        _ = this.Implicit;
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_workspace_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
        this.WorkspaceRole.Validate();
    }

    public BetaServiceAccountWorkspaceMember()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServiceAccountWorkspaceMember(
        BetaServiceAccountWorkspaceMember betaServiceAccountWorkspaceMember
    )
        : base(betaServiceAccountWorkspaceMember) { }
#pragma warning restore CS8618

    public BetaServiceAccountWorkspaceMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_workspace_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServiceAccountWorkspaceMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServiceAccountWorkspaceMemberFromRaw.FromRawUnchecked"/>
    public static BetaServiceAccountWorkspaceMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaServiceAccountWorkspaceMemberFromRaw : IFromRawJson<BetaServiceAccountWorkspaceMember>
{
    /// <inheritdoc/>
    public BetaServiceAccountWorkspaceMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaServiceAccountWorkspaceMember.FromRawUnchecked(rawData);
}
