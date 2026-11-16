using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The endpoint serves only organizations that belong to a parent organization, and
/// this organization belongs to none.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ParentOrganizationRequiredErrorDetails,
        ParentOrganizationRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class ParentOrganizationRequiredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("parent_organization_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ParentOrganizationRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("parent_organization_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParentOrganizationRequiredErrorDetails(
        ParentOrganizationRequiredErrorDetails parentOrganizationRequiredErrorDetails
    )
        : base(parentOrganizationRequiredErrorDetails) { }
#pragma warning restore CS8618

    public ParentOrganizationRequiredErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("parent_organization_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParentOrganizationRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParentOrganizationRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ParentOrganizationRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParentOrganizationRequiredErrorDetailsFromRaw
    : IFromRawJson<ParentOrganizationRequiredErrorDetails>
{
    /// <inheritdoc/>
    public ParentOrganizationRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParentOrganizationRequiredErrorDetails.FromRawUnchecked(rawData);
}
