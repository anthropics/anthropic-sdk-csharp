using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Federation;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class FederationService : IFederationService
{
    readonly Lazy<IFederationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFederationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IFederationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FederationService(this._client.WithOptions(modifier));
    }

    public FederationService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FederationServiceWithRawResponse(client.WithRawResponse));
        _issuers = new(() => new IssuerService(client));
        _rules = new(() => new RuleService(client));
    }

    readonly Lazy<IIssuerService> _issuers;
    public IIssuerService Issuers
    {
        get { return _issuers.Value; }
    }

    readonly Lazy<IRuleService> _rules;
    public IRuleService Rules
    {
        get { return _rules.Value; }
    }
}

/// <inheritdoc/>
public sealed class FederationServiceWithRawResponse : IFederationServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFederationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FederationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FederationServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _issuers = new(() => new IssuerServiceWithRawResponse(client));
        _rules = new(() => new RuleServiceWithRawResponse(client));
    }

    readonly Lazy<IIssuerServiceWithRawResponse> _issuers;
    public IIssuerServiceWithRawResponse Issuers
    {
        get { return _issuers.Value; }
    }

    readonly Lazy<IRuleServiceWithRawResponse> _rules;
    public IRuleServiceWithRawResponse Rules
    {
        get { return _rules.Value; }
    }
}
