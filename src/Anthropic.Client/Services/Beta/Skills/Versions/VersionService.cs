using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Skills.Versions;

namespace Anthropic.Client.Services.Beta.Skills.Versions;

public sealed class VersionService : IVersionService
{
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public VersionService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<VersionCreateResponse> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<VersionRetrieveResponse> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<VersionListPageResponse> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
