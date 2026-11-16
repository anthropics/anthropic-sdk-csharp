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
        BetaWebhookExternalKeyRecoveredEventData,
        BetaWebhookExternalKeyRecoveredEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookExternalKeyRecoveredEventData : JsonModel
{
    /// <summary>
    /// ID (`ekey_...`) of the external key that stopped working or works again.
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
                JsonSerializer.SerializeToElement("external_key.recovered")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookExternalKeyRecoveredEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookExternalKeyRecoveredEventData(
        BetaWebhookExternalKeyRecoveredEventData betaWebhookExternalKeyRecoveredEventData
    )
        : base(betaWebhookExternalKeyRecoveredEventData) { }
#pragma warning restore CS8618

    public BetaWebhookExternalKeyRecoveredEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key.recovered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookExternalKeyRecoveredEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookExternalKeyRecoveredEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookExternalKeyRecoveredEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookExternalKeyRecoveredEventDataFromRaw
    : IFromRawJson<BetaWebhookExternalKeyRecoveredEventData>
{
    /// <inheritdoc/>
    public BetaWebhookExternalKeyRecoveredEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookExternalKeyRecoveredEventData.FromRawUnchecked(rawData);
}
