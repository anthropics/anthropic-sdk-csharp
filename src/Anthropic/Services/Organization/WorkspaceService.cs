using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces;
using Workspaces = Anthropic.Services.Organization.Workspaces;

namespace Anthropic.Services.Organization;

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
        _rateLimits = new(() => new Workspaces::RateLimitService(client));
        _members = new(() => new Workspaces::MemberService(client));
        _serviceAccounts = new(() => new Workspaces::ServiceAccountService(client));
    }

    readonly Lazy<Workspaces::IRateLimitService> _rateLimits;
    public Workspaces::IRateLimitService RateLimits
    {
        get { return _rateLimits.Value; }
    }

    readonly Lazy<Workspaces::IMemberService> _members;
    public Workspaces::IMemberService Members
    {
        get { return _members.Value; }
    }

    readonly Lazy<Workspaces::IServiceAccountService> _serviceAccounts;
    public Workspaces::IServiceAccountService ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    /// <inheritdoc/>
    public async Task<Workspace> Create(
        WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Workspace> Retrieve(
        WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Workspace> Retrieve(
        string workspaceID,
        WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Workspace> Update(
        WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Workspace> Update(
        string workspaceID,
        WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkspaceListPage> List(
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Workspace> Archive(
        WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Workspace> Archive(
        string workspaceID,
        WorkspaceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { WorkspaceID = workspaceID }, cancellationToken);
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

        _rateLimits = new(() => new Workspaces::RateLimitServiceWithRawResponse(client));
        _members = new(() => new Workspaces::MemberServiceWithRawResponse(client));
        _serviceAccounts = new(() => new Workspaces::ServiceAccountServiceWithRawResponse(client));
    }

    readonly Lazy<Workspaces::IRateLimitServiceWithRawResponse> _rateLimits;
    public Workspaces::IRateLimitServiceWithRawResponse RateLimits
    {
        get { return _rateLimits.Value; }
    }

    readonly Lazy<Workspaces::IMemberServiceWithRawResponse> _members;
    public Workspaces::IMemberServiceWithRawResponse Members
    {
        get { return _members.Value; }
    }

    readonly Lazy<Workspaces::IServiceAccountServiceWithRawResponse> _serviceAccounts;
    public Workspaces::IServiceAccountServiceWithRawResponse ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Workspace>> Create(
        WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WorkspaceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspace = await response.Deserialize<Workspace>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspace.Validate();
                }
                return workspace;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Workspace>> Retrieve(
        WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspace = await response.Deserialize<Workspace>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspace.Validate();
                }
                return workspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Workspace>> Retrieve(
        string workspaceID,
        WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Workspace>> Update(
        WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspace = await response.Deserialize<Workspace>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspace.Validate();
                }
                return workspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Workspace>> Update(
        string workspaceID,
        WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
    public async Task<HttpResponse<Workspace>> Archive(
        WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspace = await response.Deserialize<Workspace>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspace.Validate();
                }
                return workspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Workspace>> Archive(
        string workspaceID,
        WorkspaceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}
