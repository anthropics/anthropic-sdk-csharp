using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// The API could not finish checking whether an RBAC Group in the request grants
/// owner access (the check reached a fixed limit), so it made no change. Retrying
/// the same request will not help. Make the change in the organization's admin settings
/// in Claude.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RbacGroupOwnerAccessUnconfirmedErrorDetails,
        RbacGroupOwnerAccessUnconfirmedErrorDetailsFromRaw
    >)
)]
public sealed record class RbacGroupOwnerAccessUnconfirmedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("rbac_group_owner_access_unconfirmed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacGroupOwnerAccessUnconfirmedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_owner_access_unconfirmed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacGroupOwnerAccessUnconfirmedErrorDetails(
        RbacGroupOwnerAccessUnconfirmedErrorDetails rbacGroupOwnerAccessUnconfirmedErrorDetails
    )
        : base(rbacGroupOwnerAccessUnconfirmedErrorDetails) { }
#pragma warning restore CS8618

    public RbacGroupOwnerAccessUnconfirmedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("rbac_group_owner_access_unconfirmed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacGroupOwnerAccessUnconfirmedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacGroupOwnerAccessUnconfirmedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static RbacGroupOwnerAccessUnconfirmedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacGroupOwnerAccessUnconfirmedErrorDetailsFromRaw
    : IFromRawJson<RbacGroupOwnerAccessUnconfirmedErrorDetails>
{
    /// <inheritdoc/>
    public RbacGroupOwnerAccessUnconfirmedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacGroupOwnerAccessUnconfirmedErrorDetails.FromRawUnchecked(rawData);
}
