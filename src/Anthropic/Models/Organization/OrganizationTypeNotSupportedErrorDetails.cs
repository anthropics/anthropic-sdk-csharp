using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// The endpoint does not support the organization's type. Each endpoint's description
/// says which organization types it supports.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OrganizationTypeNotSupportedErrorDetails,
        OrganizationTypeNotSupportedErrorDetailsFromRaw
    >)
)]
public sealed record class OrganizationTypeNotSupportedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("organization_type_not_supported")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationTypeNotSupportedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("organization_type_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationTypeNotSupportedErrorDetails(
        OrganizationTypeNotSupportedErrorDetails organizationTypeNotSupportedErrorDetails
    )
        : base(organizationTypeNotSupportedErrorDetails) { }
#pragma warning restore CS8618

    public OrganizationTypeNotSupportedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("organization_type_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationTypeNotSupportedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationTypeNotSupportedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static OrganizationTypeNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationTypeNotSupportedErrorDetailsFromRaw
    : IFromRawJson<OrganizationTypeNotSupportedErrorDetails>
{
    /// <inheritdoc/>
    public OrganizationTypeNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationTypeNotSupportedErrorDetails.FromRawUnchecked(rawData);
}
