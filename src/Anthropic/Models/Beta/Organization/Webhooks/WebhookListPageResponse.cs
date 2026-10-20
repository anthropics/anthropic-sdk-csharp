using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// A page of organization webhook endpoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookListPageResponse, WebhookListPageResponseFromRaw>))]
public sealed record class WebhookListPageResponse : JsonModel
{
    /// <summary>
    /// The organization webhook endpoints on this page.
    /// </summary>
    public required IReadOnlyList<BetaOrganizationWebhookEndpoint> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaOrganizationWebhookEndpoint>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaOrganizationWebhookEndpoint>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether more endpoints follow this page in list order. With `before_id`, only
    /// endpoints before the cursor count.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// First ID in the `data` list.
    /// </summary>
    public string? FirstID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_id");
        }
        init { this._rawData.Set("first_id", value); }
    }

    /// <summary>
    /// Last ID in the `data` list. Can be used as the `after_id` for the next page.
    /// </summary>
    public string? LastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_id");
        }
        init { this._rawData.Set("last_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.FirstID;
        _ = this.LastID;
    }

    public WebhookListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookListPageResponse(WebhookListPageResponse webhookListPageResponse)
        : base(webhookListPageResponse) { }
#pragma warning restore CS8618

    public WebhookListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookListPageResponseFromRaw.FromRawUnchecked"/>
    public static WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookListPageResponseFromRaw : IFromRawJson<WebhookListPageResponse>
{
    /// <inheritdoc/>
    public WebhookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookListPageResponse.FromRawUnchecked(rawData);
}
