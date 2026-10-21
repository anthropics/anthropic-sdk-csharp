using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.UserProfiles;
using Anthropic.Services.UserProfiles;

namespace Anthropic.Services;

/// <inheritdoc/>
public sealed class UserProfileService : IUserProfileService
{
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
        _actionUrls = new(() => new ActionUrlService(client));
    }

    readonly Lazy<IActionUrlService> _actionUrls;
    public IActionUrlService ActionUrls
    {
        get { return _actionUrls.Value; }
    }

    /// <inheritdoc/>
    public async Task<UserProfile> Create(
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
    public async Task<UserProfile> Retrieve(
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
    public Task<UserProfile> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserProfile> Update(
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
    public Task<UserProfile> Update(
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
    public async Task<DeletedUserProfile> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeletedUserProfile> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { UserProfileID = userProfileID }, cancellationToken);
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

        _actionUrls = new(() => new ActionUrlServiceWithRawResponse(client));
    }

    readonly Lazy<IActionUrlServiceWithRawResponse> _actionUrls;
    public IActionUrlServiceWithRawResponse ActionUrls
    {
        get { return _actionUrls.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserProfile>> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.user_profiles.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userProfile = await response
                    .Deserialize<UserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userProfile.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.user_profile.id",
                    userProfile,
                    static created => created.ID
                );
                return userProfile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserProfile>> Retrieve(
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
            SpanName = "anthropic.user_profiles.retrieve",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userProfile = await response
                    .Deserialize<UserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userProfile.Validate();
                }
                return userProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserProfile>> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserProfile>> Update(
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
            SpanName = "anthropic.user_profiles.update",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userProfile = await response
                    .Deserialize<UserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userProfile.Validate();
                }
                return userProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserProfile>> Update(
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
            SpanName = "anthropic.user_profiles.list",
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
    public async Task<HttpResponse<DeletedUserProfile>> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<UserProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            SpanName = "anthropic.user_profiles.delete",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deletedUserProfile = await response
                    .Deserialize<DeletedUserProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deletedUserProfile.Validate();
                }
                return deletedUserProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeletedUserProfile>> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }
}
