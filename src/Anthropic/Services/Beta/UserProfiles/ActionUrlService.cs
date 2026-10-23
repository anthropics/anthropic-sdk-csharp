using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;

namespace Anthropic.Services.Beta.UserProfiles;

/// <inheritdoc/>
public sealed class ActionUrlService : IActionUrlService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "user-profiles-2026-08-18");
    }

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
    public async Task<BetaUserProfileActionUrl> Create(
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
    public Task<BetaUserProfileActionUrl> Create(
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
    public async Task<HttpResponse<BetaUserProfileActionUrl>> Create(
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
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.user_profiles.action_urls.create",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaUserProfileActionUrl = await response
                    .Deserialize<BetaUserProfileActionUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaUserProfileActionUrl.Validate();
                }
                return betaUserProfileActionUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaUserProfileActionUrl>> Create(
        string userProfileID,
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }
}
