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
        BetaWebhookDeploymentCreatedEventData,
        BetaWebhookDeploymentCreatedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookDeploymentCreatedEventData : JsonModel
{
    /// <summary>
    /// ID of the deployment that triggered the event.
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
                JsonSerializer.SerializeToElement("deployment.created")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWebhookDeploymentCreatedEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("deployment.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookDeploymentCreatedEventData(
        BetaWebhookDeploymentCreatedEventData betaWebhookDeploymentCreatedEventData
    )
        : base(betaWebhookDeploymentCreatedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookDeploymentCreatedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("deployment.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookDeploymentCreatedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookDeploymentCreatedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookDeploymentCreatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookDeploymentCreatedEventDataFromRaw
    : IFromRawJson<BetaWebhookDeploymentCreatedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookDeploymentCreatedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookDeploymentCreatedEventData.FromRawUnchecked(rawData);
}
