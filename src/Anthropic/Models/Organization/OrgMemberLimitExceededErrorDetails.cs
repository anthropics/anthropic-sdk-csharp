using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// The organization has reached the member limit that Anthropic set for it. Pending
/// invites count toward the limit.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OrgMemberLimitExceededErrorDetails,
        OrgMemberLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class OrgMemberLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("org_member_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrgMemberLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("org_member_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrgMemberLimitExceededErrorDetails(
        OrgMemberLimitExceededErrorDetails orgMemberLimitExceededErrorDetails
    )
        : base(orgMemberLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public OrgMemberLimitExceededErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("org_member_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrgMemberLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrgMemberLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static OrgMemberLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrgMemberLimitExceededErrorDetailsFromRaw : IFromRawJson<OrgMemberLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public OrgMemberLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrgMemberLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
