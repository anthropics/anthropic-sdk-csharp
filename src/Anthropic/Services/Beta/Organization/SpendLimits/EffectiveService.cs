using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits.Effective;

namespace Anthropic.Services.Beta.Organization.SpendLimits;

/// <inheritdoc/>
public sealed class EffectiveService : IEffectiveService
{
    readonly Lazy<IEffectiveServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEffectiveServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IEffectiveService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EffectiveService(this._client.WithOptions(modifier));
    }

    public EffectiveService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EffectiveServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EffectiveListPage> List(
        EffectiveListParams? parameters = null,
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
public sealed class EffectiveServiceWithRawResponse : IEffectiveServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEffectiveServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EffectiveServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EffectiveServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EffectiveListPage>> List(
        EffectiveListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EffectiveListParams> request = new()
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
                    .Deserialize<EffectiveListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EffectiveListPage(this, parameters, page);
            }
        );
    }
}
