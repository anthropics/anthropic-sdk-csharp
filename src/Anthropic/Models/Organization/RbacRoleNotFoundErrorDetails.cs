using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// No RBAC Role with this ID was found.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RbacRoleNotFoundErrorDetails, RbacRoleNotFoundErrorDetailsFromRaw>)
)]
public sealed record class RbacRoleNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("rbac_role_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacRoleNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_role_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRoleNotFoundErrorDetails(RbacRoleNotFoundErrorDetails rbacRoleNotFoundErrorDetails)
        : base(rbacRoleNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public RbacRoleNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_role_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRoleNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRoleNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RbacRoleNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRoleNotFoundErrorDetailsFromRaw : IFromRawJson<RbacRoleNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public RbacRoleNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacRoleNotFoundErrorDetails.FromRawUnchecked(rawData);
}
