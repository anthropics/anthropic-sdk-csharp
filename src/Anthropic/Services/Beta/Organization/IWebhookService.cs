using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an organization webhook endpoint.
    ///
    /// <para>An organization webhook endpoint belongs to the organization rather than
    /// to one of its workspaces. An organization can have at most 32 organization
    /// webhook endpoints, enabled or disabled.</para>
    ///
    /// <para>The response includes the endpoint's signing secret. No read returns it,
    /// so store it when you receive it.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<BetaNewOrganizationWebhookEndpoint> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an organization webhook endpoint by ID.
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<BetaOrganizationWebhookEndpoint> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<BetaOrganizationWebhookEndpoint> Retrieve(
        string webhookEndpointID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an organization webhook endpoint. Only the fields you send are changed.
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<BetaOrganizationWebhookEndpoint> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<BetaOrganizationWebhookEndpoint> Update(
        string webhookEndpointID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's webhook endpoints.
    ///
    /// <para>An organization webhook endpoint belongs to the organization rather than
    /// to one of its workspaces. The list does not include webhook endpoints that
    /// belong to a workspace.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<WebhookListPage> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an organization webhook endpoint.
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<BetaDeletedOrganizationWebhookEndpoint> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<BetaDeletedOrganizationWebhookEndpoint> Delete(
        string webhookEndpointID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace an organization webhook endpoint's signing secret. The old secret stops
    /// working immediately. The new secret is returned only in this response.
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// webhooks-2026-10-07`. A request without it returns `404`, exactly as if this API
    /// did not exist. Anthropic turns organization webhook endpoints on for each
    /// organization; until yours is on, requests also return `404`. Organization
    /// webhook endpoints are in beta and are not available to organizations with HIPAA
    /// readiness enabled.</para>
    /// </summary>
    Task<BetaOrganizationWebhookEndpointSigningSecret> RegenerateSigningSecret(
        WebhookRegenerateSigningSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RegenerateSigningSecret(WebhookRegenerateSigningSecretParams, CancellationToken)"/>
    Task<BetaOrganizationWebhookEndpointSigningSecret> RegenerateSigningSecret(
        string webhookEndpointID,
        WebhookRegenerateSigningSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaNewOrganizationWebhookEndpoint>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/webhooks/{webhook_endpoint_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Retrieve(WebhookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Retrieve(
        string webhookEndpointID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/webhooks/{webhook_endpoint_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Update(
        string webhookEndpointID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListPage>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/webhooks/{webhook_endpoint_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedOrganizationWebhookEndpoint>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedOrganizationWebhookEndpoint>> Delete(
        string webhookEndpointID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/webhooks/{webhook_endpoint_id}/regenerate_signing_secret</c>, but is otherwise the
    /// same as <see cref="IWebhookService.RegenerateSigningSecret(WebhookRegenerateSigningSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationWebhookEndpointSigningSecret>> RegenerateSigningSecret(
        WebhookRegenerateSigningSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RegenerateSigningSecret(WebhookRegenerateSigningSecretParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationWebhookEndpointSigningSecret>> RegenerateSigningSecret(
        string webhookEndpointID,
        WebhookRegenerateSigningSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
