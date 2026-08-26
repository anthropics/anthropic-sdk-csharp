using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Federation.Rules;
using Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Services.Beta.Organization.Federation.Rules;

/// <inheritdoc/>
public sealed class WorkspaceService : IWorkspaceService
{
    readonly Lazy<IWorkspaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkspaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkspaceService(this._client.WithOptions(modifier));
    }

    public WorkspaceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkspaceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WorkspaceListPage> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspaceListPage> List(
        string federationRuleID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaFederationRuleWorkspace> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationRuleWorkspace> Add(
        string federationRuleID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { FederationRuleID = federationRuleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkspaceRemoveResponse> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspaceRemoveResponse> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WorkspaceServiceWithRawResponse : IWorkspaceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkspaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkspaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkspaceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationRuleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FederationRuleID' cannot be null");
        }

        HttpRequest<WorkspaceListParams> request = new()
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
                    .Deserialize<WorkspaceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WorkspaceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspaceListPage>> List(
        string federationRuleID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationRuleWorkspace>> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationRuleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FederationRuleID' cannot be null");
        }

        HttpRequest<WorkspaceAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationRuleWorkspace = await response
                    .Deserialize<BetaFederationRuleWorkspace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationRuleWorkspace.Validate();
                }
                return betaFederationRuleWorkspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationRuleWorkspace>> Add(
        string federationRuleID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { FederationRuleID = federationRuleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspaceRemoveResponse>> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspace = await response
                    .Deserialize<WorkspaceRemoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspace.Validate();
                }
                return workspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspaceRemoveResponse>> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}
