using System;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Skills;
using Anthropic.Client.Services.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills;

public sealed class SkillService : ISkillService
{
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

    public async Task<SkillCreateResponse> Create(SkillCreateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SkillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var skill = await response.Deserialize<SkillCreateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }

    public async Task<SkillRetrieveResponse> Retrieve(SkillRetrieveParams parameters)
    {
        HttpRequest<SkillRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var skill = await response.Deserialize<SkillRetrieveResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }

    public async Task<SkillListPageResponse> List(SkillListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<SkillListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<SkillListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<SkillDeleteResponse> Delete(SkillDeleteParams parameters)
    {
        HttpRequest<SkillDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var skill = await response.Deserialize<SkillDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            skill.Validate();
        }
        return skill;
    }
}
