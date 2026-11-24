using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <inheritdoc/>
public sealed class NoticeService : INoticeService
{
    readonly Lazy<INoticeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INoticeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public INoticeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NoticeService(this._client.WithOptions(modifier));
    }

    public NoticeService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new NoticeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<NoticeListPage> List(
        NoticeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NoticeServiceWithRawResponse : INoticeServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public INoticeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NoticeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NoticeServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NoticeListPage>> List(
        NoticeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NoticeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.compliance.review.notices.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<NoticeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new NoticeListPage(this, parameters, page);
            }
        );
    }
}
