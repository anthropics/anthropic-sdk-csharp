using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The request set the channel up, and `settings` was then refused. The channel stays
/// set up with every setting unset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSlackChannelSetUpSettingsRefusedErrorDetails,
        BetaSlackChannelSetUpSettingsRefusedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSlackChannelSetUpSettingsRefusedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("slack_channel_set_up_settings_refused")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.SlackChannelID;
    }

    public BetaSlackChannelSetUpSettingsRefusedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("slack_channel_set_up_settings_refused");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSlackChannelSetUpSettingsRefusedErrorDetails(
        BetaSlackChannelSetUpSettingsRefusedErrorDetails betaSlackChannelSetUpSettingsRefusedErrorDetails
    )
        : base(betaSlackChannelSetUpSettingsRefusedErrorDetails) { }
#pragma warning restore CS8618

    public BetaSlackChannelSetUpSettingsRefusedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("slack_channel_set_up_settings_refused");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSlackChannelSetUpSettingsRefusedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSlackChannelSetUpSettingsRefusedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSlackChannelSetUpSettingsRefusedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSlackChannelSetUpSettingsRefusedErrorDetails(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaSlackChannelSetUpSettingsRefusedErrorDetailsFromRaw
    : IFromRawJson<BetaSlackChannelSetUpSettingsRefusedErrorDetails>
{
    /// <inheritdoc/>
    public BetaSlackChannelSetUpSettingsRefusedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSlackChannelSetUpSettingsRefusedErrorDetails.FromRawUnchecked(rawData);
}
