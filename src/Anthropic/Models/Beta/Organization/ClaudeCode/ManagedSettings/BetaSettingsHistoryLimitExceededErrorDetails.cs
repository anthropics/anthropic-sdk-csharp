using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The organization has reached its settings history limit, a cap on stored versions
/// of its settings documents. Nothing in the API or claude.ai lowers the count,
/// so contact support. Creating or deleting group settings, creating or clearing
/// the default settings, and reordering are refused. Changing the mode still works,
/// unless it would copy the organization settings into a new default.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSettingsHistoryLimitExceededErrorDetails,
        BetaSettingsHistoryLimitExceededErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSettingsHistoryLimitExceededErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("settings_history_limit_exceeded")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSettingsHistoryLimitExceededErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("settings_history_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSettingsHistoryLimitExceededErrorDetails(
        BetaSettingsHistoryLimitExceededErrorDetails betaSettingsHistoryLimitExceededErrorDetails
    )
        : base(betaSettingsHistoryLimitExceededErrorDetails) { }
#pragma warning restore CS8618

    public BetaSettingsHistoryLimitExceededErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("settings_history_limit_exceeded");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSettingsHistoryLimitExceededErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSettingsHistoryLimitExceededErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSettingsHistoryLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSettingsHistoryLimitExceededErrorDetailsFromRaw
    : IFromRawJson<BetaSettingsHistoryLimitExceededErrorDetails>
{
    /// <inheritdoc/>
    public BetaSettingsHistoryLimitExceededErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSettingsHistoryLimitExceededErrorDetails.FromRawUnchecked(rawData);
}
