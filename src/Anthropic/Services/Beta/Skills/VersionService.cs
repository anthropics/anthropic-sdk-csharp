using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Services.Beta.Skills;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "skills-2025-10-02");
    }

    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<VersionCreateResponse> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionCreateResponse> Create(
        string skillID,
        VersionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionRetrieveResponse> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionRetrieveResponse> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionListPage> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionListPage> List(
        string skillID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionDeleteResponse> Delete(
        string version,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { Version = version }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionCreateResponse>> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SkillID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SkillID' cannot be null");
        }

        HttpRequest<VersionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var version = await response
                    .Deserialize<VersionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    version.Validate();
                }
                return version;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionCreateResponse>> Create(
        string skillID,
        VersionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<VersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var version = await response
                    .Deserialize<VersionRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    version.Validate();
                }
                return version;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionListPage>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SkillID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SkillID' cannot be null");
        }

        HttpRequest<VersionListParams> request = new()
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
                    .Deserialize<VersionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new VersionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionListPage>> List(
        string skillID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionDeleteResponse>> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<VersionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var version = await response
                    .Deserialize<VersionDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    version.Validate();
                }
                return version;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionDeleteResponse>> Delete(
        string version,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { Version = version }, cancellationToken);
    }
}
