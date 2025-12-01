using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Services.Beta.Skills;

/// <inheritdoc />
public sealed class VersionService : IVersionService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "skills-2025-10-02");
    }

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public VersionService(IAnthropicClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<VersionCreateResponse> Create(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var version = await response
            .Deserialize<VersionCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            version.Validate();
        }
        return version;
    }

    /// <inheritdoc/>
    public async Task<VersionCreateResponse> Create(
        string skillID,
        VersionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Create(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var version = await response
            .Deserialize<VersionRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            version.Validate();
        }
        return version;
    }

    /// <inheritdoc/>
    public async Task<VersionRetrieveResponse> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<VersionListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<VersionListPageResponse> List(
        string skillID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionDeleteResponse> Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var version = await response
            .Deserialize<VersionDeleteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            version.Validate();
        }
        return version;
    }

    /// <inheritdoc/>
    public async Task<VersionDeleteResponse> Delete(
        string version,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Delete(parameters with { Version = version }, cancellationToken);
    }
}
