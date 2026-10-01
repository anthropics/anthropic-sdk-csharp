using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Skills;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class SkillService : ISkillService
{
    readonly Lazy<ISkillServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillService(this._client.WithOptions(modifier));
    }

    public SkillService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SkillServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SkillListPage> List(
        SkillListParams? parameters = null,
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
public sealed class SkillServiceWithRawResponse : ISkillServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SkillServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SkillListPage>> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SkillListParams> request = new()
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
                    .Deserialize<SkillListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SkillListPage(this, parameters, page);
            }
        );
    }
}
