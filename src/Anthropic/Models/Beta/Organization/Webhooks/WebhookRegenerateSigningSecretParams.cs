using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.Webhooks;

/// <summary>
/// Replace an organization webhook endpoint's signing secret. The old secret stops
/// working immediately. The new secret is returned only in this response.
///
/// <para>Every request must include the beta header `anthropic-beta: webhooks-2026-10-07`.
/// A request without it returns `404`, exactly as if this API did not exist. Anthropic
/// turns organization webhook endpoints on for each organization; until yours is
/// on, requests also return `404`. Organization webhook endpoints are in beta and
/// are not available to organizations with HIPAA readiness enabled.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookRegenerateSigningSecretParams : ParamsBase
{
    public string? WebhookEndpointID { get; init; }

    /// <summary>
    /// This endpoint is in beta: requests must send `webhooks-2026-10-07` in this header.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public WebhookRegenerateSigningSecretParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRegenerateSigningSecretParams(
        WebhookRegenerateSigningSecretParams webhookRegenerateSigningSecretParams
    )
        : base(webhookRegenerateSigningSecretParams)
    {
        this.WebhookEndpointID = webhookRegenerateSigningSecretParams.WebhookEndpointID;
    }
#pragma warning restore CS8618

    public WebhookRegenerateSigningSecretParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRegenerateSigningSecretParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string webhookEndpointID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.WebhookEndpointID = webhookEndpointID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookRegenerateSigningSecretParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string webhookEndpointID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            webhookEndpointID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["WebhookEndpointID"] = JsonSerializer.SerializeToElement(
                        this.WebhookEndpointID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WebhookRegenerateSigningSecretParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.WebhookEndpointID?.Equals(other.WebhookEndpointID)
                ?? other.WebhookEndpointID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/webhooks/{0}/regenerate_signing_secret",
                    ParamsBase.EncodePathSegment(
                        this.WebhookEndpointID,
                        nameof(this.WebhookEndpointID)
                    )
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/webhooks/{webhook_endpoint_id}/regenerate_signing_secret";

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        WebhookService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
