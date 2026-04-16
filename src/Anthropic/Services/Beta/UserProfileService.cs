using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class UserProfileService : IUserProfileService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "user-profiles-2026-03-24");
    }

    readonly Lazy<IUserProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IUserProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserProfileService(this._client.WithOptions(modifier));
    }

    public UserProfileService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserProfileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaUserProfile> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaUserProfile> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaUserProfile> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaUserProfile> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaUserProfile> Update(
        string userProfileID,
        UserProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserProfileListPage> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaUserProfileEnrollmentUrl> CreateEnrollmentUrl(
        UserProfileCreateEnrollmentUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateEnrollmentUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaUserProfileEnrollmentUrl> CreateEnrollmentUrl(
        string userProfileID,
        UserProfileCreateEnrollmentUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateEnrollmentUrl(
            parameters with
            {
                UserProfileID = userProfileID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class UserProfileServiceWithRawResponse : IUserProfileServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserProfileServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaUserProfile>> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaUserProfile = await response
                    .Deserialize<BetaUserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaUserProfile.Validate();
                }
                return betaUserProfile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaUserProfile>> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<UserProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaUserProfile = await response
                    .Deserialize<BetaUserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaUserProfile.Validate();
                }
                return betaUserProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaUserProfile>> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaUserProfile>> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<UserProfileUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaUserProfile = await response
                    .Deserialize<BetaUserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaUserProfile.Validate();
                }
                return betaUserProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaUserProfile>> Update(
        string userProfileID,
        UserProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserProfileListPage>> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserProfileListParams> request = new()
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
                    .Deserialize<UserProfileListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new UserProfileListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaUserProfileEnrollmentUrl>> CreateEnrollmentUrl(
        UserProfileCreateEnrollmentUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<UserProfileCreateEnrollmentUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaUserProfileEnrollmentUrl = await response
                    .Deserialize<BetaUserProfileEnrollmentUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaUserProfileEnrollmentUrl.Validate();
                }
                return betaUserProfileEnrollmentUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaUserProfileEnrollmentUrl>> CreateEnrollmentUrl(
        string userProfileID,
        UserProfileCreateEnrollmentUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateEnrollmentUrl(
            parameters with
            {
                UserProfileID = userProfileID,
            },
            cancellationToken
        );
    }
}
