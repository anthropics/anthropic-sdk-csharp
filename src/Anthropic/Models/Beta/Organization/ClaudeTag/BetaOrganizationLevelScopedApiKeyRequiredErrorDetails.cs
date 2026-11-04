using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The credential is not a scoped API key that is bound at the organization level.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationLevelScopedApiKeyRequiredErrorDetails,
        BetaOrganizationLevelScopedApiKeyRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class BetaOrganizationLevelScopedApiKeyRequiredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("organization_level_scoped_api_key_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationLevelScopedApiKeyRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "organization_level_scoped_api_key_required"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationLevelScopedApiKeyRequiredErrorDetails(
        BetaOrganizationLevelScopedApiKeyRequiredErrorDetails betaOrganizationLevelScopedApiKeyRequiredErrorDetails
    )
        : base(betaOrganizationLevelScopedApiKeyRequiredErrorDetails) { }
#pragma warning restore CS8618

    public BetaOrganizationLevelScopedApiKeyRequiredErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "organization_level_scoped_api_key_required"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationLevelScopedApiKeyRequiredErrorDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationLevelScopedApiKeyRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationLevelScopedApiKeyRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationLevelScopedApiKeyRequiredErrorDetailsFromRaw
    : IFromRawJson<BetaOrganizationLevelScopedApiKeyRequiredErrorDetails>
{
    /// <inheritdoc/>
    public BetaOrganizationLevelScopedApiKeyRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationLevelScopedApiKeyRequiredErrorDetails.FromRawUnchecked(rawData);
}
