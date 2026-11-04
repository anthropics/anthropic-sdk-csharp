using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// Anthropic has disabled the organization for trust and safety reasons. An organization
/// disabled for any other reason, such as billing, does not get this code. `appeal_url`,
/// when present, is where the organization can appeal.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OrganizationOnHoldErrorDetails,
        OrganizationOnHoldErrorDetailsFromRaw
    >)
)]
public sealed record class OrganizationOnHoldErrorDetails : JsonModel
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

    public string? AppealUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("appeal_url");
        }
        init { this._rawData.Set("appeal_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("organization_on_hold")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.AppealUrl;
    }

    public OrganizationOnHoldErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("organization_on_hold");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationOnHoldErrorDetails(
        OrganizationOnHoldErrorDetails organizationOnHoldErrorDetails
    )
        : base(organizationOnHoldErrorDetails) { }
#pragma warning restore CS8618

    public OrganizationOnHoldErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("organization_on_hold");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationOnHoldErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationOnHoldErrorDetailsFromRaw.FromRawUnchecked"/>
    public static OrganizationOnHoldErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationOnHoldErrorDetailsFromRaw : IFromRawJson<OrganizationOnHoldErrorDetails>
{
    /// <inheritdoc/>
    public OrganizationOnHoldErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationOnHoldErrorDetails.FromRawUnchecked(rawData);
}
