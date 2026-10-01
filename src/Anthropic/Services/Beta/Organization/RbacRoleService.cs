using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacRoles;
using Anthropic.Services.Beta.Organization.RbacRoles;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class RbacRoleService : IRbacRoleService
{
    readonly Lazy<IRbacRoleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRbacRoleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRbacRoleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacRoleService(this._client.WithOptions(modifier));
    }

    public RbacRoleService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RbacRoleServiceWithRawResponse(client.WithRawResponse));
        _permissions = new(() => new PermissionService(client));
    }

    readonly Lazy<IPermissionService> _permissions;
    public IPermissionService Permissions
    {
        get { return _permissions.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaRbacRole> Retrieve(
        RbacRoleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaRbacRole> Retrieve(
        string rbacRoleID,
        RbacRoleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacRoleID = rbacRoleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacRoleListPage> List(
        RbacRoleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RbacRoleServiceWithRawResponse : IRbacRoleServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRbacRoleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacRoleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RbacRoleServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _permissions = new(() => new PermissionServiceWithRawResponse(client));
    }

    readonly Lazy<IPermissionServiceWithRawResponse> _permissions;
    public IPermissionServiceWithRawResponse Permissions
    {
        get { return _permissions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaRbacRole>> Retrieve(
        RbacRoleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacRoleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacRoleID' cannot be null");
        }

        HttpRequest<RbacRoleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaRbacRole = await response
                    .Deserialize<BetaRbacRole>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaRbacRole.Validate();
                }
                return betaRbacRole;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaRbacRole>> Retrieve(
        string rbacRoleID,
        RbacRoleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacRoleID = rbacRoleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacRoleListPage>> List(
        RbacRoleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RbacRoleListParams> request = new()
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
                    .Deserialize<RbacRoleListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RbacRoleListPage(this, parameters, page);
            }
        );
    }
}
