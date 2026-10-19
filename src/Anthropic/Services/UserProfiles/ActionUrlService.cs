using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Services.UserProfiles;

/// <inheritdoc/>
public sealed class ActionUrlService : IActionUrlService
{
    readonly Lazy<IActionUrlServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionUrlServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IActionUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ActionUrlService(this._client.WithOptions(modifier));
    }

    public ActionUrlService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ActionUrlServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UserProfileActionUrl> Create(
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserProfileActionUrl> Create(
        string userProfileID,
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActionUrlServiceWithRawResponse : IActionUrlServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionUrlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ActionUrlServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionUrlServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserProfileActionUrl>> Create(
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<ActionUrlCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.user_profiles.action_urls.create",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userProfileActionUrl = await response
                    .Deserialize<UserProfileActionUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userProfileActionUrl.Validate();
                }
                return userProfileActionUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserProfileActionUrl>> Create(
        string userProfileID,
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }
}
