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
        BetaWebhookSessionBudgetReachedEventData,
        BetaWebhookSessionBudgetReachedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookSessionBudgetReachedEventData : JsonModel
{
    /// <summary>
    /// ID of the session that triggered the event.
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
                JsonSerializer.SerializeToElement("session.budget_reached")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWebhookSessionBudgetReachedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("session.budget_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookSessionBudgetReachedEventData(
        BetaWebhookSessionBudgetReachedEventData betaWebhookSessionBudgetReachedEventData
    )
        : base(betaWebhookSessionBudgetReachedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookSessionBudgetReachedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session.budget_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookSessionBudgetReachedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookSessionBudgetReachedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookSessionBudgetReachedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookSessionBudgetReachedEventDataFromRaw
    : IFromRawJson<BetaWebhookSessionBudgetReachedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookSessionBudgetReachedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookSessionBudgetReachedEventData.FromRawUnchecked(rawData);
}
