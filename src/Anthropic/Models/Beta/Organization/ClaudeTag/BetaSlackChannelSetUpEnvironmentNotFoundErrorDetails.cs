using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// `settings.environment_id` names no Environment within the organization's reach,
/// and the request had set the channel up by then. The channel stays set up with
/// every setting unset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails,
        BetaSlackChannelSetUpEnvironmentNotFoundErrorDetailsFromRaw
    >)
)]
public sealed record class BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("slack_channel_set_up_environment_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.SlackChannelID;
    }

    public BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_environment_not_found"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
        BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails betaSlackChannelSetUpEnvironmentNotFoundErrorDetails
    )
        : base(betaSlackChannelSetUpEnvironmentNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement(
            "slack_channel_set_up_environment_not_found"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSlackChannelSetUpEnvironmentNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails(string slackChannelID)
        : this()
    {
        this.SlackChannelID = slackChannelID;
    }
}

class BetaSlackChannelSetUpEnvironmentNotFoundErrorDetailsFromRaw
    : IFromRawJson<BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails.FromRawUnchecked(rawData);
}
