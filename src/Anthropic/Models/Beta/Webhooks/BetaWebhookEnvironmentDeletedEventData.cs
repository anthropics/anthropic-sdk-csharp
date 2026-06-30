using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebhookEnvironmentDeletedEventData,
        BetaWebhookEnvironmentDeletedEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookEnvironmentDeletedEventData : JsonModel
{
    /// <summary>
    /// ID of the environment that triggered the event.
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

    public required ApiEnum<string, BetaWebhookEnvironmentDeletedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaWebhookEnvironmentDeletedEventType>
            >("type");
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
        this.Type.Validate();
        _ = this.WorkspaceID;
    }

    public BetaWebhookEnvironmentDeletedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookEnvironmentDeletedEventData(
        BetaWebhookEnvironmentDeletedEventData betaWebhookEnvironmentDeletedEventData
    )
        : base(betaWebhookEnvironmentDeletedEventData) { }
#pragma warning restore CS8618

    public BetaWebhookEnvironmentDeletedEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookEnvironmentDeletedEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookEnvironmentDeletedEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookEnvironmentDeletedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookEnvironmentDeletedEventDataFromRaw
    : IFromRawJson<BetaWebhookEnvironmentDeletedEventData>
{
    /// <inheritdoc/>
    public BetaWebhookEnvironmentDeletedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookEnvironmentDeletedEventData.FromRawUnchecked(rawData);
}
