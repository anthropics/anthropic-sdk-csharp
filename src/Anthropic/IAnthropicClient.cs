using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Services;

namespace Anthropic;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAnthropicClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string? APIKey { get; init; }

    string? AuthToken { get; init; }

    IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageService Messages { get; }

    IModelService Models { get; }

    IBetaService Beta { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
