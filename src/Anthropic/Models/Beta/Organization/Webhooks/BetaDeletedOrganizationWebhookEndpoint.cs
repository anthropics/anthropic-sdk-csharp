using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// A deleted organization webhook endpoint.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaDeletedOrganizationWebhookEndpoint,
        BetaDeletedOrganizationWebhookEndpointFromRaw
    >)
)]
public sealed record class BetaDeletedOrganizationWebhookEndpoint : JsonModel
{
    /// <summary>
    /// ID of the deleted webhook endpoint.
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
    /// Always `webhook_endpoint_deleted`.
    /// </summary>
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("webhook_endpoint_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedOrganizationWebhookEndpoint()
    {
        this.Type = JsonSerializer.SerializeToElement("webhook_endpoint_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedOrganizationWebhookEndpoint(
        BetaDeletedOrganizationWebhookEndpoint betaDeletedOrganizationWebhookEndpoint
    )
        : base(betaDeletedOrganizationWebhookEndpoint) { }
#pragma warning restore CS8618

    public BetaDeletedOrganizationWebhookEndpoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("webhook_endpoint_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedOrganizationWebhookEndpoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedOrganizationWebhookEndpointFromRaw.FromRawUnchecked"/>
    public static BetaDeletedOrganizationWebhookEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedOrganizationWebhookEndpoint(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDeletedOrganizationWebhookEndpointFromRaw
    : IFromRawJson<BetaDeletedOrganizationWebhookEndpoint>
{
    /// <inheritdoc/>
    public BetaDeletedOrganizationWebhookEndpoint FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedOrganizationWebhookEndpoint.FromRawUnchecked(rawData);
}
