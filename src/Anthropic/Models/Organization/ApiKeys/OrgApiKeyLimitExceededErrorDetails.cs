using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

/// <summary>
/// The organization has reached its limit of active API keys.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        OrgApiKeyLimitExceededErrorDetails,
        OrgApiKeyLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class OrgApiKeyLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("org_api_key_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrgApiKeyLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("org_api_key_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrgApiKeyLimitExceededErrorDetails(
        OrgApiKeyLimitExceededErrorDetails orgApiKeyLimitExceededErrorDetails
    )
        : base(orgApiKeyLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public OrgApiKeyLimitExceededErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("org_api_key_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrgApiKeyLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrgApiKeyLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static OrgApiKeyLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrgApiKeyLimitExceededErrorDetailsFromRaw : IFromRawJson<OrgApiKeyLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public OrgApiKeyLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrgApiKeyLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
