using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Webhooks;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "webhooks-2026-10-07");
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaNewOrganizationWebhookEndpoint> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaOrganizationWebhookEndpoint> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaOrganizationWebhookEndpoint> Retrieve(
        string webhookEndpointID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaOrganizationWebhookEndpoint> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaOrganizationWebhookEndpoint> Update(
        string webhookEndpointID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<WebhookListPage> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedOrganizationWebhookEndpoint> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedOrganizationWebhookEndpoint> Delete(
        string webhookEndpointID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaOrganizationWebhookEndpointSigningSecret> RegenerateSigningSecret(
        WebhookRegenerateSigningSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RegenerateSigningSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaOrganizationWebhookEndpointSigningSecret> RegenerateSigningSecret(
        string webhookEndpointID,
        WebhookRegenerateSigningSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RegenerateSigningSecret(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaNewOrganizationWebhookEndpoint>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaNewOrganizationWebhookEndpoint = await response
                    .Deserialize<BetaNewOrganizationWebhookEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaNewOrganizationWebhookEndpoint.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.webhook.id",
                    betaNewOrganizationWebhookEndpoint,
                    static created => created.ID
                );
                return betaNewOrganizationWebhookEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookEndpointID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.WebhookEndpointID' cannot be null"
            );
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.webhook.id", parameters.WebhookEndpointID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaOrganizationWebhookEndpoint = await response
                    .Deserialize<BetaOrganizationWebhookEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaOrganizationWebhookEndpoint.Validate();
                }
                return betaOrganizationWebhookEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Retrieve(
        string webhookEndpointID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookEndpointID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.WebhookEndpointID' cannot be null"
            );
        }

        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.update",
            SpanResourceIds =
            [
                new("anthropic.organization.webhook.id", parameters.WebhookEndpointID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaOrganizationWebhookEndpoint = await response
                    .Deserialize<BetaOrganizationWebhookEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaOrganizationWebhookEndpoint.Validate();
                }
                return betaOrganizationWebhookEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaOrganizationWebhookEndpoint>> Update(
        string webhookEndpointID,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListPage>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<WebhookListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WebhookListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedOrganizationWebhookEndpoint>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookEndpointID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.WebhookEndpointID' cannot be null"
            );
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.delete",
            SpanResourceIds =
            [
                new("anthropic.organization.webhook.id", parameters.WebhookEndpointID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedOrganizationWebhookEndpoint = await response
                    .Deserialize<BetaDeletedOrganizationWebhookEndpoint>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedOrganizationWebhookEndpoint.Validate();
                }
                return betaDeletedOrganizationWebhookEndpoint;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedOrganizationWebhookEndpoint>> Delete(
        string webhookEndpointID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<BetaOrganizationWebhookEndpointSigningSecret>
    > RegenerateSigningSecret(
        WebhookRegenerateSigningSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookEndpointID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.WebhookEndpointID' cannot be null"
            );
        }

        HttpRequest<WebhookRegenerateSigningSecretParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.webhooks.regenerate_signing_secret",
            SpanResourceIds =
            [
                new("anthropic.organization.webhook.id", parameters.WebhookEndpointID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaOrganizationWebhookEndpointSigningSecret = await response
                    .Deserialize<BetaOrganizationWebhookEndpointSigningSecret>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaOrganizationWebhookEndpointSigningSecret.Validate();
                }
                return betaOrganizationWebhookEndpointSigningSecret;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaOrganizationWebhookEndpointSigningSecret>> RegenerateSigningSecret(
        string webhookEndpointID,
        WebhookRegenerateSigningSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RegenerateSigningSecret(
            parameters with
            {
                WebhookEndpointID = webhookEndpointID,
            },
            cancellationToken
        );
    }
}
