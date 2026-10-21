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
        BetaWebhookUserProfileEnforcementActionResolvedEventData,
        BetaWebhookUserProfileEnforcementActionResolvedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookUserProfileEnforcementActionResolvedEventData : JsonModel
{
    /// <summary>
    /// ID of the user profile the enforcement action is on.
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

    /// <summary>
    /// ID (`enac_...`) of the enforcement action that was opened or resolved.
    /// </summary>
    public required string EnforcementActionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("enforcement_action_id");
        }
        init { this._rawData.Set("enforcement_action_id", value); }
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
        _ = this.EnforcementActionID;
        _ = this.OrganizationID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("user_profile.enforcement_action_resolved")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookUserProfileEnforcementActionResolvedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile.enforcement_action_resolved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookUserProfileEnforcementActionResolvedEventData(
        BetaWebhookUserProfileEnforcementActionResolvedEventData betaWebhookUserProfileEnforcementActionResolvedEventData
    )
        : base(betaWebhookUserProfileEnforcementActionResolvedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookUserProfileEnforcementActionResolvedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile.enforcement_action_resolved");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookUserProfileEnforcementActionResolvedEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookUserProfileEnforcementActionResolvedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookUserProfileEnforcementActionResolvedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookUserProfileEnforcementActionResolvedEventDataFromRaw
    : IFromRawJson<BetaWebhookUserProfileEnforcementActionResolvedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookUserProfileEnforcementActionResolvedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookUserProfileEnforcementActionResolvedEventData.FromRawUnchecked(rawData);
}
