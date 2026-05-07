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
        BetaWebhookSessionStatusRunStartedEventData,
        BetaWebhookSessionStatusRunStartedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookSessionStatusRunStartedEventData : JsonModel
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
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session.status_run_started")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWebhookSessionStatusRunStartedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("session.status_run_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookSessionStatusRunStartedEventData(
        BetaWebhookSessionStatusRunStartedEventData betaWebhookSessionStatusRunStartedEventData
    )
        : base(betaWebhookSessionStatusRunStartedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookSessionStatusRunStartedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session.status_run_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookSessionStatusRunStartedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookSessionStatusRunStartedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookSessionStatusRunStartedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookSessionStatusRunStartedEventDataFromRaw
    : IFromRawJson<BetaWebhookSessionStatusRunStartedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookSessionStatusRunStartedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookSessionStatusRunStartedEventData.FromRawUnchecked(rawData);
}
