using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The request set the channel up, and something else then changed the channel or
/// removed it. Nothing of `settings` was stored.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSlackChannelSetUpSettingsConflictErrorDetails,
        BetaSlackChannelSetUpSettingsConflictErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSlackChannelSetUpSettingsConflictErrorDetails : JsonModel
{
    /// <summary>
    /// A stable code that names the cause.
    /// </summary>
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// The identifier of the channel the request set up, starting with `slch_`.
    /// </summary>
    public required string SlackChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slack_channel_id");
        }
        init { this._rawData.Set("slack_channel_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("slack_channel_set_up_settings_conflict")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.SlackChannelID;
    }

    public BetaSlackChannelSetUpSettingsConflictErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_settings_conflict"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSlackChannelSetUpSettingsConflictErrorDetails(
        BetaSlackChannelSetUpSettingsConflictErrorDetails betaSlackChannelSetUpSettingsConflictErrorDetails
    )
        : base(betaSlackChannelSetUpSettingsConflictErrorDetails) { }
#pragma warning restore CS8618

    public BetaSlackChannelSetUpSettingsConflictErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_settings_conflict"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSlackChannelSetUpSettingsConflictErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSlackChannelSetUpSettingsConflictErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSlackChannelSetUpSettingsConflictErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSlackChannelSetUpSettingsConflictErrorDetails(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaSlackChannelSetUpSettingsConflictErrorDetailsFromRaw
    : IFromRawJson<BetaSlackChannelSetUpSettingsConflictErrorDetails>
{
    /// <inheritdoc/>
    public BetaSlackChannelSetUpSettingsConflictErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSlackChannelSetUpSettingsConflictErrorDetails.FromRawUnchecked(rawData);
}
