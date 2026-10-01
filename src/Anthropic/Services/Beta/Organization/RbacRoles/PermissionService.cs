using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Services.Beta.Organization.RbacRoles;

/// <inheritdoc/>
public sealed class PermissionService : IPermissionService
{
    readonly Lazy<IPermissionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPermissionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IPermissionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PermissionService(this._client.WithOptions(modifier));
    }

    public PermissionService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PermissionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PermissionListPage> List(
        PermissionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PermissionListPage> List(
        string rbacRoleID,
        PermissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RbacRoleID = rbacRoleID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PermissionServiceWithRawResponse : IPermissionServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPermissionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PermissionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PermissionServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PermissionListPage>> List(
        PermissionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacRoleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacRoleID' cannot be null");
        }

        HttpRequest<PermissionListParams> request = new()
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
                    .Deserialize<PermissionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PermissionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PermissionListPage>> List(
        string rbacRoleID,
        PermissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { RbacRoleID = rbacRoleID }, cancellationToken);
    }
}
