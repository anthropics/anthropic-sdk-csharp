using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.Members;

[JsonConverter(typeof(JsonModelConverter<MemberRemoveResponse, MemberRemoveResponseFromRaw>))]
public sealed record class MemberRemoveResponse : JsonModel
{
    /// <summary>
    /// Deleted object type.
    ///
    /// <para>For Workspace Members, this is always `"workspace_member_deleted"`.</para>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workspace_member_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
        _ = this.WorkspaceID;
    }

    public MemberRemoveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemberRemoveResponse(MemberRemoveResponse memberRemoveResponse)
        : base(memberRemoveResponse) { }
#pragma warning restore CS8618

    public MemberRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemberRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemberRemoveResponseFromRaw.FromRawUnchecked"/>
    public static MemberRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemberRemoveResponseFromRaw : IFromRawJson<MemberRemoveResponse>
{
    /// <inheritdoc/>
    public MemberRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemberRemoveResponse.FromRawUnchecked(rawData);
}
