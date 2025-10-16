using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills.Versions;

public sealed class VersionService : IVersionService
{
    readonly IAnthropicClient _client;

    public VersionService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<VersionCreateResponse> Create(VersionCreateParams parameters)
    {
        HttpRequest<VersionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<VersionCreateResponse>().ConfigureAwait(false);
    }

    public async Task<VersionRetrieveResponse> Retrieve(VersionRetrieveParams parameters)
    {
        HttpRequest<VersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<VersionRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task<VersionListPageResponse> List(VersionListParams parameters)
    {
        HttpRequest<VersionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<VersionListPageResponse>().ConfigureAwait(false);
    }

    public async Task<VersionDeleteResponse> Delete(VersionDeleteParams parameters)
    {
        HttpRequest<VersionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<VersionDeleteResponse>().ConfigureAwait(false);
    }
}
