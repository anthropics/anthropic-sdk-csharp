using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;

namespace Anthropic.Services.Beta.Organization.Analytics.Apps.Chat;

/// <inheritdoc/>
public sealed class ProjectService : IProjectService
{
    readonly Lazy<IProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectService(this._client.WithOptions(modifier));
    }

    public ProjectService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProjectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ProjectListPage> List(
        ProjectListParams? parameters = null,
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
public sealed class ProjectServiceWithRawResponse : IProjectServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProjectServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProjectListPage>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProjectListParams> request = new()
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
                    .Deserialize<ProjectListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ProjectListPage(this, parameters, page);
            }
        );
    }
}
