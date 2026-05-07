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
        BetaWebhookSessionCreatedEventData,
        BetaWebhookSessionCreatedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookSessionCreatedEventData : JsonModel
{
    /// <summary>
    /// ID of the resource that triggered the event.
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

    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.OrganizationID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session.created"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWebhookSessionCreatedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("session.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookSessionCreatedEventData(
        BetaWebhookSessionCreatedEventData betaWebhookSessionCreatedEventData
    )
        : base(betaWebhookSessionCreatedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookSessionCreatedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookSessionCreatedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookSessionCreatedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookSessionCreatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookSessionCreatedEventDataFromRaw : IFromRawJson<BetaWebhookSessionCreatedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookSessionCreatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookSessionCreatedEventData.FromRawUnchecked(rawData);
}
