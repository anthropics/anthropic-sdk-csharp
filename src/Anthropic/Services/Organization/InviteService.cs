using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Invites;

namespace Anthropic.Services.Organization;

/// <inheritdoc/>
public sealed class InviteService : IInviteService
{
    readonly Lazy<IInviteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInviteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IInviteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InviteService(this._client.WithOptions(modifier));
    }

    public InviteService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InviteServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OrganizationInvite> Create(
        InviteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OrganizationInvite> Retrieve(
        InviteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OrganizationInvite> Retrieve(
        string inviteID,
        InviteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InviteID = inviteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InviteListPage> List(
        InviteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InviteDeleteResponse> Delete(
        InviteDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InviteDeleteResponse> Delete(
        string inviteID,
        InviteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { InviteID = inviteID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InviteServiceWithRawResponse : IInviteServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInviteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InviteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InviteServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationInvite>> Create(
        InviteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InviteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizationInvite = await response
                    .Deserialize<OrganizationInvite>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizationInvite.Validate();
                }
                return organizationInvite;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrganizationInvite>> Retrieve(
        InviteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InviteID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.InviteID' cannot be null");
        }

        HttpRequest<InviteRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var organizationInvite = await response
                    .Deserialize<OrganizationInvite>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    organizationInvite.Validate();
                }
                return organizationInvite;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OrganizationInvite>> Retrieve(
        string inviteID,
        InviteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InviteID = inviteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InviteListPage>> List(
        InviteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InviteListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<InviteListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InviteListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InviteDeleteResponse>> Delete(
        InviteDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InviteID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.InviteID' cannot be null");
        }

        HttpRequest<InviteDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invite = await response
                    .Deserialize<InviteDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invite.Validate();
                }
                return invite;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InviteDeleteResponse>> Delete(
        string inviteID,
        InviteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { InviteID = inviteID }, cancellationToken);
    }
}
