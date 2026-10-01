using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Users;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UserListPage> List(
        UserListParams? parameters = null,
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
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserListPage>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserListParams> request = new()
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
                    .Deserialize<UserListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new UserListPage(this, parameters, page);
            }
        );
    }
}
