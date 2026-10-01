using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacGroups;
using Anthropic.Services.Beta.Organization.RbacGroups;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class RbacGroupService : IRbacGroupService
{
    readonly Lazy<IRbacGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRbacGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupService(this._client.WithOptions(modifier));
    }

    public RbacGroupService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RbacGroupServiceWithRawResponse(client.WithRawResponse));
        _members = new(() => new MemberService(client));
    }

    readonly Lazy<IMemberService> _members;
    public IMemberService Members
    {
        get { return _members.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaRbacGroup> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaRbacGroup> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaRbacGroup> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaRbacGroup> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaRbacGroup> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacGroupListPage> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RbacGroupDeleteResponse> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RbacGroupDeleteResponse> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RbacGroupServiceWithRawResponse : IRbacGroupServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RbacGroupServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _members = new(() => new MemberServiceWithRawResponse(client));
    }

    readonly Lazy<IMemberServiceWithRawResponse> _members;
    public IMemberServiceWithRawResponse Members
    {
        get { return _members.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaRbacGroup>> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RbacGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaRbacGroup = await response
                    .Deserialize<BetaRbacGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaRbacGroup.Validate();
                }
                return betaRbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaRbacGroup>> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaRbacGroup = await response
                    .Deserialize<BetaRbacGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaRbacGroup.Validate();
                }
                return betaRbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaRbacGroup>> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaRbacGroup>> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaRbacGroup = await response
                    .Deserialize<BetaRbacGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaRbacGroup.Validate();
                }
                return betaRbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaRbacGroup>> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroupListPage>> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RbacGroupListParams> request = new()
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
                    .Deserialize<RbacGroupListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RbacGroupListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroupDeleteResponse>> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rbacGroup = await response
                    .Deserialize<RbacGroupDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rbacGroup.Validate();
                }
                return rbacGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RbacGroupDeleteResponse>> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}
