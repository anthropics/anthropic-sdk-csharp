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
        BetaWebhookExternalKeyFailedEventData,
        BetaWebhookExternalKeyFailedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookExternalKeyFailedEventData : JsonModel
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
                JsonSerializer.SerializeToElement("external_key.failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookExternalKeyFailedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key.failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookExternalKeyFailedEventData(
        BetaWebhookExternalKeyFailedEventData betaWebhookExternalKeyFailedEventData
    )
        : base(betaWebhookExternalKeyFailedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookExternalKeyFailedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key.failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookExternalKeyFailedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookExternalKeyFailedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookExternalKeyFailedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookExternalKeyFailedEventDataFromRaw
    : IFromRawJson<BetaWebhookExternalKeyFailedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookExternalKeyFailedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookExternalKeyFailedEventData.FromRawUnchecked(rawData);
}
