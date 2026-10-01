using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Artifacts;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class ArtifactService : IArtifactService
{
    readonly Lazy<IArtifactServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IArtifactService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtifactService(this._client.WithOptions(modifier));
    }

    public ArtifactService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ArtifactServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ArtifactListPage> List(
        ArtifactListParams parameters,
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
public sealed class ArtifactServiceWithRawResponse : IArtifactServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtifactServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ArtifactServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ArtifactListPage>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtifactListParams> request = new()
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
                    .Deserialize<ArtifactListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ArtifactListPage(this, parameters, page);
            }
        );
    }
}
