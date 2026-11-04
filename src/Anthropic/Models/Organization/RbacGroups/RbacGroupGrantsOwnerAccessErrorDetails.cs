using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacGroups;

/// <summary>
/// A role attached to an RBAC Group in the request grants owner access, so this API
/// does not add members to that group (directly or through an invite), remove its
/// members, or delete it. Make the change in the organization's admin settings in Claude.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RbacGroupGrantsOwnerAccessErrorDetails,
        RbacGroupGrantsOwnerAccessErrorDetailsFromRaw
    >)
)]
public sealed record class RbacGroupGrantsOwnerAccessErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("rbac_group_grants_owner_access")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacGroupGrantsOwnerAccessErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_grants_owner_access");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacGroupGrantsOwnerAccessErrorDetails(
        RbacGroupGrantsOwnerAccessErrorDetails rbacGroupGrantsOwnerAccessErrorDetails
    )
        : base(rbacGroupGrantsOwnerAccessErrorDetails) { }
#pragma warning restore CS8618

    public RbacGroupGrantsOwnerAccessErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_grants_owner_access");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacGroupGrantsOwnerAccessErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacGroupGrantsOwnerAccessErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RbacGroupGrantsOwnerAccessErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacGroupGrantsOwnerAccessErrorDetailsFromRaw
    : IFromRawJson<RbacGroupGrantsOwnerAccessErrorDetails>
{
    /// <inheritdoc/>
    public RbacGroupGrantsOwnerAccessErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacGroupGrantsOwnerAccessErrorDetails.FromRawUnchecked(rawData);
}
