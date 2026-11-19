using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The organization has reached its limit of settings documents, counting unused
/// ones. An owner can remove unused documents in claude.ai. Deleting a group's settings
/// or clearing the default settings also frees a document, if nothing else uses it.
/// None of these works once the organization has also reached its settings history limit.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSettingsDocumentLimitExceededErrorDetails,
        BetaSettingsDocumentLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSettingsDocumentLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("settings_document_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSettingsDocumentLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("settings_document_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSettingsDocumentLimitExceededErrorDetails(
        BetaSettingsDocumentLimitExceededErrorDetails betaSettingsDocumentLimitExceededErrorDetails
    )
        : base(betaSettingsDocumentLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public BetaSettingsDocumentLimitExceededErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("settings_document_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSettingsDocumentLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSettingsDocumentLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSettingsDocumentLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSettingsDocumentLimitExceededErrorDetailsFromRaw
    : IFromRawJson<BetaSettingsDocumentLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public BetaSettingsDocumentLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSettingsDocumentLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
