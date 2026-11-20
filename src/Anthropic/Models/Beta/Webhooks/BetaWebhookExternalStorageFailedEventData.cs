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
        BetaWebhookExternalStorageFailedEventData,
        BetaWebhookExternalStorageFailedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookExternalStorageFailedEventData : JsonModel
{
    /// <summary>
    /// ID (`estrg_...`) of the External Storage whose bucket failed Anthropic's
    /// check or passes it again.
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
                JsonSerializer.SerializeToElement("external_storage.failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookExternalStorageFailedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("external_storage.failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookExternalStorageFailedEventData(
        BetaWebhookExternalStorageFailedEventData betaWebhookExternalStorageFailedEventData
    )
        : base(betaWebhookExternalStorageFailedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookExternalStorageFailedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_storage.failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookExternalStorageFailedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookExternalStorageFailedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookExternalStorageFailedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookExternalStorageFailedEventDataFromRaw
    : IFromRawJson<BetaWebhookExternalStorageFailedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookExternalStorageFailedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookExternalStorageFailedEventData.FromRawUnchecked(rawData);
}
