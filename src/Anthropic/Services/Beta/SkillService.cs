using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Skills;
using Anthropic.Services.Beta.Skills;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class SkillService : ISkillService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "skills-2025-10-02");
    }

    /// <inheritdoc/>
    public ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SkillService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public SkillService(IAnthropicClient client)
    {
        _client = client;
        _versions = new(() => new VersionService(client));
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    /// <inheritdoc/>
    public async Task<SkillCreateResponse> Create(
        SkillCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SkillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var skill = await response
            .Deserialize<SkillCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }

    /// <inheritdoc/>
    public async Task<SkillRetrieveResponse> Retrieve(
        SkillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SkillID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SkillID' cannot be null");
        }

        HttpRequest<SkillRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var skill = await response
            .Deserialize<SkillRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }

    /// <inheritdoc/>
    public async Task<SkillRetrieveResponse> Retrieve(
        string skillID,
        SkillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { SkillID = skillID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SkillListPage> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<SkillListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new SkillListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<SkillDeleteResponse> Delete(
        SkillDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SkillID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SkillID' cannot be null");
        }

        HttpRequest<SkillDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var skill = await response
            .Deserialize<SkillDeleteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }

    /// <inheritdoc/>
    public async Task<SkillDeleteResponse> Delete(
        string skillID,
        SkillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Delete(parameters with { SkillID = skillID }, cancellationToken);
    }
}
