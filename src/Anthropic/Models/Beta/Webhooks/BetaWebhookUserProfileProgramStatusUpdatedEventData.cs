using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebhookUserProfileProgramStatusUpdatedEventData,
        BetaWebhookUserProfileProgramStatusUpdatedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookUserProfileProgramStatusUpdatedEventData : JsonModel
{
    /// <summary>
    /// ID of the user profile that triggered the event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.OrganizationID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("user_profile.program_status_updated")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookUserProfileProgramStatusUpdatedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile.program_status_updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookUserProfileProgramStatusUpdatedEventData(
        BetaWebhookUserProfileProgramStatusUpdatedEventData betaWebhookUserProfileProgramStatusUpdatedEventData
    )
        : base(betaWebhookUserProfileProgramStatusUpdatedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookUserProfileProgramStatusUpdatedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile.program_status_updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookUserProfileProgramStatusUpdatedEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookUserProfileProgramStatusUpdatedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookUserProfileProgramStatusUpdatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookUserProfileProgramStatusUpdatedEventDataFromRaw
    : IFromRawJson<BetaWebhookUserProfileProgramStatusUpdatedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookUserProfileProgramStatusUpdatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookUserProfileProgramStatusUpdatedEventData.FromRawUnchecked(rawData);
}
