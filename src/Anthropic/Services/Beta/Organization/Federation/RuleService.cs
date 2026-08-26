using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Federation.Rules;
using Rules = Anthropic.Services.Beta.Organization.Federation.Rules;

namespace Anthropic.Services.Beta.Organization.Federation;

/// <inheritdoc/>
public sealed class RuleService : IRuleService
{
    readonly Lazy<IRuleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRuleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRuleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleService(this._client.WithOptions(modifier));
    }

    public RuleService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RuleServiceWithRawResponse(client.WithRawResponse));
        _workspaces = new(() => new Rules::WorkspaceService(client));
    }

    readonly Lazy<Rules::IWorkspaceService> _workspaces;
    public Rules::IWorkspaceService Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaFederationRule> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaFederationRule> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationRule> Retrieve(
        string federationRuleID,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaFederationRule> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationRule> Update(
        string federationRuleID,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<RuleListPage> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaFederationRule> Archive(
        RuleArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationRule> Archive(
        string federationRuleID,
        RuleArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class RuleServiceWithRawResponse : IRuleServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRuleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RuleServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _workspaces = new(() => new Rules::WorkspaceServiceWithRawResponse(client));
    }

    readonly Lazy<Rules::IWorkspaceServiceWithRawResponse> _workspaces;
    public Rules::IWorkspaceServiceWithRawResponse Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationRule>> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RuleCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationRule = await response
                    .Deserialize<BetaFederationRule>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationRule.Validate();
                }
                return betaFederationRule;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationRule>> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationRuleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FederationRuleID' cannot be null");
        }

        HttpRequest<RuleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationRule = await response
                    .Deserialize<BetaFederationRule>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationRule.Validate();
                }
                return betaFederationRule;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationRule>> Retrieve(
        string federationRuleID,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationRule>> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationRuleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FederationRuleID' cannot be null");
        }

        HttpRequest<RuleUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationRule = await response
                    .Deserialize<BetaFederationRule>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationRule.Validate();
                }
                return betaFederationRule;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationRule>> Update(
        string federationRuleID,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleListPage>> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RuleListParams> request = new()
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
                    .Deserialize<RuleListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RuleListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationRule>> Archive(
        RuleArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationRuleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FederationRuleID' cannot be null");
        }

        HttpRequest<RuleArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationRule = await response
                    .Deserialize<BetaFederationRule>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationRule.Validate();
                }
                return betaFederationRule;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationRule>> Archive(
        string federationRuleID,
        RuleArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                FederationRuleID = federationRuleID,
            },
            cancellationToken
        );
    }
}
