using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Services;

namespace Anthropic;

/// <summary>
/// A client for interacting with the Anthropic REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAnthropicClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    string? AuthToken { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAnthropicClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageService Messages { get; }

    IModelService Models { get; }

    IBetaService Beta { get; }
}

/// <summary>
/// A view of <see cref="IAnthropicClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IAnthropicClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    string? AuthToken { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnthropicClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageServiceWithRawResponse Messages { get; }

    IModelServiceWithRawResponse Models { get; }

    IBetaServiceWithRawResponse Beta { get; }

    /// <summary>
    /// Sends a request to the Anthropic REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
